using HarmonyLib;
using Il2Cpp;

namespace CaputillaMelonLoader.Patches
{
    [HarmonyPatch(typeof(QueueSelect), "OnTriggerEnter")]
    internal class QueueSelect_OnTriggerEnter_Patch
    {
        private static void Postfix(QueueSelect __instance)
        {
            QueueSelect queueSelect = MainMod.ModdedButton.GetComponent<QueueSelect>();
            queueSelect.button.material = FusionHub.selectedQueue.ToLower().Contains("modded") ? queueSelect.redMat : queueSelect.defaultMat;
        }
    }
}