using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Image : Control
{
    private IContentManager _contentManager;
    private Texture2D _texture;
    public Rectangle Destination;
    public Rectangle Source;
    public Color Color {get; set;} = Color.White;
    public Image(int x, int y, string file, float scale = 1.0f) : base(x, y, scale)
    {
        this._contentManager = ServiceProvider.Current.Get<IContentManager>();
        this._texture = _contentManager.LoadTexture(file);
        this.Source = new Rectangle(0, 0, this._texture.Width, this._texture.Height);
        this.Destination = new Rectangle(x, y, (int) Math.Round(this.Source.Width * scale), (int) Math.Round(this.Source.Height * scale));
    }

    public Image(Rectangle source, Rectangle destination, string file) : base(new Vector2(destination.X, destination.Y), destination.Width, destination.Height)
    {
        
    }

    public override void Draw(SpriteBatch spritebatch)
    {
        spritebatch.Draw(this._texture, this.Destination, this.Source, this.Color);
    }
}