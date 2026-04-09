using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager ins;
    public int currentDay = 1;
    public int endingDay = 10;
    public Texture[] calendarTextures;
    private bool gameEnded = false;

    void Awake()
    {
        ins = this;

    }

    public void CompleteDay()
    {
        if (gameEnded)
            return;


        currentDay++;

        FindObjectsByType<CalendarMesh>(FindObjectsSortMode.None)[0].UpdateTexture();

        if (currentDay >= endingDay)
        {
            gameEnded = true;
            GalleryCanvas.ins.ShowGallery();
            return;
        }
    }
 
}
