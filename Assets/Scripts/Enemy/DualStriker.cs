using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualStriker : Enemy
{
    void Awake() {
        GameManager.OnGameStateChange += GameManagerOnGameStateChange;
    }

    void OnDestroy() {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    }

    private void GameManagerOnGameStateChange(GameState state)
    {
        if(state == GameState.PlayerTeleporting)
        {
            SpawnPortal();
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        TakeDamage(1);
    }
}
