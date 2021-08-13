using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        //used for testing purpose
        //remove when testing is done
        
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.W))
        {
            WinButton();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoseButton();
        }
#endif
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnButton()
    {
        SceneManager.LoadScene(0);
    }
    public void WinButton()
    {
        SceneManager.LoadScene(2);
    }
    public void LoseButton()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
