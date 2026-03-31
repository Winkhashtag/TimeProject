using UnityEngine;


[RequireComponent (typeof(Prop))]
public class Interactable : MonoBehaviour
{
   
    void Start()
    {
        this.enabled = false;

    }

 public void Interact()
    {
        Debug.Log("Interacting with " +name);
    }   
}
