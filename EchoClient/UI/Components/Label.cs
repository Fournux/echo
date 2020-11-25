using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Label : Control
{
    private IContentManager _contentManager;
    private SpriteFont Font {get; set;}
    public Color Color {get; set;} = Color.Black;
    private string _text;
    public string Text {
        get { return this._text; }
        set 
        {
            this._text = value;
            Vector2 size = Font.MeasureString(this._text);
            this.Width = (int) Math.Round(size.X);
            this.Height = (int) Math.Round(size.Y);
        }
    }
    public Label(int x, int y, string text, Color color, float scale = 1.0f) : base(x, y, scale)
    {
        this._contentManager = ServiceProvider.Current.Get<IContentManager>();
        this.Font = _contentManager.LoadFont("Fonts/FreeSans", this.Scale);
        this.Text = text;
    }

    public Label(string text, Color color, float scale = 1.0f) : this(0, 0, text, color, scale) {}

    public override void Draw(SpriteBatch spritebatch)
    {
        spritebatch.DrawString(this.Font, this.Text, this.AbsolutePosition, this.Color);
    }
}