using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class DrawingCanvas : MonoBehaviour
{
    public static DrawingCanvas ins;

    public RawImage canvasImage;
    public int textureWidth = 512;
    public int textureHeight = 512;
    public float brushSize = 5f;
    public Color brushColor = Color.black;

    public GameObject drawingPanel;
    public Image colorPreview;

    private Texture2D drawTexture;
    private bool isDrawing = false;
    private List<Texture2D> savedDrawings = new List<Texture2D>();


    public bool IsOpen()
    {
        return drawingPanel.activeInHierarchy;
    }

    private void Awake()
    {
        ins = this;
    }

    public void Open()
    {
        drawingPanel.SetActive(true);

        if (drawTexture == null)
        {
            NewCanvas();
        }
    }

    public void Close()
    {
        drawingPanel.SetActive(false);
    }

    void NewCanvas()
    {
        drawTexture = new Texture2D(textureWidth, textureHeight);
        drawTexture.Apply();
        canvasImage.texture = drawTexture;
    }

    private Vector2? lastDrawPos = null;

    private void Update()
    {
        if (!drawingPanel.activeSelf) return;

        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                eventData.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, results);

                foreach (var result in results)
                {
                    if (result.gameObject != canvasImage.gameObject)
                        return;
                }
            }

            Vector2 localPoint;
            RectTransform rt = canvasImage.rectTransform;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, null, out localPoint))
            {
                float normalizedX = (localPoint.x / rt.rect.width) + 0.5f;
                float normalizedY = (localPoint.y / rt.rect.height) + 0.5f;

                if (normalizedX >= 0 && normalizedX <= 1 && normalizedY >= 0 && normalizedY <= 1)
                {
                    int x = (int)(normalizedX * textureWidth);
                    int y = (int)(normalizedY * textureHeight);
                    Draw(x, y);
                    drawTexture.Apply();
                }
            }
        }
    }
    void Draw(int x, int y)
    {
        int size = (int)brushSize;
        for(int i = -size; i <= size; i++)
        {
            for(int j = -size; j <= size; j++)
            {
                if (i * i + j * j <= size * size)
                {
                    int px = Mathf.Clamp(x + i, 0, textureWidth - 1);
                int py = Mathf.Clamp(y + j, 0, textureHeight - 1);
                drawTexture.SetPixel(px,py, brushColor);
                }
            }
        }
    }

    public void SetColor(Color color)
    {
        brushColor = color;
        if (colorPreview != null)
            colorPreview.color = color;
    }

    public void Submit()
    {
        Texture2D savedCopy = new Texture2D(textureWidth, textureHeight);
        savedCopy.SetPixels(drawTexture.GetPixels());
        savedCopy.Apply();
        savedDrawings.Add(savedCopy);

        PlayerStats.ins.ReplenishStat("Happy", 50f);

        Close();
    }

    public List<Texture2D> GetSavedDrawings()
    {
        return savedDrawings;
    }

    public void SetBrushSize(float size)
    {
        brushSize = size;
    }
}
