using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Hunter.Engine.Components.Base;
using Microsoft.Xna.Framework.Graphics;

namespace Hunter.Engine.Components.Content
{
    public class ContentManager : GameComponent
    {
        public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        public ContentManager()
        {
            name = "ContentManager";
        }

        public override void Start()
        {
        }

        public override void Update()
        {
        }

        public void Load<T>(string name, string path)
        {
            if (typeof(T) == typeof(Texture2D))
            {
                if (gameObject?.game?.graphicsDevice?.GraphicsDevice != null)
                {
                    Texture2D texture = gameObject.game.Content.Load<Texture2D>(path);
                    textures.Add(name, texture);
                }
            }
            
            else if (typeof(T) == typeof(SpriteFont))
            {
                if (gameObject?.game?.graphicsDevice?.GraphicsDevice != null)
                {
                    SpriteFont font = gameObject.game.Content.Load<SpriteFont>(path);
                    fonts.Add(name, font);
                }
            }
        }
    }
}
