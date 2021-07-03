using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SelfRevive.Patches
{
    public class MuckPatch
    {
        [HarmonyPostfix, HarmonyPatch(typeof(GameManager), nameof(GameManager.ShowEndScreen))]
        public static void OnShowEndScreen()
        {
            if (GameManager.players.Count == 1)
            {
                if (SelfRevive.gameoverUI == null)
                {
                    SelfRevive.gameoverUI = GameObject.Find("UI (1)/GameoverUi").gameObject;
                    GameObject menuButton = SelfRevive.gameoverUI.transform.Find("MenuButton").gameObject;
                    GameObject reviveButton = Object.Instantiate(menuButton, SelfRevive.gameoverUI.transform);
                    menuButton.transform.position = new Vector3(menuButton.transform.position.x + 400, menuButton.transform.position.y, menuButton.transform.position.z);
                    reviveButton.transform.position = new Vector3(reviveButton.transform.position.x - 400, reviveButton.transform.position.y, reviveButton.transform.position.z);
                    reviveButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
                    reviveButton.GetComponent<Button>().onClick.AddListener(() => SelfRevive.Revive());
                    reviveButton.transform.Find("RawImage").GetComponentInChildren<TMP_Text>().text = "Revive";
                }
            }
        }
    }
}
