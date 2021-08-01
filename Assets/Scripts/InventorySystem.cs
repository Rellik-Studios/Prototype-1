using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public Image[] slots;
    public int current_index=-1;
    private EvidenceInfo[] evidList = new EvidenceInfo[12];
    private bool IsInvenOpen = false;
    public GameObject InventoryUI;

    public Text nameText;
    public Text nameDescript;
    public Image previewImage;

    // Start is called before the first frame update
    void Start()
    {
        InventoryUI.SetActive(IsInvenOpen);
    }

    // Update is called once per frame
    void Update()
    {
        //for testing purposes on whether the inventory menu is opened
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsInvenOpen = !IsInvenOpen;
            InventoryUI.SetActive(IsInvenOpen);
            current_index = -1;
        }
        //this function will update the Inventory items in there
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateInventory();
        }
    }
    //function used for the buttons in inventory 
    public void SelectEvidence(int index)
    {
        current_index = index;
        UpdatePreview();


    }
    
    public void UpdateInventory()
    {
        int index = -1;
        foreach (var vEvidence in gameManager.Instance.collectedEvidences)
        {
            index++;
            evidList[index] = vEvidence.Value;
            slots[index] = evidList[index].GetImage();
        }
    }

   //update the preview shown in inventory system.
    void UpdatePreview()
    {
        //update name
        nameText.text = evidList[current_index].evidenceName;

        //update description
        nameDescript.text = "";
        foreach (string sentence in evidList[current_index].descriptions)
        {
            nameDescript.text += sentence;
        }

        //update image
        previewImage = evidList[current_index].GetImage();

    }
}
