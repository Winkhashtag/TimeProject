using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public Node currentNode;

    public static GameManager ins;
    public Node startingNode;

    public CameraRig rig;
    //bad singleton
    void Awake()
    {
        ins = this;
    }

    private void Start()
    {
startingNode.Arrive();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}
