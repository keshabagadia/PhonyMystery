using UnityEngine;

public class NullView : View
{
    [SerializeField] private GameObject canvases;
    [SerializeField] private GameObject gameCanvas;
    public override void Initialize()
    {
        //gameCanvas.SetActive(true);
    }

    public override void Hide()
    {
       // gameCanvas.SetActive(false);//replace with disabling clues
    }

    public override void Show()
    {
        //gameCanvas.SetActive(true);
    }
}
