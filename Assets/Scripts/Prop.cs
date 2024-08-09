using UnityEngine;

public class Prop : Interactable
{   
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with prop");
    }

}   