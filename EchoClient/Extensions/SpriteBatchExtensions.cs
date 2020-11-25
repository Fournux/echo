using System;
using Microsoft.Xna.Framework.Graphics;

public static class SpriteBatchExtensions
{
    public static void DrawScreenTexture(this SpriteBatch spriteBatch, ScreenTexture screenTexture)
    {
        spriteBatch.Draw(screenTexture.Texture, screenTexture.Destination, screenTexture.Source, screenTexture.Color);
        
    }
}