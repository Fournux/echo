using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
public class Button : Control
{
    private IContentManager _contentManager;
    private Texture2D _texture;
    private Label _label;
    private ThreePartTexture _threePartTexture;
    public string Text 
    {
        get 
        {
            return _label.Text;
        }
        set
        {
            this._label.Text = value;
        }
    }

    public Button(int x, int y, string text, float scale = 1.0f) : base(x, y, scale)
    {
        _contentManager = ServiceProvider.Current.Get<IContentManager>();
        this._texture = _contentManager.LoadTexture("Images/button");

        this._label = new Label(text, Color.Black, scale);
        this._threePartTexture = new ThreePartTexture(this._texture, this._label.Width, scale);

        this.Width = this._threePartTexture.Width;
        this.Height = this._threePartTexture.Height;

        this._label.Position = new Vector2(this._threePartTexture.DestWidth, this._threePartTexture.Height/2 - this._label.Height/2);
        
        this.Add(this._threePartTexture);
        this.Add(this._label);
    }

    private void UpdateTextureColor(Color color)
    {

    }

}


