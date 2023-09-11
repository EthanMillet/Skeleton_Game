using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStat : MonoBehaviour
{
    public static PlayerStat playerStats;
    public GameObject player;

    public float health;
    public float maxhealth;
    public float dashValue;
    public float coins;
    public float maxCoins = 999;


    public TextMeshProUGUI coinText;
    public GameObject healthBar;
    public Slider healthbarSlider;

    public Slider dashBar;

    private void Awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }
        else {
            playerStats = this;
        }
        DontDestroyOnLoad(playerStats);
    }

    void Start()
    {
        health = maxhealth;
        DashChecker(1);
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        healthbarSlider.value = CalculateHealthPercentage();
    }

    public void DashChecker(int dashValue)
    {
            dashBar.value = dashValue;
    }

    public void HealCharacteer(float heal)
    {
        health += heal;
        CheckOverheal();
    }

    private void CheckOverheal()
    {
        if (health > maxhealth)
        {
            health = maxhealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(player);
        }
    }

    private float CalculateHealthPercentage()
    {
        return health / maxhealth;
    }
}
