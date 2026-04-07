using UnityEngine;
using UnityEngine.UI;


public class ColorButton : MonoBehaviour
{
    public Color color;

    private void Start()
    {
        GetComponent<Image>().color = color;
        GetComponent<Button>().onClick.AddListener(() => DrawingCanvas.ins.SetColor(color));
    }

}
