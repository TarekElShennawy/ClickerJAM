using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChange;

    [SerializeField]
    private List<Sprite> planetList;

    [SerializeField]
    private List<Sprite> backgroundList;

    [SerializeField]
    private SpriteRenderer planetSprite;

    [SerializeField]
    private SpriteRenderer backgroundSprite;

    [SerializeField]
    private List<GameObject> enemyList;

    private int dimensionIterator;

    void Awake()
    {
        Instance = this;

        dimensionIterator = 0;
    }

    void Start()
    {
        UpdateGameState(GameState.NewBoss);
    }
    
    //Possibly start with the boss spawning THEN playerShooting phase! (Ensure first boss isn't already in the scene and spawning through GameStates using Enums)
    
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState) {
            case GameState.NewBoss:
                SpawnBoss();
                break;
            case GameState.PlayerShooting:
                break;
            case GameState.PlayerTeleporting:
                break;
            case GameState.DimensionChanging:
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

    private void ChangeDimension()
    {
        //Logic for switching background + planets

        if(dimensionIterator < planetList.Count)
        {
            planetSprite.sprite = planetList[dimensionIterator];
            backgroundSprite.sprite = backgroundList[dimensionIterator];
            
            dimensionIterator++;
            GameManager.Instance.UpdateGameState(GameState.NewBoss);
        }
        else
        {
            GameManager.Instance.UpdateGameState(GameState.WinState);
        } 
    }

    private void SpawnBoss()
    {

        if(dimensionIterator < enemyList.Count)
        {
            GameObject enemy = enemyList[dimensionIterator];

            GameObject newEnemy = Instantiate(enemy, enemy.transform.position, enemy.transform.rotation);

            newEnemy.name = enemy.name;

            GameManager.Instance.UpdateGameState(GameState.PlayerShooting);
        }
        
    }

    private void WinScreen()
    {
        Debug.Log("You Win!");
    }
}

public enum GameState{
    PlayerShooting,
    PlayerTeleporting,
    DimensionChanging,
    NewBoss,
    WinState
}