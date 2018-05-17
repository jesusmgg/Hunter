using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        private readonly Dictionary<string, int> states = new Dictionary<string, int>
        {
            {"idle", 501},
            {"collecting_straw", 502},
            {"collecting_food", 503},
            {"alert", 504},
            {"fighting", 505},
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

            state = states["idle"];
        }

        public override void Update()
        {
            if (state == states["idle"])
            {
                
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