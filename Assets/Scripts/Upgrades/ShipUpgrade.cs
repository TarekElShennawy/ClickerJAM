using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/ShipUpgrade")]
public class ShipUpgrade : PowerupEffect
{
    public string shipName;

    public override void Apply(Game target)
    {
        var gameInstance = target.GetComponent<Game>();

        switch(shipName)
        {
            case "Fighter":
                gameInstance.ChangeShip(Game.Ships.Fighter);
                break;
            case "Trooper":
                gameInstance.ChangeShip(Game.Ships.Trooper);
                break;
            case "Meteor":
                gameInstance.ChangeShip(Game.Ships.Meteor);;
                break;
        }
    }
}
