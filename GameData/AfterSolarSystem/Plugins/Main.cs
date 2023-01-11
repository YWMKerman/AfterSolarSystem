using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DependencyChecker
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Main : MonoBehaviour
    {
        public void Start()
        {
            try
            {
                Debug.Log("[DependencyChecker]: DependencyChecker.Main.Start()");
                Dictionary<string, string> dependencies = new Dictionary<string, string>()
                {
                    ["Scatterer"] = "https://spacedock.info/mod/141/Scatterer",
                    ["KSPCommunityFixes"] = "https://github.com/KSPModdingLibs/KSPCommunityFixes/releases"
                };
                List<string> missingDependencies = new List<string>();
                foreach (var dependency in dependencies)
                {
                    if (!Directory.Exists("GameData" + Path.DirectorySeparatorChar + dependency.Key))
                    {
                        Debug.Log("[DependencyChecker]: Missing mod dependency: " + dependency.Key);
                        missingDependencies.Add(dependency.Key);
                    }
                }
                if (missingDependencies.Count > 0)
                {
                    Debug.Log("[DependencyChecker]: Missing mod dependencies detected, spawning popup dialog");
                    List<DialogGUIBase> components = new List<DialogGUIBase>();
                    foreach (var missingDependency in missingDependencies)
                    {
                        components.Add(new DialogGUIButton("Download " + missingDependency, () =>
                        {
                            Application.OpenURL(dependencies[missingDependency]);
                        }, 140f, 30f, false));
                    }
                    if (missingDependencies.Count > 1)
                    {
                        components.Add(new DialogGUIButton("Download All", () =>
                        {
                            foreach (var missingDependency in missingDependencies) { Application.OpenURL(dependencies[missingDependency]); }
                        }, 140f, 30f, false));
                    }
                    components.Add(new DialogGUIButton("Close", null, 140f, 30f, true));
                    PopupDialog.SpawnPopupDialog(
                        Vector2.zero, Vector2.zero,
                        new MultiOptionDialog(
                            "DependencyChecker",
                            "We found that these mods are missing from your installation: \n\n" + string.Join("\n", missingDependencies.ToArray()) + "\n\nThis may cause abnormalities in your game or affect the visual effect, we recommend you to install these mods.",
                            "DependencyChecker",
                            HighLogic.UISkin,
                            components.ToArray()
                        ),
                        false, HighLogic.UISkin, true, string.Empty
                    );
                }
            }
            catch (Exception e)
            {
                Debug.Log("[DependencyChecker]: " + e);
            }
            finally
            {
                Debug.Log("[DependencyChecker]: Exiting");
                Destroy(this);
            }
        }
    }
}
