using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);
    }
}

