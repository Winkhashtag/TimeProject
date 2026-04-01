using UnityEngine;

public class ImageViewer : Interactable
  
{
    public Sprite pic;
    public override void Interact()
    {
        GameManager.ins.ivCanvas.Activate(pic);
    }   
}
