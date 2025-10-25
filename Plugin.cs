using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SPTest;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("SPACEPLAN.exe")]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        var kinetigen = KinetigenController.Instance();
        if (kinetigen == null)
        {
            Logger.LogWarning("KinetigenController instance empty");
        }
        else
        {
            Logger.LogWarning("KinetigenController instance found");
        }
    }

    private uint count = 0;
    void Update()
    {
        count++;
        var kinetController = KinetigenController.Instance();
        if (kinetController != null)
        {
            if (kinetController.KinetigenPowerGeneration <= 500_000_000)
            {
                kinetController.SetKinetigenPower(500_000_000);
                // Logger.LogInfo("Power modified successfully!");
            }
        }

        // if ((Autoplayer.Instance()?.Autoplay ?? false) == true)
        // {
        //     Logger.LogWarning($"Autoplayer.Instance()?.Autoplay = {Autoplayer.Instance()?.Autoplay}");

        //     Autoplayer.Instance().ToggleAutoplayer();
        // }
        var powerController = PowerController.Instance();
        if (powerController != null)
        {
            if (count % 100 == 0 && powerController.GetPower() < 100_000_000)
            {
                powerController.SetPower(100_000_000);
                // var solarPanel = powerController.Generators.First(x => x.ItemType == ItemType.RepairSolarPanel);
                // solarPanel.SetCount(solarPanel.Count + 1);

                // Logger.LogInfo(solarPanel.Count);
            }

            if (count % 100 == 0)
            {
            }

        }

        // Unlock Research
        // var research = PowerController.Instance().FindUnavailableIdea(ResearchType.GreasyHashies);
        // Logger.LogInfo(research);
        // research.CreateBuyable();

        // Unlock Research
        // var research = PowerController.Instance().FindUnavailableIdea(ResearchType.GreasyHashies);
        // Logger.LogInfo(research);
        // research.CreateBuyable();


    }

}
