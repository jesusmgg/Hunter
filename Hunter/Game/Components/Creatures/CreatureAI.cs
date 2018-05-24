using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Hunter.Engine.Components.Content;
using Hunter.Engine.Components.Graphics;
using Hunter.Game.Components.Controllers;
using Microsoft.Xna.Framework;
using GameComponent = Hunter.Engine.Components.Base.GameComponent;

namespace Hunter.Game.Components.Creatures
{
    public class CreatureAI : GameComponent
    {
        private GameController gameController;

        private Random random;
        
        Vector2 currentStartingPosition;
        Vector2 currentDestination;
        
        float minX = 50.0f;
        float maxX = 500.0f;    
        float minY = 50.0f;
        float maxY = 300.0f;

        float speed = 50.0f;
        
        float destinationTolerance = 0.05f;

        private enum States
        {
            Idle,
            CollectingStraw,
            CollectingFood,
            Alerted,
            Fighting,
        };
        
        public int state;
        
        public CreatureAI()
        {
            name = "CreatureAI";
        }
        
        public override void Start()
        {
            random = new Random();   
            
            currentDestination = GetRandomDestination();

            gameController = gameObject.GetComponent<GameController>();

            state = (int) States.Idle;
        }

        public override void Update()
        {
            switch (state)
            {
                case (int) States.Idle:
                {
                    break;
                }
                
                case (int) States.CollectingStraw:
                {
                    break;
                }
                
                case (int) States.CollectingFood:
                {
                    break;
                }
                
                case (int) States.Alerted:
                {
                    break;
                }
                
                case (int) States.Fighting:
                {
                    break;
                }

                default:
                {
                    Console.WriteLine(name + ": entered non-existent state.");
                    break;
                }
            }
        }

        public Vector2 GetRandomDestination()
        {
            Vector2 destination = new Vector2();
            
            float randomNumber = (float) random.NextDouble();
            destination.X = MathHelper.Lerp(minX, maxX, randomNumber);
            
            randomNumber = (float) random.NextDouble();
            destination.Y = MathHelper.Lerp(minY, maxY, randomNumber);

            return destination;
        }
    }
}