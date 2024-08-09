using UnityEngine;

// This class handles changing the environment canvas when a left click on the parent arrow button is detected.
public class ChangeEnvCanvas : MonoBehaviour
{
    // Reference to the canvas that will be shown when the left click occurs.
    public GameObject changedCanvas;

    // Method called when a left click is detected.
    public void OnLeftClick()
    {
        // Show the specified canvas using the EnvCanvasManager singleton instance.
        EnvCanvasManager.instance.ShowCanvas(changedCanvas);
    }
}