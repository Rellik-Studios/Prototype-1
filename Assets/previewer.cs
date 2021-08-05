using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class previewer : MonoBehaviour
{
    public int currentScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Text>().text = SceneManager.GetActiveScene().name;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentScene++;
            if (currentScene >= SceneManager.sceneCountInBuildSettings)
            {
                currentScene = 0;
            }
            SceneManager.LoadScene(currentScene);

            if(currentScene == 0)
            {
                Destroy(gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentScene--;
            if (currentScene < 0)
            {
                currentScene = SceneManager.sceneCountInBuildSettings - 1;
            }
            SceneManager.LoadScene(currentScene);

            if (currentScene == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
