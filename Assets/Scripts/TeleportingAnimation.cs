using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingAnimation : MonoBehaviour
{
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
            shipAnimator.SetBool("CanTeleport", true);
            
            Invoke("CallChangeDimension", 1f);
            
        }
    }

    private void CallChangeDimension()
    {
        shipAnimator.SetBool("CanTeleport", false);
        
        GameManager.Instance.UpdateGameState(GameState.DimensionChanging);
    }   

}
