using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public Game game;

    public GameObject shot;
    public Transform shotSlot;

    void OnMouseDown()
    {
        GameObject shotInstance = Instantiate(shot, shotSlot.position,shotSlot.rotation);

        shotInstance.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10000);
        game.damageDealt += 1;
    }
}
