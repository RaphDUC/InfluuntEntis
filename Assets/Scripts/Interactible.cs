using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canBePickedUp = true;
    public string interactableName = "Object";
    public string interactableAction = "Pick Up";
    public UIManager interactableUIManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show interaction prompt
            interactableUIManager.ShowInteractionPrompt(interactableAction + " " + interactableName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide interaction prompt
            interactableUIManager.HideInteractionPrompt();
        }
    }

    public virtual void Interact(Character character)
    {
        if (canBePickedUp)
        {
            // Add object to player inventory or something
            Debug.Log("Picked up " + interactableName +" by character " +character);
            Destroy(gameObject);
        }
    }
}
