using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    private bool panelOpen;

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

            panelOpen = true;
        }
        else
        {
            panel.SetActive(false);

            panelOpen = false;
        }
    }
}
