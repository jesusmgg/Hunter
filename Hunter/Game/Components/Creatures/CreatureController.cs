using System;
using Hunter.Engine.Components.Content;
using Hunter.Engine.Components.Graphics;
using Hunter.Game.Components.Controllers;
using Microsoft.Xna.Framework;
using GameComponent = Hunter.Engine.Components.Base.GameComponent;

namespace Hunter.Game.Components.Creatures
{
    public class CreatureController : GameComponent
    {
        public GameController gameController;

        Transform transform;
        SpriteRenderer spriteRenderer;

        float speed = 200.0f;
        
        public CreatureController()
        {
            name = "CreatureController";
        }
        
        public override void Start()
        {
            // Sprite creation
            transform = new Transform();
            spriteRenderer = new SpriteRenderer();            
            
            gameObject.AddComponent(transform);
            gameObject.AddComponent(spriteRenderer);
            
            transform.position = new Vector2(100.0f, 100.0f);
        }

        public override void LoadContent()
        {
            ContentManager contentManager = gameController.gameObject.GetComponent<ContentManager>();
            
            spriteRenderer.texture2D = contentManager.textures["creature_1"];
        }

        public override void Update()
        {
            //Console.WriteLine(transform.position.X);
            
            float deltaTime = gameController.deltaTime;
            
            transform.position = transform.position + new Vector2(speed * deltaTime, 0.0f);
        }

        Vector2 GetRandomDestination()
        {
            Vector2 destination = new Vector2();

            float minX = 50.0f;
            float maxX = 500.0f;
            float minY = 50.0f;
            float maxY = 300.0f;
            
            Random random = new Random();
            
            float randomNumber = (float) random.NextDouble();
            float x = MathHelper.Lerp(-minX, +maxX, randomNumber);
            
            randomNumber = (float) random.NextDouble();
            float y = MathHelper.Lerp(-minY, +maxY, randomNumber);

            return destination;
        }
    }
}