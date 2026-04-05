using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private Image statsBarFill;
    [SerializeField] private Text statsBarText;

    private void Start()
    {
        UpdateStatsBar(50f, 100f,"Hunger");
    }

    public void UpdateStatsBar(float current, float maximum, string statsName)
    {
        statsBarFill.fillAmount = current / maximum;

        statsBarText.text = statsName + ": " + current + "/" + maximum;
    }
}
