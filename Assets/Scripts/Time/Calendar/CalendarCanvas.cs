using UnityEngine;
using UnityEngine.UI;

public class CalendarCanvas : MonoBehaviour
{
    public RawImage calendarImage;

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
