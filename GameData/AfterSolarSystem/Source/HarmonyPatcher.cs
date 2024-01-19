


// 这个配置文件来源于RSS



using UnityEngine;

namespace AfterSolarSystem
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class HarmonyPatcher : MonoBehaviour
    {
        internal void Start()
        {
            var harmony = new HarmonyLib.Harmony("RSS.HarmonyPatcher");
            harmony.PatchAll();
        }
    }
}
