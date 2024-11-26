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

            string szUserMessage = Localizer.Format("#InstallationChecker_MissingTextures");
            string title = Localizer.Format("#InstallationChecker_Title");
            string buttonText = Localizer.Format("#InstallationChecker_DownloadAndExit");

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
                                QuitGame();
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

                string warningMessage = Localizer.Format("#InstallationChecker_PrincipiaConflict");
                string title = Localizer.Format("#InstallationChecker_Title");
                string openAndExitButtonText = Localizer.Format("#InstallationChecker_OpenAndExit");
                string closeButtonText = Localizer.Format("#InstallationChecker_Close");

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
                            openAndExitButtonText,
                            delegate
                            {
                                OpenPrincipiaFolder(principiaFilePath);
                                QuitGame();
                            },
                            140.0f,
                            30.0f,
                            true
                        ),
                        new DialogGUIButton
                        (
                            closeButtonText,
                            delegate
                            {
                                Debug.Log("[AfterSolarSystem] User closed the Principia warning dialog.");
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

        private void OpenPrincipiaFolder(string filePath)
        {
            try
            {
                string folderPath = Path.GetDirectoryName(filePath);
                if (Directory.Exists(folderPath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = folderPath,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
                else
                {
                    Debug.LogWarning("[AfterSolarSystem] The specified folder does not exist: " + folderPath);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("[AfterSolarSystem] Failed to open folder: " + ex);
            }
        }

        private void QuitGame()
        {
            Debug.Log("[AfterSolarSystem] Quitting the game due to critical installation issues.");
            Application.Quit();
        }
    }
}
