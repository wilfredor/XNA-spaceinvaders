namespace SpaceInvaders
{
    public class LivePackage : Package
    {
        public LivePackage(SpaceInvaders game, int originX, int originY) : base(game, originX, originY)
        {
            TextureName = "live";
        }

        public override void ApplyRule()
        {
            Game.nave.lives++;
        }
    }
}
