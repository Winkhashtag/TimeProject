using UnityEngine;
using UnityEngine.UI;

public class CalendarCanvas : MonoBehaviour
{
    public RawImage calendarImage;
    private int lastDay = -1;//tracks last day shown

    private void Update()
    {
        if (!gameObject.activeInHierarchy) return;

        int currentDay = DayManager.ins.currentDay;

        //only update if the day changes
        if (currentDay != lastDay)
        {
            calendarImage.texture = DayManager.ins.calendarTextures[currentDay - 1];
            lastDay = currentDay;
        }
    }

    public void Activate(Texture tex)
    {
        GameManager.ins.currentNode.SetReachableNodes(false);
        GameManager.ins.currentNode.col.enabled = false;
        calendarImage.texture = tex;
        gameObject.SetActive(true);
    }

    public void Close()
    {
       
       GameManager.ins.currentNode.SetReachableNodes(true);
       GameManager.ins.currentNode.col.enabled = true;
       gameObject.SetActive(false);
       calendarImage.texture = null;
    }
}
