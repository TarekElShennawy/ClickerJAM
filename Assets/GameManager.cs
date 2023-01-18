using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyList;

    private GameObject currentEnemy;

    //Variables for state management
    [SerializeField]
    private Game gameController;

    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChange;

    private int dimensionIterator;

    public GameObject winScreen;

    [Header("Sprite Lists")]
    [SerializeField]
    private List<Sprite> planetList;

    [SerializeField]
    private List<Sprite> backgroundList;

    [SerializeField]
    private SpriteRenderer planetSprite;

    [SerializeField]
    private SpriteRenderer backgroundSprite;

    [Header("Audio variables")]
    public List<AudioClip> bgmList;

    public AudioSource audioSrc;

    public AudioClip teleportSfx;

    [Header("UI + Effects")]

    [SerializeField]
    private TextMeshProUGUI totalDamageText;

    public GameObject lightSpeed;

    //Dimension achievement icons
    public List<Image> dimensionAchievementIcons;

    

    void Awake()
    {
        Instance = this;

        dimensionIterator = 0;

        lightSpeed.SetActive(false);
        winScreen.SetActive(false);
    }

    void Start()
    {
        UpdateGameState(GameState.NewBoss);
        UnlockAchievement(dimensionAchievementIcons[dimensionIterator]);

    }
    
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState) {
            case GameState.NewBoss:
                SpawnBoss();
                PlayBGM();
                break;
            case GameState.PlayerShooting:
                break;
            case GameState.PlayerTeleporting:
                lightSpeed.SetActive(true);
                audioSrc.PlayOneShot(teleportSfx);
                break;
            case GameState.DimensionChanging:
                lightSpeed.SetActive(false);
                ChangeDimension();
                break;
            case GameState.WinState:
                WinScreen();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChange?.Invoke(newState);
    }


    private void PlayBGM()
    {
        audioSrc.clip = bgmList[dimensionIterator];
        audioSrc.Play();
    }

    private void ChangeDimension()
    {
        //Logic for switching background + planets
        if(dimensionIterator < planetList.Count)
        {
            planetSprite.sprite = planetList[dimensionIterator];
            backgroundSprite.sprite = backgroundList[dimensionIterator];
            
            dimensionIterator++;
            
            UnlockAchievement(dimensionAchievementIcons[dimensionIterator]);
            GameManager.Instance.UpdateGameState(GameState.NewBoss);
        }
        else if(dimensionIterator > planetList.Count)
        {
            GameManager.Instance.UpdateGameState(GameState.WinState);
        }

    }

    private void SpawnBoss()
    {

        if(dimensionIterator < enemyList.Count)
        {
            GameObject enemy = enemyList[dimensionIterator];

            currentEnemy = Instantiate(enemy, enemy.transform.position, enemy.transform.rotation);

            currentEnemy.name = enemy.name;

            GameManager.Instance.UpdateGameState(GameState.PlayerShooting);
        }
        
    }

    private void WinScreen()
    {   
        winScreen.SetActive(true);
        totalDamageText.text = "Total Damage : " + gameController.totalDamage.ToString();
    }

    void UnlockAchievement(Image icon)
    {
        var unlockedAchievement = icon.color;
        unlockedAchievement.a = 1f;
        icon.color = unlockedAchievement;
    }
}

public enum GameState{
    PlayerShooting,
    PlayerTeleporting,
    DimensionChanging,
    NewBoss,
    WinState
}