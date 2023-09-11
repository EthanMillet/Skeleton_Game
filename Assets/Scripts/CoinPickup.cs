using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinPickup : MonoBehaviour
{
    public static PlayerStat playerStats;
   
    public float coinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerStat.playerStats.coins < PlayerStat.playerStats.maxCoins) 
            {
                PlayerStat.playerStats.coins += coinValue;
                string CoinAmount = PlayerStat.playerStats.coins.ToString();
                PlayerStat.playerStats.coinText.SetText(CoinAmount); 
                Destroy(this.gameObject);
            }
            
        }
            
    }

}
