using BepInEx;
using HarmonyLib;
using SelfRevive.Patches;

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

        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(MuckPatch));
            Logger.LogMessage("Loaded SelfRevive");
        }
    }
}
