using BepInEx;
using HarmonyLib;
using SelfRevive.Patches;
using UnityEngine;

namespace SelfRevive
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("Muck.exe")]
    public class SelfRevive : BaseUnityPlugin
    {
        public const string
            GUID = "SelfRevive",
            NAME = "SelfRevive",
            VERSION = "1.0.0";

        public static GameObject gameoverUI;

        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(MuckPatch));
            Logger.LogMessage("Loaded SelfRevive");
        }

        public static void Revive()
        {
            PlayerManager playerManager = GameManager.players[LocalClient.instance.myId];
            if (playerManager.dead && GameManager.state == GameManager.GameState.GameOver)
            {
                ClientSend.RevivePlayer(playerManager.id);
                GameManager.instance.gameoverUi.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                GameManager.state = GameManager.GameState.Playing;
            }
        }
    }
}
