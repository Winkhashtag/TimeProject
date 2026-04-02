using UnityEngine;
using UnityEngine.UI;

public class CalendarViewer : Interactable
{
    public Renderer calendarRenderer;
    public RawImage calendarRawImage;
    public override void Interact()
    {
        // Show in UI
        GameManager.ins.calendarCanvas.Activate(
            DayManager.ins.calendarTextures[DayManager.ins.currentDay - 1]
        );

      
    }

  
}