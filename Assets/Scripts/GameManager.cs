using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public Node currentNode;

    public static GameManager ins;
    //bad singleton
    void Awake()
    {
        ins = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}
