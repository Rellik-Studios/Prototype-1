using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspectsStories : MonoBehaviour
{
    [SerializeField] TextAsset story;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TextAsset GetStory()
    {
        return story;
    }
}
