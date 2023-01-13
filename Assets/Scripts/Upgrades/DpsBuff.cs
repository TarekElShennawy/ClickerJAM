using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/DPSBuff")]
public class DpsBuff : PowerupEffect
{
    public float amount;

    public override void Apply(Game target)
    {
        target.GetComponent<Game>().damagePerSecond += amount;
    }
}
