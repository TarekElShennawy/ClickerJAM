using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float currentHealth, startingHealth;

    [SerializeField]
    protected GameObject portal;

    void Start()
    {
        currentHealth = startingHealth;
    }

    protected void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);

            GameManager.Instance.UpdateGameState(GameState.PlayerTeleporting);
        }
    }
    
    protected void SpawnPortal()
    {
        Instantiate(portal, new Vector3(-2.42f,-1.7f,324f), Quaternion.identity);
    }
}
