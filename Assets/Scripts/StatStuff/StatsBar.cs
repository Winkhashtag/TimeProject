using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private Image statsBarFill;
    [SerializeField] private TMP_Text statsBarText;

  

    public void UpdateStatsBar(float current, float maximum, string statsName)
    {
        statsBarFill.fillAmount = current / maximum;

        statsBarText.text = statsName + ": " + current + "/" + maximum;
    }
}
