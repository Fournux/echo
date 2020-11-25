using Microsoft.Xna.Framework.Graphics;

public interface IContentManager
{
    Texture2D LoadTexture(string name);
    SpriteFont LoadFont(string name, float scale);
}