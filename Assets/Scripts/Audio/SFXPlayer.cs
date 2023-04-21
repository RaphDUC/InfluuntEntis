using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioSource sfx;
    public void playSFXButton()
    {
        sfx.Play();
    }
}
