using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public Transform cameraPosition;
    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked: " + gameObject.name);
        Arrive();
    }
  
    public void Arrive()
    {
        //leave existing current node
        if (GameManager.ins.currentNode != null)
        {
            GameManager.ins.currentNode.Leave();
        }

        //set current node
        GameManager.ins.currentNode = this;

        //move the camera
        Sequence seq = DOTween.Sequence();
        seq.Append(Camera.main.transform.DOMove(cameraPosition.position, 0.75f));
        seq.Join(Camera.main.transform.DORotate(cameraPosition.rotation.eulerAngles,0.75f));

        //Camera.main.transform.position = cameraPosition.position;
        //Camera.main.transform.rotation = cameraPosition.rotation;

        //turn off our own collider
        if (col != null)
            col.enabled = false;
        //turn on all reachable node's colliders
        foreach (Node node in reachableNodes)
        {
            if (node.col!= null)
            {
                node.col.enabled = true;
            }
        }
    }
    public void Leave()
    {
        //turn off all reachable node's colliders
        foreach (Node node in reachableNodes)
        {
            if (node.col != null)
            {
                node.col.enabled = false;
            }
        }
    }
}
