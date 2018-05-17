using GameComponent = Hunter.Engine.Components.Base.GameComponent;

namespace Hunter.Game.Components.Common
{
    public class Stats : GameComponent
    {
        public int hitPoints = 10;
        public int damage = 1;

        public int village = 1;
        
        public Stats()
        {
            name = "Stats";
        }
        
        public override void Start()
        {
        }

        public override void Update()
        {
        }
    }
}