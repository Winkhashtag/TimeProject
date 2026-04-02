using UnityEngine;

public class CalendarMesh : MonoBehaviour
{
    public Renderer calendarRenderer;

    private void Start()
    {
        UpdateTexture();
    }

    public void UpdateTexture()
    {
        calendarRenderer.material.mainTexture = DayManager.ins.calendarTextures[DayManager.ins.currentDay - 1];
    }
}