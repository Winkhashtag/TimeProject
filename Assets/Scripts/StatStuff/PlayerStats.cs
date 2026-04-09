using System;
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats ins;
    private bool isGameOver = false;

    [Header("Hunger")]
    public float hunger = 100f;
    public float maxHunger = 100f;
    public float hungerDecayRate = 1f;
    [SerializeField] private StatsBar hungerBar;

    [Header("Sleep")]
    public float sleep = 100f;
    public float maxSleep = 100f;
    public float sleepDecayRate = 0.5f;
    [SerializeField] private StatsBar sleepBar;

    [Header("Hygiene")]
    public float hygiene = 100f;
    public float maxHygiene = 100f;
    public float hygieneDecayRate = 0.3f;
    [SerializeField] private StatsBar hygieneBar;

    [Header("Bladder")]
    public float bladder = 100f;
    public float maxBladder = 100f;
    public float bladderDecayRate = .5f;
    [SerializeField] private StatsBar bladderBar;

    [Header("Happy")]   
    public float happy = 100f;
    public float maxHappy = 100f;
    public float happyDecayRate = .2f;
    [SerializeField] private StatsBar happyBar;

    [Header ("Social")]
    public float social = 100f;
    public float maxSocial = 100f;
    public float socialDecayRate = .2f;
    [SerializeField] private StatsBar socialBar;


   void Awake()
    {
        ins = this;
    }

    void Start()
    {
        UpdateAllBars();
    }

    public void Update()
    {
        DecayStats();
    }

    void DecayStats()
    {
        hunger = Mathf.Max(0, hunger - hungerDecayRate * Time.deltaTime);
        sleep = Mathf.Max(0, sleep - sleepDecayRate * Time.deltaTime);
        hygiene = Mathf.Max(0, hygiene - hygieneDecayRate * Time.deltaTime);
        bladder = Mathf.Max(0, bladder - bladderDecayRate * Time.deltaTime);
        happy = Mathf.Max(0, happy - happyDecayRate * Time.deltaTime);
        social = Mathf.Max(0, social - socialDecayRate * Time.deltaTime);

        UpdateAllBars();
        CheckPunishment();

    }

    void CheckPunishment()
    {
        if (isGameOver) return;

        if (hunger <= 0)
            Punish("Hunger");
        if (sleep <= 0)
            Punish("Sleep");
        if (hygiene <= 0)
            Punish("Hygiene");
        if (bladder <= 0)
            Punish("Bladder");
        if (happy <= 0)
            Punish("Happy");
        if (social <= 0)
            Punish("Social");

    }

    void Punish(string statName)
    {
        Debug.Log(statName + " had reached 0 - punishment triggered");
        isGameOver = true;
        StartCoroutine(GameOver());
    }

    public void ReplenishStat(string statName, float amount)
    {
        switch (statName)
        {
            case "Hunger":
                hunger = Mathf.Min(maxHunger, hunger + amount);
                break;
            case "Sleep":
                sleep = Mathf.Min(maxSleep, sleep + amount);
                break;
            case "Hygiene":
                hygiene = Mathf.Min(maxHygiene, hygiene + amount);
                break;
            case "Bladder":
                bladder = Mathf.Min(maxBladder, bladder + amount);
                break;
            case "Happy":
                happy = Mathf.Min(maxHappy, happy + amount);
                break;
            case "Social":
                social = Mathf.Min(maxSocial, social + amount);
                break;
        }
        UpdateAllBars();
    }

    void UpdateAllBars()
    {
        hungerBar.UpdateStatsBar(hunger, maxHunger, "Hunger");
        sleepBar.UpdateStatsBar(sleep, maxSleep, "Sleep");
        hygieneBar.UpdateStatsBar(hygiene, maxHygiene, "Hygiene");
        bladderBar.UpdateStatsBar(bladder, maxBladder, "Bladder");
        happyBar.UpdateStatsBar(happy, maxHappy, "Happy");
        socialBar.UpdateStatsBar(social, maxSocial, "Social");
    }

    IEnumerator GameOver()
    {
        GameManager.ins.ShowGameOver();
        yield return new WaitForSeconds(5f);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
