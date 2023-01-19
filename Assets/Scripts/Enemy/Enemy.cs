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

    public List<Sprite> monsterSprites;

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
        //Getting random direction to shoot monster
        Vector2 direction = new Vector2((float)Random.Range(-1,1), (float)Random.Range(-5,5));

        //Swapping monster GameObject's sprite for one from the list of sprites to throw out random monsters
        int monsterPicker = Random.Range(0, monsterSprites.Count - 1);
        monsterObj.GetComponent<SpriteRenderer>().sprite = monsterSprites[monsterPicker];

        GameObject monsterInstance = Instantiate(monsterObj);

        monsterInstance.GetComponent<Rigidbody>().AddForce(direction * 4000);
    }

    void OnCollisionEnter(Collision coll)
    {
        int shotValue = coll.transform.GetComponent<Shot>().shotValue;
        TakeDamage(shotValue);
    }

}
