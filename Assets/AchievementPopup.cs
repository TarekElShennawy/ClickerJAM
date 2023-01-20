using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementPopup : MonoBehaviour
{
    public TextMeshProUGUI achievementText;
    public Canvas achievementCanvas;

    public GameObject achievementSlot;

    public void PopUp()
    {
        var popup = Instantiate(achievementText, achievementSlot.transform.position, achievementSlot.transform.rotation);
        popup.transform.parent = achievementCanvas.transform;
    }
}
