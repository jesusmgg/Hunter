using Hunter.Engine.Components.Base;
using Hunter.Engine.Components.Content;
using Hunter.Engine.Components.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace Hunter.Game.Components.Controllers
{
    public class GameController : GameComponent
    {
        public ContentManager contentManager;

        public override void Start()
        {
            name = "GameController";
            
            contentManager = new ContentManager();
            gameObject.AddComponent(contentManager);

            // Asset loading
            contentManager.Load<Texture2D>("sprite_ship", "Sprites/test.png");
            
            // Sprite creation
            SpriteRenderer shipSpriteRenderer = new SpriteRenderer();
            gameObject.AddComponent(shipSpriteRenderer);
            shipSpriteRenderer.texture2D = contentManager.textures["sprite_ship"];
            shipSpriteRenderer.gameObject.game = gameObject.game;
        }
    }
}