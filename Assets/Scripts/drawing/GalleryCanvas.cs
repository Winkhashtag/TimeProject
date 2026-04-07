using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using NUnit.Framework;
public class GalleryCanvas : MonoBehaviour
{
    public static GalleryCanvas ins;

    public RawImage galleryImage;
    public GameObject galleryPanel;
    public float displayDuration = 3f;

    private void Awake()
    {
        ins = this;
        galleryPanel.SetActive(false);

    }

    public void ShowGallery()
    {
        galleryPanel.SetActive(true);
        StartCoroutine(DisplayDrawings());
    }

    IEnumerator<WaitForSeconds> DisplayDrawings()
    {
        List<Texture2D> drawings = DrawingCanvas.ins.GetSavedDrawings();
        
        if (drawings.Count == 0)
        {
            EndGame();
            yield break;
        }

        foreach (Texture2D drawing in drawings)
        {
            galleryImage.texture = drawing;
            yield return new WaitForSeconds(displayDuration);
        }

        EndGame();
    }

    void EndGame()
    {
        Application.Quit();
    }
}
