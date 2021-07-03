using HarmonyLib;
using UnityEngine;

namespace SelfRevive.Patches
{
    public class MuckPatch
    {
        [HarmonyPostfix, HarmonyPatch(typeof(ChatBox), nameof(ChatBox.Instance.ChatCommand))]
        public static void OnChatCommand(ref string message)
        {
            if (message == "/revive")
            {
                PlayerManager playerManager = GameManager.players[LocalClient.instance.myId];
                if (playerManager.dead && GameManager.state == GameManager.GameState.GameOver && GameManager.players.Count == 1)
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
}
