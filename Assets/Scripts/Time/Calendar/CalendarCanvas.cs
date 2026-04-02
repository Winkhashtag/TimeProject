using UnityEngine;
using UnityEngine.UI;

public class CalendarCanvas : MonoBehaviour
{
    public RawImage calendarImage;

    public void Activate(Texture tex)
    {
        calendarImage.texture = tex;
        gameObject.SetActive(true);
    }

    public void Close()
    {
       calendarImage.texture = null;
    }
}
