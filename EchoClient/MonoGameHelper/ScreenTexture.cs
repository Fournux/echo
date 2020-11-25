
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ScreenTexture
{
    public Texture2D Texture {get; set;}
    public Rectangle Source {get; set;}
    public Rectangle Destination {get; set;}
    public Color Color {get; set;} = Color.White;
}