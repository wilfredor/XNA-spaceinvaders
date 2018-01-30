namespace SpaceInvaders
{
    public class BulletPackage : Package
    {
        public BulletPackage(SpaceInvaders game, int originX, int originY) : base(game,  originX,  originY)
        {
            TextureName = "bulletpackage";
        }

        public override void ApplyRule()
        {
            Game.nave.numShotsFromCurrentMagazine = 100;
        }
    }
}