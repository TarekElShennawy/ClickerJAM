using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    public Game game;

    public AudioSource shipAudio;
    public AudioClip[] laserSfx;

    public TextMeshProUGUI scoreText;
    public Canvas scoreCanvas;

    public GameObject textSlot;

    private void OnMouseDown()  
    {
        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
        {
            if(g.name == "ShotSlot")
            {
                var shootingLogic = g.GetComponent<Shooting>();

                shootingLogic.Shoot();
                
                int shotValue = shootingLogic.shot.GetComponent<Shot>().shotValue;
                HandleScore(shotValue);

                PlayShotSfx(laserSfx);

                
                
            }
        }
    }

    void PlayShotSfx(AudioClip[] sfxList)
    {
        int randomChooser = Random.Range(0,laserSfx.Length);

        shipAudio.PlayOneShot(sfxList[randomChooser]);
    }

    void HandleScore(int shotValue)
    {
        game.damageDealt += shotValue;
        game.totalDamage += shotValue;

        //UI Pop-up
        scoreText.text = "+" + shotValue.ToString();
        var score = Instantiate(scoreText, textSlot.transform.position, textSlot.transform.rotation);
        score.transform.parent = scoreCanvas.transform;
    }
}
