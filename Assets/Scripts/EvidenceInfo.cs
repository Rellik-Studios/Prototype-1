using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceInfo : MonoBehaviour
{
    private Sprite evidenceImage;

    public string evidenceName;
    [TextArea]
    public List<string> descriptions;

    public int pointer;

    // Start is called before the first frame update
    void Start()
    {
        evidenceImage = Resources.Load<Sprite>("Images/" + gameObject.name.ToLower().Replace(" ", " "));
        if(evidenceImage == null)
        {
            evidenceImage = Resources.Load<Sprite>("Images/knife");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pointer > descriptions.Count - 1)
        {
            pointer = descriptions.Count - 1;
        }
    }

    public void ModifyAppend()
    {
        pointer++;
    }
   

    public void Information()
    {
        Debug.Log(evidenceName);
        Debug.Log(descriptions[pointer]);
    }

    public Sprite GetImage()
    {
        return evidenceImage;
    }
}
