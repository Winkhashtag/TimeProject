using UnityEngine;

public class CalendarViewer : Interactable
{
    public Renderer calendarRenderer;

    public override void Interact()
    {
        GameManager.ins.calendarCanvas.Activate(DayManager.ins.calendarTextures[DayManager.ins.currentDay - 1]);
    }
}
