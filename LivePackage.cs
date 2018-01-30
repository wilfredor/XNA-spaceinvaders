namespace SpaceInvaders
{
    public class LivePackage : Package
    {
        public LivePackage(SpaceInvaders game) : base(game)
        {
            TextureName = "live";
        }

        public override void ApplyRule()
        {
            Game.Lives++;
        }
    }
}
