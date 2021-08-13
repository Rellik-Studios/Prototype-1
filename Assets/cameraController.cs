using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private GameObject inkDialogue;

    private List<GameObject> cameras;
    private int index = 0;
    [SerializeField] private int defaultTimer;
    private InspectObject inspector;
    private InventorySystem inventorySystem;
    enum lSwitch
    {
        UP, DOWN
    }

    private lSwitch lastSwitch;
    private int cameraIndex
    {
        get => index;
        set => index = (value < 0) ? cameras.Count - 1:(value > cameras.Count - 1)?0 : value;
    }

    void Awake()
    {
        inventorySystem = GameObject.FindObjectOfType<InventorySystem>();
        inspector = GameObject.FindObjectOfType<InspectObject>();
        inkDialogue = GameObject.FindGameObjectWithTag("InkDialogue");
        Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = defaultTimer;
        cameras = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            cameras.Add(transform.GetChild(i).gameObject);    
        }
        
    }

    private bool canSwitch = true;
    void Update()
    {
        if (canSwitch)
        {
            if (cameraIndex == 4)
            {
                cameras[cameraIndex].SetActive(false);
                cameraIndex += lastSwitch == lSwitch.UP ? 1 : -1;
                cameras[cameraIndex].SetActive(true);
                canSwitch = false;
                StartCoroutine(CanSwitch(defaultTimer));
            }

            if (Input.GetKeyDown(KeyCode.Q) && !inkDialogue.activeInHierarchy && !inspector.isInspecting && !inventorySystem.isInventoryOpen)
            {
                lastSwitch = lSwitch.DOWN;
                cameras[cameraIndex].SetActive(false);
                cameraIndex--;
                cameras[cameraIndex].SetActive(true);
                canSwitch = false;
                StartCoroutine(CanSwitch(defaultTimer));
               
            }

            if (Input.GetKeyDown(KeyCode.E) && !inkDialogue.activeInHierarchy && !inspector.isInspecting && !inventorySystem.isInventoryOpen)
            {
                cameras[cameraIndex].SetActive(false);
                lastSwitch = lSwitch.UP;
                cameraIndex++;
                cameras[cameraIndex].SetActive(true);
                canSwitch = false;
                StartCoroutine(CanSwitch(defaultTimer));
                
            }
        }
    }

    IEnumerator CanSwitch(int timer)
    {
        yield return new WaitForSeconds(timer);
        canSwitch = true;
    }
}
