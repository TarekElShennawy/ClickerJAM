using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    
    public GameObject shot;

    [SerializeField]
    private Transform shotSlot;

    public void Shoot()
    {
        GameObject shotInstance = Instantiate(shot, shotSlot.position,shotSlot.rotation);

        
        shotInstance.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10000);
        
    }

    
}
