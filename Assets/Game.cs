using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public float damageDealt;
    public float damagePerSecond;

    public TextMeshProUGUI damageUI;
    public TextMeshProUGUI dpsUI;

    void Awake()
    {
        damageDealt = 0;
        damagePerSecond = 0;
    }

    // Update is called once per frame
    void Update()
    {
        damageUI.text = "Damage: " + damageDealt;
        dpsUI.text = "DPS: " + damagePerSecond;
    }
}
