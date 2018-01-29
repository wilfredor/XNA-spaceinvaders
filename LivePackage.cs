namespace SpaceInvaders
{
    public class LivePackage : Package
    {
        public LivePackage(SpaceInvaders game1, int originX, int originY) : base(game1, originX, originY)
        {
            Texture = "live";
        }

        public override void ApplyRule()
        {
            game.nave.lives++;
        }
    }
}
