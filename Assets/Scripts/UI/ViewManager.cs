using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public static ViewManager instance;//to store the instance of the view manager
    public View startView;//to store the start view
    [SerializeField] private View[] views;//to store all the views
    [SerializeField] Canvas panelCanvas;//to store the panel canvas
    private View currentView;//to store the current view
    private View previousView;//to store the previous view
    //to make a singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (View view in views)
        {
            view.Initialize();
            view.Hide();
        }
        if (startView != null)
        {
            startView.Show();
            currentView = startView;
            previousView = startView;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(CheckCurrentView<InventoryView>()||CheckCurrentView<DeductionView>())
            {
                ShowView<NullView>();
            } else if(CheckCurrentView<NullView>())
            {
                ShowView<InventoryView>();
            }
        }
    }
    //to get the view
    public static T GetView<T>() where T : View
    {
        foreach (View view in instance.views)
        {
            if (view is T)
            {
                return view as T;
            }
        }
        return null;
    }

    public static void ShowView<T>() where T : View
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                if(instance.currentView != null)
                {
                    instance.currentView.Hide();
                }
                instance.views[i].Show();
                instance.currentView = instance.views[i];
            }
        }
    }

    public static void ShowPreviousView()
    {
        if (instance.previousView != null)
        {
            instance.currentView.Hide();
            instance.previousView.Show();
            instance.currentView = instance.previousView;
        }
    }

    public static bool CheckCurrentView<T>() where T : View
    {
        if (instance.currentView is T)
        {
            return true;
        }
        return false;
    }
}
