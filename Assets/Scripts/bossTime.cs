using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTime : MonoBehaviour
{
    public Camera mainCam;

    public GameObject RatKing;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Instantiate(RatKing);
            bossCamera functionPlayer = mainCam.GetComponent<bossCamera>();
            functionPlayer.BossCameraMovetoPoint();
        }
        return;
    }
}
