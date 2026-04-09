using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GalleryCanvas : MonoBehaviour
{
    public static GalleryCanvas ins;

    public RawImage galleryImage;
    public GameObject galleryPanel;
    public GameObject statsCanvas;
    public float displayDuration = 3f;
    public float fadeDuration = 1f;

    private void Awake()
    {
        ins = this;
        galleryPanel.SetActive(false);
    }

    public void ShowGallery()
    {
        Debug.Log("Total drawings saved: " + DrawingCanvas.ins.GetSavedDrawings().Count);
        galleryPanel.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        statsCanvas.SetActive(false);
        StartCoroutine(DisplayDrawings());
    }


    IEnumerator DisplayDrawings()
    {
        List<Texture2D> drawings = DrawingCanvas.ins.GetSavedDrawings();
        Debug.Log("Starting gallery with " + drawings.Count + " drawings");

        foreach (Texture2D drawing in drawings)
        {
            yield return StartCoroutine(FadeImage(1f, 0f));

            galleryImage.texture = drawing;

            yield return StartCoroutine(FadeImage(0f, 1f));
            yield return new WaitForSeconds(displayDuration);
        }

        yield return StartCoroutine(FadeImage(1f, 0f));

        EndGame();
    }

    IEnumerator FadeImage(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color col = galleryImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            galleryImage.color = new Color(col.r, col.g, col.b, alpha);
            yield return null;
        }

        galleryImage.color = new Color(col.r, col.g, col.b, endAlpha);
    }

    void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Application.Quit();
    }

    public bool IsOpen()
    {
        return galleryPanel.activeInHierarchy;
    }
}
