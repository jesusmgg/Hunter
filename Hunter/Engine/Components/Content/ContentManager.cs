using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Hunter.Engine.Components.Base;
using Microsoft.Xna.Framework.Graphics;

namespace Hunter.Engine.Components.Content
{
    public class ContentManager : GameComponent
    {
        readonly string assetsBasePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Assets/";
        
        public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        public override void Start()
        {
        }

        public override void Update()
        {
        }

        public void Load<T>(string name, string path)
        {
            FileStream fileStream = new FileStream(assetsBasePath + path, FileMode.Open);
                
            if (typeof(T) == typeof(Texture2D))
            {
                if (gameObject?.game?.graphicsDevice?.GraphicsDevice != null)
                {
                    Texture2D texture = Texture2D.FromStream(entity.game.graphicsDevice.GraphicsDevice, fileStream);
                    textures.Add(name, texture);
                }
            }
            
            else if (typeof(T) == typeof(SpriteFont))
            {
                if (gameObject?.game?.graphicsDevice?.GraphicsDevice != null)
                {
                    SpriteFont font = new SpriteFont();//.FromStream(entity.game.graphicsDevice.GraphicsDevice, fileStream);
                    textures.Add(name, texture);
                }
            }
            
            fileStream.Dispose();
        }
    }
}
