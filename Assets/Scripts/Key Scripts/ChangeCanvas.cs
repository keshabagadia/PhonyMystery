using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    public GameObject changedCanvas;

    public void OnLeftClick()
    {
        CanvasManager.instance.ShowCanvas(changedCanvas);
    }
}