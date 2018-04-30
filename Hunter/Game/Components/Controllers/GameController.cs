using Hunter.Engine.Components.Content;
using Hunter.Engine.Components.Graphics;
using Hunter.Engine.Entities.Base;
using Hunter.Game.Components.Creatures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameComponent = Hunter.Engine.Components.Base.GameComponent;

namespace Hunter.Game.Components.Controllers
{
    public class GameController : GameComponent
    {
        public ContentManager contentManager;
        
        public GameTime gameTime;
        public float deltaTime;

        public GameController()
        {
            name = "GameController";
        }

        public override void Start()
        {
            gameTime = new GameTime();
            
            // Game objects creation
            GameObject creature = new GameObject();
            creature.name = "Creature1";
            gameObject.AddChild(creature);
            creature.AddComponent(new CreatureController {gameController = this});
        }

        public override void LoadContent()
        {
            contentManager = new ContentManager();
            contentManager.name = "ContentManager";
            gameObject.AddComponent(contentManager);
            
            // Sprites
            contentManager.Load<Texture2D>("sprite_ship", "Sprites/test");
            contentManager.Load<Texture2D>("creature_1", "Sprites/Creatures/creature_1");
            
            // Fonts
            contentManager.Load<SpriteFont>("Arial", "Fonts/Arial");
        }

        public override void Update()
        {
            GameObject parent = (GameObject) gameObject.parent;
            gameTime = parent.gameTime;
            deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}