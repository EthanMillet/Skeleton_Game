using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RatKingController : MonoBehaviour
{
    public static RatKingController bossStats;
    public GameObject RatKing;
    public GameObject handRight;
    public GameObject handLeft;

    public float health;
    public float maxhealth;
    private float attackDelay;
    public float fightStartDelay;

    private void Awake()
    {
        if (bossStats != null)
        {
            Destroy(bossStats);
        }
        else
        {
            bossStats = this;
        }
        DontDestroyOnLoad(bossStats);
    }

    void Start()
    {
        health = maxhealth;
        StartCoroutine(startFight());
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
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
            Destroy(RatKing);
        }
    }



    private void ExecuteAttackRightHand()
    {
        if (handRight == null)
        {
            return;
        }
        int rand = UnityEngine.Random.Range(-1, 101);
        Debug.Log("Right" + rand);

        if (rand > 90) 
            {
            handSwipeRight(handRight);
            } 
                else if (rand > 40 && rand <=89)
            {
                SingleRepeatingShot(handRight);
            } 
                else if (rand > 20 && rand <= 39 )
            {
                multiShot(handRight);
            } else
            {
            HandSlam(handRight);
            }
        StartCoroutine(HandAttackDelayRight());
    }

    private void ExecuteAttackLefttHand()
    {
        if(handLeft == null)
        {
            return;
        }
        int rand = UnityEngine.Random.Range(-1, 101);
        Debug.Log("Left" + rand);

        if (rand > 90)
        {
            handSwipeLeft(handLeft);
        }
        else if (rand > 40 && rand <= 89)
        {
            SingleRepeatingShot(handLeft);
        }
        else if (rand > 20 && rand <= 39)
        {
            multiShot(handLeft);
        }
        else
        {
            HandSlam(handLeft);
        }
        StartCoroutine(HandAttackDelayLeft());
    }

    private void HandSlam(GameObject hand)
    {
        Debug.Log("Hand Slam");
        if (hand == handRight)
        {
            handRight.GetComponent<RatKingRightHand>().Multi();
        }
        else
        {
            handLeft.GetComponent<RatKingLeftHand>().Multi();
        }
    }

    private void SingleRepeatingShot(GameObject hand)
    {
        Debug.Log("Single Repeating Shot");
        if(hand == handRight)
        {
            handRight.GetComponent<RatKingRightHand>().Single();
        } else
        {
            handLeft.GetComponent<RatKingLeftHand>().Single();
        }
    }

    private void multiShot(GameObject hand)
    {
        Debug.Log("Multi Shot");
        if (hand == handRight)
        {
            handRight.GetComponent<RatKingRightHand>().Multi(); 
        }
        else
        {
            handLeft.GetComponent<RatKingLeftHand>().Multi();
        }
    }
    private void handSwipeRight(GameObject hand)
    {
        Debug.Log("hand Swipe Right");
        if (hand == handRight)
        {
            handRight.GetComponent<RatKingRightHand>().Multi();
        }
        else
        {
            handLeft.GetComponent<RatKingLeftHand>().Multi();
        }   
    }

    private void handSwipeLeft(GameObject hand)
    {
        Debug.Log("Hand Swipe Left");
        if (hand == handRight)
        {
            handRight.GetComponent<RatKingRightHand>().Multi();
        }
        else
        {
            handLeft.GetComponent<RatKingLeftHand>().Multi();
        }
    }

    private IEnumerator startFight()
    {        
        yield return new WaitForSeconds(fightStartDelay);
        ExecuteAttackRightHand();
        ExecuteAttackLefttHand();
    }

    private IEnumerator HandAttackDelayRight()
    {
        attackDelay = UnityEngine.Random.Range(2, 6);
        yield return new WaitForSeconds(attackDelay);
        ExecuteAttackRightHand();
    }

    private IEnumerator HandAttackDelayLeft()
    {
        attackDelay = UnityEngine.Random.Range(2, 6);
        yield return new WaitForSeconds(attackDelay);
        ExecuteAttackLefttHand();
    }

}
