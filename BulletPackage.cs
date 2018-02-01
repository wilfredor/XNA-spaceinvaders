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
            GameInfo.numShotsFromCurrentMagazine = Constant.DefaultPackageQuantity;
        }
    }
}