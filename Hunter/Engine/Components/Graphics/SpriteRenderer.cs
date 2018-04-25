using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hunter.Engine.Components.Graphics
{
    public class SpriteRenderer: Base.GameComponent
    {
        public Texture2D texture2D;
        public Rectangle rectangle;

        public override void Start()
        {
            if (texture2D != null)
            {
                rectangle = texture2D.Bounds;
            }
            else
            {
                rectangle = new Rectangle();
            }
            
            UpdateRectangleWithTransform();
        }

        public override void Update()
        {
            UpdateRectangleWithTransform();
        }

        public override void Draw()
        {
            gameObject.game?.spriteBatch?.Draw(texture2D, rectangle, new Color(Color.White.ToVector4()));
        }

        void UpdateRectangleWithTransform()
        {
            Transform transform = gameObject.GetComponent<Transform>();
            if (transform != null)
            {
                rectangle.X = (int) transform.position.X;
                rectangle.Y = (int) transform.position.Y;
            }
        }
    }
}