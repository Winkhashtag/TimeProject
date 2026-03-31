using UnityEngine;

public class ImageViewer : Interactable
{
    public override void Interact()
    {
        GameManager.ins.ivCanvas.Activate();
    }   
}
