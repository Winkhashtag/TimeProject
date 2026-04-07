using UnityEngine;

public class EaselInteractable : Interactable
{

    public override void Interact()
    {
        DrawingCanvas.ins.Open();
    }
}
