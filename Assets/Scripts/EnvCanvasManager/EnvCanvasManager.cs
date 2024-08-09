using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvCanvasManager : MonoBehaviour
{
    public static EnvCanvasManager instance;
    public List<GameObject> canvases = new List<GameObject>();
    public GameObject currentCanvas;
    public GameObject startCanvas;

    private void Awake()
    {
        instance = this;
        DisableAllCanvas();
        if(startCanvas == null)
        {
            startCanvas = canvases[0];
        }
        ShowCanvas(startCanvas);
    }

    public void DisableAllCanvas()
    {
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }
    }

    public void ShowCanvas(GameObject canvas)
    {
        if (currentCanvas != null)
        {
            currentCanvas.SetActive(false);
        }
        currentCanvas = canvas;
        currentCanvas.SetActive(true);
    }

}
