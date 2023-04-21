using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text interactionPrompt;

    public void ShowInteractionPrompt(string message)
    {
        interactionPrompt.text = message;
        interactionPrompt.gameObject.SetActive(true);
    }

    public void HideInteractionPrompt()
    {
        interactionPrompt.gameObject.SetActive(false);
    }
}