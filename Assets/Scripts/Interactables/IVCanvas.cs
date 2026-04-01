using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class IVCanvas : MonoBehaviour
{
    public Image imageHolder;
  public void Activate(Sprite pic)
    {
        GameManager.ins.currentNode.SetReachableNodes(false);
        GameManager.ins.currentNode.col.enabled = false;
        gameObject.SetActive(true);
        imageHolder.sprite = pic;
    }   

    public void Close()
    {
        GameManager.ins.currentNode.SetReachableNodes(true);
        GameManager.ins.currentNode.col.enabled = true;
        gameObject.SetActive(false);
        imageHolder.sprite = null;
    }
}
