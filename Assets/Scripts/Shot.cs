using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);

        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
    }
}

