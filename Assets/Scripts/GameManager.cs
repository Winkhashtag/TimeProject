using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public IVCanvas ivCanvas;
    public ObsCamera obsCamera;
    public CalendarCanvas calendarCanvas;

    [HideInInspector]
    public Node currentNode;

   
    public Node startingNode;

    public CameraRig rig;
    //bad singleton
    void Awake()
    {
        ins = this;
        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
        calendarCanvas.gameObject.SetActive(false);
    }

    private void Start()
    {
startingNode.Arrive();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            if (ivCanvas.gameObject.activeInHierarchy)
            {
                ivCanvas.Close();
                return;
            }
            if (obsCamera.gameObject.activeInHierarchy)
            {
                obsCamera.Close();
                return;
            }
            if (calendarCanvas.gameObject.activeInHierarchy)
            {
                calendarCanvas.Close();
                return;
            }
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}
