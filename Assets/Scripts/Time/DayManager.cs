using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager ins;
    public int currentDay = 1;
    public int endingDay = 10;
    public Texture[] calendarTextures;

    void Awake()
    {
        ins = this;
    }

    public void CompleteDay()
    {
        currentDay++;

        if (currentDay >= endingDay)
        {
            TriggerEnding();
            return;
        }
    }

    void TriggerEnding()
    {
        Debug.Log("Game Over");
    }
}
