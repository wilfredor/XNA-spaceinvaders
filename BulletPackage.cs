namespace SpaceInvaders
{
    public class BulletPackage : Package
    {
        public BulletPackage(SpaceInvaders game) : base(game)
        {
            TextureName = "bulletpackage";
        }

        public override void ApplyRule()
        {
            Game.nave.numShotsFromCurrentMagazine = 100;
        }
    }
}