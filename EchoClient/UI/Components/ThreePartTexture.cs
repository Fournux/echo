
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ThreePartTexture : Control
{
    ///////////////////////////////////////////////////////////
    ///////////////////// PRIVATE FIELDS //////////////////////
    ///////////////////////////////////////////////////////////
    private Texture2D _texture;
    private int _middle;
    private float _scale;
    private Rectangle[] _sourceRectangles;
    private int _sourceWidth;
    private int _sourceHeight;
    public int DestWidth {get; private set;}    
    public int DestHeight {get; private set;}
    private Vector2 _destinationPosition;
    private ScreenTexture[] _screenTextures;

    ///////////////////////////////////////////////////////////
    /////////////////////// PROPERTIES ////////////////////////
    ///////////////////////////////////////////////////////////
    public Texture2D Texture 
    {
        get => this._texture;
        set
        {
            this._texture = value;
            this.ComputeSourceData();
            this.ComputeDestinationData();

        }
    }
    public new float Scale 
    {
        get => this._scale; 
        set
        {
            this._scale = value;
            this.ComputeDestinationData();
        }
    }

    public int Middle 
    {
        get => this._middle; 
        set
        {
            this._middle = value;
            this.ComputeDestinationData();
        }
    }

    ///////////////////////////////////////////////////////////
    ////////////////////// CONSTRUCTORS ///////////////////////
    ///////////////////////////////////////////////////////////
    public ThreePartTexture(Texture2D texture, int middle, float scale) : base(0, 0, scale)
    {
        this._texture = texture;
        this._middle = middle;

        this.ComputeSourceData();
        this.ComputeDestinationData();
    }

    ///////////////////////////////////////////////////////////
    //////////////////////// METHODS //////////////////////////
    ///////////////////////////////////////////////////////////

    private void ComputeSourceData()
    {
        this._sourceWidth = (int) Math.Round(this.Texture.Width / 3.0f);
        this._sourceHeight = this.Texture.Height;

        this._sourceRectangles = new Rectangle[]{
            new Rectangle(0, 0, this._sourceWidth, this._sourceHeight), 
            new Rectangle(this._sourceWidth, 0, this._sourceWidth, this._sourceHeight), 
            new Rectangle(this._sourceWidth*2, 0, this._sourceWidth, this._sourceHeight)
        };
    }

    private void ComputeDestinationData()
    {
        this.DestWidth = (int) Math.Round(this._sourceWidth * this.Scale);
        this.DestHeight = (int) Math.Round(this._sourceHeight * this.Scale);

        Rectangle[] destinationRectangles  = new Rectangle[]{
            new Rectangle((int)this.AbsolutePosition.X, (int)this.AbsolutePosition.Y, this.DestWidth, this.DestHeight),
            new Rectangle((int)this.AbsolutePosition.X + this.DestWidth, (int)this.AbsolutePosition.Y, this.Middle, this.DestHeight),
            new Rectangle((int)this.AbsolutePosition.X + this.DestWidth + this.Middle, (int)this.AbsolutePosition.Y, this.DestWidth, this.DestHeight)
        };

        this.Width = destinationRectangles.Sum(o => o.Width);
        this.Height = destinationRectangles[0].Height;

        this._screenTextures = new ScreenTexture[] {
            new ScreenTexture() {Texture = this.Texture, Destination = destinationRectangles[0], Source = this._sourceRectangles[0]},
            new ScreenTexture() {Texture = this.Texture, Destination = destinationRectangles[1], Source = this._sourceRectangles[1]},
            new ScreenTexture() {Texture = this.Texture, Destination = destinationRectangles[2], Source = this._sourceRectangles[2]}
        };
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        foreach(ScreenTexture screenTexture in this._screenTextures)
        {
            spriteBatch.DrawScreenTexture(screenTexture);
        }
    }
}