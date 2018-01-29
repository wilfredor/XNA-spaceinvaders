namespace SpaceInvaders
{
    public class BulletPackage : Package
    {
        public BulletPackage(SpaceInvaders game1, int originX, int originY) : base(game1,  originX,  originY)
        {
            Texture = "bulletpackage";
        }

        public override void ApplyRule()
        {
            game.nave.numShotsFromCurrentMagazine = 100;
        }
    }
}

