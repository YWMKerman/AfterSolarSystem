using System;
using System.IO;
using UnityEngine;
using KSP.Localization;

namespace AfterSolarSystem
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class ASSInstallationCheck : MonoBehaviour
    {
        public void Start()
        {
            try
            {
                ASS_InstallCheck();
            }
            catch (Exception ex)
            {
                Debug.Log("[AfterSolarSystem] ASSInstallationCheck.Start() caught an exception: " + ex);
            }
            finally
            {
                Destroy(this);
            }
        }

        private void ASS_InstallCheck()
        {
            CheckTextures();
            CheckPrincipia();
        }

        private void CheckTextures()
        {
            string szTextureFolderPath = $"{KSPUtil.ApplicationRootPath}GameData{Path.AltDirectorySeparatorChar}AfterSolarSystem-Textures";

            // Localized messages
            string szUserMessage = Localizer.Format("#InstallationChecker_MissingTextures");
            string title = Localizer.Format("#InstallationChecker_Title");
            string buttonText = Localizer.Format("#InstallationChecker_Download");

            if (!Directory.Exists(szTextureFolderPath))
            {
                Debug.Log("[AfterSolarSystem] No texture pack detected!");

                PopupDialog.SpawnPopupDialog
                (
                    new Vector2(0.0f, 0.0f),
                    new Vector2(0.0f, 0.0f),
                    new MultiOptionDialog
                    (
                        "ASS_InstallCheck",
                        szUserMessage,
                        title,
                        HighLogic.UISkin,
                        new Rect(0.25f, 0.75f, 320f, 80f),
                        new DialogGUIFlexibleSpace(),
                        new DialogGUIButton
                        (
                            buttonText,
                            delegate
                            {
                                OpenASSTexturesDownloadPage();
                            },
                            140.0f,
                            30.0f,
                            true
                        )
                    ),
                    false,
                    HighLogic.UISkin,
                    true,
                    string.Empty
                );
            }
        }

        private void CheckPrincipia()
        {
            string principiaFolderPath = $"{KSPUtil.ApplicationRootPath}GameData{Path.AltDirectorySeparatorChar}Principia";
            string principiaFilePath = $"{principiaFolderPath}{Path.AltDirectorySeparatorChar}real_solar_system{Path.AltDirectorySeparatorChar}initial_state_jd_2433282_500000000.cfg";

            if (Directory.Exists(principiaFolderPath) && File.Exists(principiaFilePath))
            {
                Debug.Log("[AfterSolarSystem] Conflicting Principia file detected!");

                // Localized messages
                string warningMessage = Localizer.Format("#InstallationChecker_PrincipiaConflict");
                string title = Localizer.Format("#InstallationChecker_Title");
                string buttonText = Localizer.Format("#InstallationChecker_Close");

                PopupDialog.SpawnPopupDialog
                (
                    new Vector2(0.0f, 0.0f),
                    new Vector2(0.0f, 0.0f),
                    new MultiOptionDialog
                    (
                        "ASS_PrincipiaCheck",
                        warningMessage,
                        title,
                        HighLogic.UISkin,
                        new Rect(0.25f, 0.75f, 320f, 80f),
                        new DialogGUIFlexibleSpace(),
                        new DialogGUIButton
                        (
                            buttonText,
                            delegate
                            {
                                Debug.Log("[AfterSolarSystem] User acknowledged the Principia warning.");
                            },
                            140.0f,
                            30.0f,
                            true
                        )
                    ),
                    false,
                    HighLogic.UISkin,
                    true,
                    string.Empty
                );
            }
        }

        private void OpenASSTexturesDownloadPage()
        {
            Application.OpenURL("https://github.com/YWMKerman/AfterSolarSystem/releases");
        }
    }
}
