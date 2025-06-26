using HarmonyLib;
using Il2Cpp;
using Il2CppFusion;

namespace CaputillaMelonLoader.Patches
{
    [HarmonyPatch(typeof(FusionHub), "OnPlayerJoined")]
    internal class FusionHub_OnPlayerJoined_Patch
    {
        public static void Postfix(FusionHub __instance, PlayerRef player)
        {
            if (FusionHub.Runner.LocalPlayer == player)
            {
                if (FusionHub.currentQueue.ToLower().Contains("modded"))
                    CaputillaHub.Instance.InvokeOnModdedJoin();
            }
        }
    }
    
    [HarmonyPatch(typeof(FusionHub), "Leave")]
    internal class FusionHub_Leave_Patch
    {
        public static void Postfix(FusionHub __instance)
        {
            if (CaputillaHub.InModdedRoom)
                CaputillaHub.Instance.InvokeOnModdedLeave();
        }
    }
}