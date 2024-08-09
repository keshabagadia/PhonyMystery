using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    // Singleton instance of the ViewManager
    public static ViewManager instance;
    
    // Reference to the initial view to be shown
    public View startView;
    
    // Array to store all the views
    // List of views and their descriptions:
    // - InventoryView: Represents the phoneme inventory canvas.
    // - DeductionView: Handles the deduction or question/answer UI which 
    //                  includes the dialogue canvas,answer key frame and inventory canvas.
    // - NullView: Represents the exploration/default view which means the grey panel
    //              is disabled and the environment canvas is interactable.
    [SerializeField] private View[] views;
    
    // Reference to the grey panel canvas to overlay on the environment canvas
    //This is to ensure that the environment canvas is not interactable when a view is shown
    // Using a separate grey panel ensures that multiple canvases can be displayed simultaneously 
    //without visual inconsistencies that might occur if each canvas had its own grey panel.
    [SerializeField] Canvas panelCanvas;
    
    // Reference to the currently active view
    private View currentView;
    
    // Reference to the previously active view
    private View previousView;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure that there is only one instance of ViewManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize and hide all views
        foreach (View view in views)
        {
            view.Initialize();
            view.Hide();
        }
        
        // Show the start view if it is set
        if (startView != null)
        {
            startView.Show();
            currentView = startView;
            previousView = startView;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Handle the Escape key press to toggle between views:
        // - If the current view is NullView, switch back and forth from InventoryView.
        // - If the current view DeductionView, switch to NullView.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CheckCurrentView<InventoryView>() || CheckCurrentView<DeductionView>())
            {
                ShowView<NullView>();
            }
            else if (CheckCurrentView<NullView>())
            {
                ShowView<InventoryView>();
            }
        }
    }

    // Get and return a view of type T
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

    // Make the view of type T the current view
    public static void ShowView<T>() where T : View
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                if (instance.currentView != null)
                {
                    instance.currentView.Hide();
                }
                instance.views[i].Show();
                instance.currentView = instance.views[i];
            }
        }
    }

    // Show the previous view
    //This hasn't been used in the codebase yet but it can be useful in future implementations
    public static void ShowPreviousView()
    {
        if (instance.previousView != null)
        {
            instance.currentView.Hide();
            instance.previousView.Show();
            instance.currentView = instance.previousView;
        }
    }

    // Check if the current view is of type T
    public static bool CheckCurrentView<T>() where T : View
    {
        if (instance.currentView is T)
        {
            return true;
        }
        return false;
    }
}