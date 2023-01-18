using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRotate : MonoBehaviour
{
    void Awake()
    {
        Invoke("DestroyMonster", 4f);
    }

    
    void Update()
    {
        gameObject.transform.Rotate(Vector3.back);

    }

    void DestroyMonster()
    {
        Destroy(this.gameObject);
    }
}
