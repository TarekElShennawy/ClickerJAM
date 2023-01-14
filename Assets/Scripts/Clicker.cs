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
                g.GetComponent<Shooting>().Shoot();
                PlayShotSfx(laserSfx);

                HandleScore();
                game.damageDealt += 1;
            }
        }
    }

    void PlayShotSfx(AudioClip[] sfxList)
    {
        int randomChooser = Random.Range(0,laserSfx.Length);

        shipAudio.PlayOneShot(sfxList[randomChooser]);
    }

    void HandleScore()
    {
        var score = Instantiate(scoreText, textSlot.transform.position, textSlot.transform.rotation);
        score.transform.parent = scoreCanvas.transform;
    }
}
