using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    public float currentHealth, startingHealth;

    public GameObject healthBarParent;

    private Image healthBarImage;

    private ScreenShake screenShake;

    private float healthPercentage;

    private AudioSource audioSrc;

    public AudioClip explosionSfx;

    public GameObject monsterObj;

    void Start()
    {
        currentHealth = startingHealth;
        
        healthBarParent = GameObject.FindGameObjectWithTag("Healthbar");

        screenShake = GameObject.Find("Main Camera").GetComponent<ScreenShake>();

        audioSrc = GameObject.Find("Game").GetComponent<AudioSource>();
 
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
        DropMonster();
        
        if(currentHealth <= 0)
        {
            //Death logic
            audioSrc.PlayOneShot(explosionSfx);
            
            Destroy(this.gameObject);
            
            GameManager.Instance.UpdateGameState(GameState.PlayerTeleporting);
        }
    }

    public void UpdateHealthbar() {
        healthPercentage = (currentHealth)/(startingHealth);
        healthBarImage.fillAmount = healthPercentage;
    }

    void DropMonster()
    {
        Instantiate(monsterObj);
    }

    void OnCollisionEnter(Collision coll)
    {
        int shotValue = coll.transform.GetComponent<Shot>().shotValue;
        TakeDamage(shotValue);
    }

}
