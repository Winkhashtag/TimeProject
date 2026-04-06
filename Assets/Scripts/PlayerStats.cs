using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float hunger;
    public float maxHunger;

    public float sleep;
    public float hygiene;
    public float bladder;
    public float work;
    public float happy;
    public float social;

    [SerializeField] private StatsBar hungerBar;

    private void Start()
    {
        hunger = 100f;
        IsHungry(50f);
    }
    public void UpdateHungerBar()
    {
        hungerBar.UpdateStatsBar(hunger, maxHunger, "Hunger");
    }

    public void IsHungry(float amount)
    {
        hunger -= amount;
        UpdateHungerBar();
    }
}
