

 // 这个配置文件来源于RSS

using CommNet;
using System;
using UnityEngine;

namespace AfterSolarSystem
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, true)]
    public class ASSCommNetSettings : MonoBehaviour
    {
        public void Start()
        {
            try
            {
                bool enableExtraGroundStations = true;
                bool overrideCommNetParams = true;

                float occlusionMultiplierInAtm = 1.0f;
                float occlusionMultiplierInVac = 1.0f;

                Debug.Log("[AfterSolarSystem] Checking for custom CommNet settings...");

                foreach (ConfigNode ASSSettings in GameDatabase.Instance.GetConfigNodes("AfterSolarSystem"))
                {
                    ASSSettings.TryGetValue("overrideCommNetParams", ref overrideCommNetParams);
                    ASSSettings.TryGetValue("enableGroundStations", ref enableExtraGroundStations);
                    ASSSettings.TryGetValue("occlusionMultiplierAtm", ref occlusionMultiplierInAtm);
                    ASSSettings.TryGetValue("occlusionMultiplierVac", ref occlusionMultiplierInVac);
                }

                if (overrideCommNetParams)
                {
                    //  Set the default CommNet parameters for AfterSolarSystem.

                    Debug.Log("[AfterSolarSystem] Updating the CommNet settings...");

                    HighLogic.CurrentGame.Parameters.CustomParams<CommNetParams>().enableGroundStations = enableExtraGroundStations;
                    HighLogic.CurrentGame.Parameters.CustomParams<CommNetParams>().occlusionMultiplierAtm = occlusionMultiplierInAtm;
                    HighLogic.CurrentGame.Parameters.CustomParams<CommNetParams>().occlusionMultiplierVac = occlusionMultiplierInVac;
                }
            }
            catch (Exception exceptionStack)
            {
                Debug.Log("[AfterSolarSystem] ASSCommNetSettings.Start() caught an exception: " + exceptionStack);
            }
            finally
            {
                Destroy(this);
            }
        }
    }
}
