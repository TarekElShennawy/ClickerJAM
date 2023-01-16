using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Enemy enemyLogic;

    public Image healthBarImage;

    private float healthPercentage;

    public void UpdateHealthbar() {
    healthPercentage = (enemyLogic.currentHealth)/(enemyLogic.startingHealth);
    healthBarImage.fillAmount = healthPercentage;
    }

    void Update()
    {
        if(enemyLogic == null)
        {
            var enemy = GameObject.FindWithTag("Enemy");
            enemyLogic = enemy.GetComponent<Enemy>();
        }
    }
}
