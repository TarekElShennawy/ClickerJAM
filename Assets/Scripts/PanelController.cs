using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    private bool panelOpen;

    [SerializeField]
    private AudioSource audioSrc;
    
    [SerializeField]
    private AudioClip openSfx, closeSfx;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);

        panelOpen = false;
    }

    public void ShowPanel()
    {

        if(!panelOpen)
        {
            panel.SetActive(true);

            audioSrc.PlayOneShot(openSfx);
            panelOpen = true;
        }
        else
        {
            panel.SetActive(false);

            audioSrc.PlayOneShot(closeSfx);
            panelOpen = false;
        }
    }

    public void Test()
    {
        Debug.Log("Clicking");
    }
}
