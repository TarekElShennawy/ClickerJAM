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
    
    [SerializeField]
    private Image healthBarImage;

    private float healthPercentage;

    private AudioSource audioSrc;

    public AudioClip explosionSfx;

    public GameObject monsterObj;

    public GameObject bossObj;

    public List<Sprite> monsterSprites;

    void Start()
    {
        currentHealth = startingHealth;
        
        healthBarParent = GameObject.FindGameObjectWithTag("Healthbar");

        audioSrc = GameObject.Find("Game").GetComponent<AudioSource>();
 
        healthBarImage = GameObject.FindGameObjectWithTag("HealthbarInner").GetComponent<Image>(); //Such an expensive method but not fatal as it's a small game + time constraints

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

            GameObject bossInstance = Instantiate(bossObj);

            bossInstance.GetComponent<Rigidbody>().AddForce(Vector3.up * 4000);
            
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
        //Getting random direction to shoot monster
        Vector2 direction = new Vector2((float)Random.Range(-1,1), (float)Random.Range(-5,5));

        //Swapping monster GameObject's sprite for one from the list of sprites to throw out random monsters
        int monsterPicker = Random.Range(0, monsterSprites.Count - 1);

        GameObject monsterInstance = Instantiate(monsterObj);

        monsterInstance.GetComponent<SpriteRenderer>().sprite = monsterSprites[monsterPicker];
        monsterInstance.GetComponent<Rigidbody>().AddForce(direction * 4000);
    }

    void OnCollisionEnter(Collision coll)
    {
        int shotValue = coll.transform.GetComponent<Shot>().shotValue;
        TakeDamage(shotValue);
    }

}
