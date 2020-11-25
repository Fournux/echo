using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

interface IGameComponent
{
    void Update(KeyboardState keyBoardState, MouseState mouseState, MouseState previousMouseState);
    void Draw(SpriteBatch spriteBatch);
}