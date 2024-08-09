using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : View
{
    [SerializeField] List<GameObject> canvases = new List<GameObject>();
    public override void Initialize()
    {
        Debug.Log("InventoryView Initialize");
    }

    public override void Hide()
    {
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }
    }

    public override void Show()
    {
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(true);
        }
    }

}
