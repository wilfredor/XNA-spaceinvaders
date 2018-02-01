using System.Runtime.InteropServices;

namespace SpaceInvaders
{
    [ComVisibleAttribute(false)]
    public class LivePackage : Package
    {
        public LivePackage(SpaceInvaders game) : base(game)
        {
            TextureName = "live";
        }

        public override void ApplyRule()
        {
            GameInfo.Lives++;
        }
    }
}
