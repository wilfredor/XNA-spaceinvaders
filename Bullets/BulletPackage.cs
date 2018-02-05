using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class BulletPackage : Package
    {
        public BulletPackage(SpaceInvaders game) : base(game)
        {
            TextureName = Constant.BulletsPath + "bulletpackage";
        }

        public override void ApplyRule()
        {
            GameInfo.Shots = Constant.DefaultPackageQuantity;
        }
    }
}