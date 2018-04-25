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
        public float deltaTime = 0.0f;

        public override void Start()
        {
            name = "GameController";
            
            gameTime = new GameTime();
            
            contentManager = new ContentManager();
            gameObject.AddComponent(contentManager);

            // Asset loading
            contentManager.Load<Texture2D>("sprite_ship", "Sprites/test.png");
            contentManager.Load<Texture2D>("creature_1", "Sprites/Creatures/creature_1.png");
            
            // Game objects creation
            GameObject creature = new GameObject();
            gameObject.AddChild(creature);
            creature.AddComponent(new Creature {gameController = this});
        }

        public override void Update()
        {
            GameObject parent = (GameObject) gameObject.parent;
            gameTime = parent.gameTime;
            deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}