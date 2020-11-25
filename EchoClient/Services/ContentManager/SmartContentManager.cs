using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class SmartContentManager : IContentManager
{
    private IDictionary<string, object> Resources = new Dictionary<string, object>();
    private ContentManager ContentManager {get; set;}
    private const int FONT_SIZE_BASE = 16;
    public SmartContentManager(ContentManager contentManager)
    {
        ContentManager = contentManager;
    }
    public T Load<T>(string name)
    {
        if (!Resources.ContainsKey(name)) 
        {
            Resources[name] = ContentManager.Load<T>(name);
        }
        return (T) Resources[name];
    }

    public Texture2D LoadTexture(string name)
    {
        return Load<Texture2D>(name);
    }

    public SpriteFont LoadFont(string name, float scale)
    {  
        int fontSize = ((int) Math.Round(scale*FONT_SIZE_BASE) >> 1) << 1;
        if (fontSize < 10) fontSize = 10;
        else if (fontSize > 34) fontSize = 34;

        return Load<SpriteFont>(name + "_" + fontSize);
    }
}