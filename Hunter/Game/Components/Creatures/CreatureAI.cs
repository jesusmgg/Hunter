using System;
using System.Collections.Concurrent;
using Hunter.Engine.Components.Content;
using Hunter.Engine.Components.Graphics;
using Hunter.Game.Components.Controllers;
using Microsoft.Xna.Framework;
using GameComponent = Hunter.Engine.Components.Base.GameComponent;

namespace Hunter.Game.Components.Creatures
{
    public class CreatureAI : GameComponent
    {
        Vector2 currentStartingPosition;
        Vector2 currentDestination;

        float speed = 50.0f;
        
        float destinationTolerance = 0.05f;
        
        public CreatureAI()
        {
            name = "CreatureAI";
        }
        
        public override void Start()
        {
            currentStartingPosition = transform.position;
            currentDestination = GetRandomDestination();
        }

        public override void Update()
        {
            float deltaTime = gameController.deltaTime;

            float progress = ((currentStartingPosition - transform.position).Length() + speed * deltaTime)
                             / (currentDestination - currentStartingPosition).Length();
            
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