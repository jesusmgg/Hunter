using System.Collections.Generic;
using System.Linq;
using Hunter.Game.Components.Controllers;
using Microsoft.Xna.Framework;
using GameComponent = Hunter.Engine.Components.Base.GameComponent;

namespace Hunter.Engine.Components.Graphics
{
    public class FrameCounter : GameComponent
    {
        public GameController gameController;

        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }

        public const int MaximumSamples = 100;

        private Queue<float> _sampleBuffer = new Queue<float>();
        
        public FrameCounter()
        {
            name = "FrameCounter";
        }

        public override void Update()
        {
            if (gameController != null)
            {
                CurrentFramesPerSecond = 1.0f / gameController.deltaTime;
    
                _sampleBuffer.Enqueue(CurrentFramesPerSecond);
    
                if (_sampleBuffer.Count > MaximumSamples)
                {
                    _sampleBuffer.Dequeue();
                    AverageFramesPerSecond = _sampleBuffer.Average(i => i);
                } 
                else
                {
                    AverageFramesPerSecond = CurrentFramesPerSecond;
                }
    
                TotalFrames++;
                TotalSeconds += gameController.deltaTime;
            }
        }
        
        public override void Draw()
        {
            if (gameController != null)
            {
                var fps = string.Format("FPS: {0}", AverageFramesPerSecond);

                gameObject?.game?.spriteBatch?.DrawString(gameController.contentManager.fonts["Arial"], fps, new Vector2(1, 1), Color.Black);

                // other draw code here
            }
        }
    }
}