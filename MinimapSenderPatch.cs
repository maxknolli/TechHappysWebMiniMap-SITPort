using System.Reflection;
using SIT.Tarkov.Core;
using SIT.Core.Coop;
using Comfort.Common;
using EFT;

namespace TechHappy.MinimapSender
{
    public class MinimapSenderPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(CoopGame).GetMethod("vmethod_2", BindingFlags.Public | BindingFlags.Instance);
        }

        [PatchPostfix]
        public static void PatchPostFix()
        {
            GameWorld gameWorld = Singleton<GameWorld>.Instance;

            if (gameWorld == null)
            {
                return;
            }

            MinimapSenderPlugin.raidCounter++;
            MinimapSenderPlugin.airdrops.Clear();

            gameWorld.gameObject.AddComponent<MinimapSenderController>();
        }
    }
}