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
            position = new Vector2();
            rotation = new Vector2();
            scale = new Vector2();
        }
    }
}
