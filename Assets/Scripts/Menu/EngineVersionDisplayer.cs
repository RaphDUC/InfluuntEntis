using UnityEngine;
using UnityEngine.UI;

public class EngineVersionDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();
        text.text = "Unity version "+Application.unityVersion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
