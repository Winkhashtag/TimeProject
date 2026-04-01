using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public IVCanvas ivCanvas;

    [HideInInspector]
    public Node currentNode;

   
    public Node startingNode;

    public CameraRig rig;
    //bad singleton
    void Awake()
    {
        ins = this;
        ivCanvas.gameObject.SetActive(false);
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
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}
