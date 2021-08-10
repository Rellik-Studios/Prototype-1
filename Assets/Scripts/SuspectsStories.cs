using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspectsStories : MonoBehaviour
{
    [SerializeField] TextAsset story;
    [SerializeField] TextAsset storyTalked;
    public bool talked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool HasTalked()
    {
        return talked;
    }

    public TextAsset GetStory()
    {
        return talked ? storyTalked : story;
    }
}
