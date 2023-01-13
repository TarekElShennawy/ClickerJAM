using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChange;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.PlayerShooting);
    }
    
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState) {
            case GameState.PlayerShooting:
                break;
            case GameState.PlayerTeleporting:
                HandleTeleport();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChange?.Invoke(newState);
    }

    private void HandleTeleport()
    {
        Debug.Log("Teleporting!");
        //Logic for switching background and "dimensions"
    }
}

public enum GameState{
    PlayerShooting,
    PlayerTeleporting
}