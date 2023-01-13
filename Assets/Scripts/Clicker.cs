using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    public Game game;

    public GameObject shot;

    [SerializeField]
    private Transform shotSlot;

    public TextMeshProUGUI scoreText;
    public Canvas scoreCanvas;

    public GameObject textSlot;

    public AudioSource shipAudio;
    public AudioClip[] laserSfx;
    
    void OnMouseDown()
    {
        Shoot();
    }

    void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;
        GameObject shotInstance = Instantiate(shot, shotSlot.position,shotSlot.rotation);

        var score = Instantiate(scoreText, textSlot.transform.position, textSlot.transform.rotation);
        score.transform.parent = scoreCanvas.transform;
        PlayShotSfx(laserSfx);

        shotInstance.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10000);
        game.damageDealt += 1;
    }

    void PlayShotSfx(AudioClip[] sfxList)
    {
        int randomChooser = Random.Range(0,laserSfx.Length);

        shipAudio.PlayOneShot(sfxList[randomChooser]);
    }

    void Update()
    {
        if(shotSlot == null)
        {
            shotSlot = GameObject.Find("ShotSlot").transform;
        }
        else
        {
            Debug.Log("No Shotslot found!");
        }
    }
}
