using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingAnimation : MonoBehaviour
{
    private bool canTeleport = false;
    private Animator shipAnimator;
    
    
    void Awake() {
        GameManager.OnGameStateChange += GameManagerOnGameStateChange;

        shipAnimator = GetComponent<Animator>();
    }

    void OnDestroy() {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    }

    private void GameManagerOnGameStateChange(GameState state)
    {
        if(state == GameState.PlayerTeleporting)
        {
            canTeleport = true;

            shipAnimator.SetBool("CanTeleport", true);
        }
    }

}
