using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionIntroTOMenu : MonoBehaviour
{

    public void Test()
    {
        Debug.Log("Hello cyka");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Transition to menu Scene
    private void OnEnable()
    {
        SceneManager.LoadScene("menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
