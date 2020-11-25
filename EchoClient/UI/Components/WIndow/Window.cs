using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Window : InteractiveControl
{
    private IContentManager _contentManager;
    private WindowTitleBar _windowTitleBar;
    public Texture2D Texture;
    private ScreenTexture[] ScreenTextures {get; set;}
    private bool _mooving;

    public Window(int x, int y, int width, int height, string title, float scale = 1.0f) : base(new Vector2(x, y), width, height, scale)
    {
        _contentManager = ServiceProvider.Current.Get<IContentManager>();
        this.Texture = _contentManager.LoadTexture("Images/window");

        this.LeftMouseDown += ((e, args) => _mooving = true);
        this.LeftMouseUp += ((e, args) => _mooving = false);
        
        Init();
    }

    public void Init()
    {
        int sourceWidth = (int) Math.Round(this.Texture.Width / 3.0f);
        int sourceHeight = (int) Math.Round(this.Texture.Height / 3.0f);
        int destWidth = (int) Math.Round(sourceWidth * this.Scale);
        int destHeight = (int) Math.Round(sourceHeight * this.Scale);

        Vector2 absolutePosition = this.AbsolutePosition;
        int x = (int)Math.Round(absolutePosition.X);
        int y = (int)Math.Round(absolutePosition.Y);

        int middleWidth = this.Width - 2*destWidth;
        int middleHeight = this.Height - 2*destHeight;

        if (middleWidth < 0) middleWidth = 0;
        if (middleHeight < 0) middleHeight = 0;

        Rectangle[,] src = new Rectangle[,] {
            {new Rectangle(0, 0, sourceWidth, sourceHeight), new Rectangle(sourceWidth, 0, sourceWidth, sourceHeight), new Rectangle(sourceWidth*2, 0, sourceWidth, sourceHeight)}, 
            {new Rectangle(0, sourceHeight, sourceWidth, sourceHeight), new Rectangle(sourceWidth, sourceHeight, sourceWidth, sourceHeight), new Rectangle(sourceWidth*2, sourceHeight, sourceWidth, sourceHeight)},
            {new Rectangle(0, sourceHeight*2, sourceWidth, sourceHeight), new Rectangle(sourceWidth, sourceHeight*2, sourceWidth, sourceHeight), new Rectangle(sourceWidth*2, sourceHeight*2, sourceWidth, sourceHeight)}
        };

        Rectangle[,] dst = new Rectangle[,] {
            {new Rectangle(x, y, destWidth, destHeight), new Rectangle(x + destWidth, y, middleWidth, destHeight), new Rectangle(x + destWidth + middleWidth, y, destWidth, destHeight)}, 
            {new Rectangle(x, y + destHeight, destWidth, middleHeight), new Rectangle(x + destWidth, y + destHeight, middleWidth, middleHeight), new Rectangle(x + destWidth + middleWidth, y + destHeight, destWidth, middleHeight)},
            {new Rectangle(x, y + destHeight + middleHeight, destWidth, destHeight), new Rectangle(x + destWidth, y + destHeight + middleHeight, middleWidth, destHeight), new Rectangle(x + destWidth + middleWidth, y + destHeight + middleHeight, destWidth, destHeight)}
        };

        this.ScreenTextures = new ScreenTexture[] {
            new ScreenTexture() {Texture = this.Texture, Destination = dst[0,0], Source = src[0,0]},
            new ScreenTexture() {Texture = this.Texture, Destination = dst[0,1], Source = src[0,1]},
            new ScreenTexture() {Texture = this.Texture, Destination = dst[0,2], Source = src[0,2]},
            new ScreenTexture() {Texture = this.Texture, Destination = dst[1,0], Source = src[1,0]},
            new ScreenTexture() {Texture = this.Texture, Destination = dst[1,1], Source = src[1,1]},
            new ScreenTexture() {Texture = this.Texture, Destination = dst[1,2], Source = src[1,2]},
            new ScreenTexture() {Texture = this.Texture, Destination = dst[2,0], Source = src[2,0]},
            new ScreenTexture() {Texture = this.Texture, Destination = dst[2,1], Source = src[2,1]},
            new ScreenTexture() {Texture = this.Texture, Destination = dst[2,2], Source = src[2,2]},
        };
    }

    public override void Update(KeyboardState keyBoardState, MouseState mouseState, MouseState previousMouseState)
    {
        base.Update(keyBoardState, mouseState, previousMouseState);

        if (_mooving)
        {
            Point diff = mouseState.Position - previousMouseState.Position;
            this.Position += new Vector2(diff.X, diff.Y);
            this.Init();
        }
        
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        for(int i = 0; i < ScreenTextures.Length; i++)
        {
            spriteBatch.DrawScreenTexture(this.ScreenTextures[i]);
        }
    }


}