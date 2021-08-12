using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private List<GameObject> cameras;
    private int index = 0;
    [SerializeField] private int defaultTimer;
    private int cameraIndex
    {
        get => index;
        set => index = (value < 0) ? 3:(value > 3)?0 : value;
    }

    void Awake()
    {
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                cameras[cameraIndex].SetActive(false);
                cameraIndex--;
                cameras[cameraIndex].SetActive(true);
                canSwitch = false;
                StartCoroutine(CanSwitch(defaultTimer));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                cameras[cameraIndex].SetActive(false);
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
