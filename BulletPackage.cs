using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class BulletPackage : Package
    {
        public BulletPackage(SpaceInvaders game) : base(game)
        {
            TextureName = "bulletpackage";
        }

        public override void ApplyRule()
        {
            GameN.nave.numShotsFromCurrentMagazine = 100;
        }
    }
}