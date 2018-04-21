namespace Hunter.ECS
{
    public abstract class Component
    {
        public string name;
        
        public bool enabled;
        public bool started;
        
        public Entity entity;

        protected Component()
        {
            enabled = true;
            started = false;
        }

        public virtual void Start()
        {
        }
        
        public virtual void Update()
        {
        }
        
        public virtual void Draw()
        {
        }
    }
}
