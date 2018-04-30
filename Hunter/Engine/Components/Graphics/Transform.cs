using Microsoft.Xna.Framework;

namespace Hunter.Engine.Components.Graphics
{
    public class Transform : Base.GameComponent
    {
        public Vector2 position;
        public Vector2 rotation;
        public Vector2 scale;

        public Rectangle rectangle;

        public Transform()
        {
            name = "Transform";
        }

        public override void Start()
        {
            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            // ReSharper disable HeuristicUnreachableCode
            
            if (position == null)
            {
                position = new Vector2();
            }
            
            if (rotation == null)
            {
                rotation = new Vector2();
            }

            if (scale == null)
            {
                scale = new Vector2();
            }
            
            // ReSharper restore HeuristicUnreachableCode
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
        }
    }
}
