using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    public float currentHealth, startingHealth;

    [SerializeField]
    protected GameObject portal;

    public GameObject healthBarParent;
    private Image healthBarImage;

    private float healthPercentage;

    void Start()
    {
        currentHealth = startingHealth;
        
        healthBarParent = GameObject.FindGameObjectWithTag("Healthbar");
 
        healthBarImage = healthBarParent.transform.GetChild(1).GetChild(0).GetComponent<Image>(); //TODO: Figure out that line, I hate it so much

        var healthBarName = healthBarParent.GetComponentInChildren<TextMeshProUGUI>();

        healthBarName.text = this.gameObject.name;

        //Setting up healthbar as boss spawns
        UpdateHealthbar();
    }

    protected void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        UpdateHealthbar();

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

    public void UpdateHealthbar() {
        healthPercentage = (currentHealth)/(startingHealth);
        healthBarImage.fillAmount = healthPercentage;
    }

}
