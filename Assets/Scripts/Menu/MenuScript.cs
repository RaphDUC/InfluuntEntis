using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

  
    // Start is called before the first frame update
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1);
        AudioListener.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NewGame()
    {
        //SceneManager.LoadScene("newGame");
        Debug.Log("newGame!");
    }

    public void LoadGame()
    {
        //SceneManager.LoadScene("savesList");
        Debug.Log("savesList!");
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
	