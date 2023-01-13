using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/ShipUpgrade")]
public class ShipUpgrade : PowerupEffect
{

    //Currently only switches to redfighter, re-create enum as a string list and use that as the input into the ChangeShip method
    public override void Apply(Game target)
    {
        var gameInstance = target.GetComponent<Game>();

        gameInstance.ChangeShip(Game.Ships.RedFighter);

        Debug.Log("Button press");
    }
}
