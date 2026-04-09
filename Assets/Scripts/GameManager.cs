using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public IVCanvas ivCanvas;
    public ObsCamera obsCamera;
    public CalendarCanvas calendarCanvas;
    public DrawingCanvas drawingCanvas;
    public GalleryCanvas galleryCanvas;

    [HideInInspector]
    public Node currentNode;

   
    public Node startingNode;

    public CameraRig rig;

    public GameObject gameOverPanel;
    public string gameOverMessage = "I hope this was enough.";
    public TMPro.TMP_Text gameOverText;


    //bad singleton
    void Awake()
    {
        ins = this;
        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
        calendarCanvas.gameObject.SetActive(false);
        drawingCanvas.Close();
    }

    private void Start()
    {
startingNode.Arrive();
    }
    void Update()
    {
        if (currentNode == null)
            return;

        if (Input.GetMouseButtonDown(1))
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

            StatReplenisher replenisher = currentNode.GetComponent<StatReplenisher>();
            if (replenisher != null && replenisher.isActive)
            {
                replenisher.Close();
                return;
            }

            if (currentNode.GetComponent<Prop>() != null && currentNode.GetComponent<Prop>().loc != null)
            {
                currentNode.GetComponent<Prop>().loc.Arrive();
            }

            if (GameManager.ins.drawingCanvas.IsOpen())
            {
                drawingCanvas.Close();
                return;
            }
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = gameOverMessage;
    }
}
