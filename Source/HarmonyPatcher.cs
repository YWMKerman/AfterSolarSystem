using UnityEngine;

namespace AfterSolarSystem
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class HarmonyPatcher : MonoBehaviour
    {
        internal void Start()
        {
            var harmony = new HarmonyLib.Harmony("ASS.HarmonyPatcher");
            harmony.PatchAll();
        }
    }
}
