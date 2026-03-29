using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        Camera.main.transform.position = cameraPosition.position;
        Camera.main.transform.rotation = cameraPosition.rotation;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
                Debug.Log("Hit: " + hit.collider.gameObject.name);
            else
                Debug.Log("Raycast hit nothing");
        }
    }
}
