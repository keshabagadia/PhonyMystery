using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract base class for all views in the application.
public abstract class View : MonoBehaviour
{
    // Method to initialize the view. Must be implemented by derived classes.
    //Each view is intended to be attached to its respective canvas game object in the scene.
    public abstract void Initialize();

    // Method to hide the view. Can be overridden by derived classes.
    public virtual void Hide()
    {
        // Deactivate the parent GameObject to hide the view.
        gameObject.SetActive(false);
    }

    // Method to show the view. Can be overridden by derived classes.
    public virtual void Show()
    {
        // Activate the parent GameObject to show the view.
        gameObject.SetActive(true);
    }
}