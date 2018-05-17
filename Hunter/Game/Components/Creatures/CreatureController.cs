using System;
using System.Collections.Concurrent;
using Hunter.Engine.Components.Content;
using Hunter.Engine.Components.Graphics;
using Hunter.Game.Components.Common;
using Hunter.Game.Components.Controllers;
using Microsoft.Xna.Framework;
using GameComponent = Hunter.Engine.Components.Base.GameComponent;

namespace Hunter.Game.Components.Creatures
{
    public class CreatureController : GameComponent
    {
        public GameController gameController;

        private Transform transform;
        private SpriteRenderer spriteRenderer;
        private CreatureAI creatureAI;
        private Stats stats;

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
            transform = new Transform();
            gameObject.AddComponent(transform);
            
            spriteRenderer = new SpriteRenderer();            
            gameObject.AddComponent(spriteRenderer);

            stats = new Stats
            {
                hitPoints = 10,
                damage = 1
            };
            gameObject.AddComponent(stats);
            
            creatureAI = new CreatureAI();
            gameObject.AddComponent(creatureAI);
            
            transform.position = new Vector2(100.0f, 100.0f);
            
            currentStartingPosition = transform.position;
            currentDestination = creatureAI.GetRandomDestination();
        }

        public override void LoadContent()
        {
            spriteRenderer.texture2D = gameController.contentManager.textures["creature_1"];
        }

        public override void Update()
        {
            float deltaTime = gameController.deltaTime;

            float progress = ((currentStartingPosition - transform.position).Length() + speed * deltaTime) / (currentDestination - currentStartingPosition).Length();
            
            transform.position.X = MathHelper.Lerp(currentStartingPosition.X, currentDestination.X, progress);
            transform.position.Y = MathHelper.Lerp(currentStartingPosition.Y, currentDestination.Y, progress);

            if (progress >= 1.0f - destinationTolerance)
            {
                currentDestination = creatureAI.GetRandomDestination();
                currentStartingPosition = transform.position;
            }
        }
    }
}