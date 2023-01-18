using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject explosion;
    public int shotValue = 100;

    private void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);

        Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
    }
}

