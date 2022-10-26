using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame() {

        Application.Quit();
    }
    public void StartFunction() {
        SceneManager.LoadScene("Scene_01");
       
    }
    public void FirstFunction() {

        SceneManager.LoadScene("Scene_00");
    }
}
