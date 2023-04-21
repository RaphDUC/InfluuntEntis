using UnityEngine;

public class AudioListenerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }
}
