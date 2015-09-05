using UnityEngine;
using System.Collections;

public class GlobalStats : MonoBehaviour, IController
{
    public DodgeStats dodgeStats;
    public ShootStats shootStats;
    public GameStats gameStats;

    public static string DodgeStats = "GlobalStats.DodgeStats";
    public static string ShootStats = "GlobalStats.ShootStats";
    public static string GameStats = "GlobalStats.GameStats";

    private StatsManager statsManager;

    void Awake()
    {
        statsManager = Resolver.Instance.GetController<StatsManager>();

        statsManager.AddSetting<DodgeStats>(DodgeStats, dodgeStats);
        statsManager.AddSetting<ShootStats>(ShootStats, shootStats);
        statsManager.AddSetting<GameStats>(GameStats, gameStats);

        EventHandler eventHandler = Resolver.Instance.GetController<EventHandler>();
        eventHandler.Register(Events.Shoot.BaddieKilled, BaddieKilled);
    }

    public void BaddieKilled(int id, object data)
    {
        Setting dodgeStats = statsManager.GetSetting(DodgeStats);
        ((DodgeStats)dodgeStats.Value).baddiesDestroyed++;
    }


    public void Cleanup()
    {

    }
}


