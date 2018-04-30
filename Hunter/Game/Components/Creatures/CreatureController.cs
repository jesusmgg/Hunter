using System;
using System.Collections.Concurrent;
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

        float destinationTolerance = 0.05f;

        Vector2 currentStartingPosition;
        Vector2 currentDestination;

        float speed = 50.0f;
        
        public CreatureController()
        {
            name = "CreatureController";
        }
        
        public override void Start()
        {
            // Sprite creation
            transform = new Transform();
            gameObject.AddComponent(transform);
            
            spriteRenderer = new SpriteRenderer();            
            gameObject.AddComponent(spriteRenderer);
            
            transform.position = new Vector2(100.0f, 100.0f);
            
            currentStartingPosition = transform.position;
            currentDestination = GetRandomDestination();
        }

        public override void LoadContent()
        {
            ContentManager contentManager = gameController.gameObject.GetComponent<ContentManager>();
            
            spriteRenderer.texture2D = contentManager.textures["creature_1"];
        }

        public override void Update()
        {
            float deltaTime = gameController.deltaTime;

            float progress = ((currentStartingPosition - transform.position).Length() + speed * deltaTime) / (currentDestination - currentStartingPosition).Length();
            
            transform.position.X = MathHelper.Lerp(currentStartingPosition.X, currentDestination.X, progress);
            transform.position.Y = MathHelper.Lerp(currentStartingPosition.Y, currentDestination.Y, progress);

            if (progress >= 1.0f - destinationTolerance)
            {
                currentDestination = GetRandomDestination();
                currentStartingPosition = transform.position;
            }
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
            destination.X = MathHelper.Lerp(minX, maxX, randomNumber);
            
            randomNumber = (float) random.NextDouble();
            destination.Y = MathHelper.Lerp(minY, maxY, randomNumber);

            return destination;
        }
    }
}