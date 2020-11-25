using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WindowTitleBar : Control
{
    private Label _title;
    public string Title {
        get { return _title.Text; }
        set 
        {
            _title.Text = value;
        }
    }
    public WindowTitleBar(int x, int y, int width, int height, string title, float scale = 1.0f) : base(new Vector2(x, y), width, height, scale)
    {
        this._title = new Label(0, 0, title, Color.White);
        this._title.Position = new Vector2(20, (height / 2) - (this._title.Height / 2));
    }
    public override void Draw(SpriteBatch spritebatch)
    {
        throw new NotImplementedException();
    }
}