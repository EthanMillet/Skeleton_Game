using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatKingLeftHand : MonoBehaviour
{
    public float health;
    public float maxhealth;


    public Rigidbody2D enemyBody;

    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float flashTime = 0.25f;

    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;
    private GameObject player;

    public GameObject singleShot;
    public GameObject multiPoint;
    public float minDamage;
    public float maxDamage;
    public float singleShotForce;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        player = GameObject.Find("Player");
    }

    private void Awake()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        Init();
    }

    private void Init()
    {
        _materials = new Material[_spriteRenderers.Length];

        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _materials[i] = _spriteRenderers[i].material;
        }
    }

    public void DealDamage(float damage, float knockback)
    {
        gameObject.tag = "Immune";

        StartCoroutine(ImmuneAfterHit());
        StartCoroutine(DamageFlasher());
        health -= damage;

        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }

    private IEnumerator ImmuneAfterHit()
    {
        yield return new WaitForSeconds(flashTime);
        gameObject.tag = "Enemy";
    }

    private IEnumerator DamageFlasher()
    {
        SetFlashColor();
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < flashTime)
        {
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime / flashTime));
            setFlashAmount(currentFlashAmount);

            yield return null;
        }
    }

    private void SetFlashColor()
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetColor("_FlashColor", flashColor);
        }
    }

    private void setFlashAmount(float amount)
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetFloat("_FlashAmount", amount);
        }
    }

    public void Slam()
    {

    }

    public void Single()
    {
        if (player != null)
        {
            GameObject spellObject = Instantiate(singleShot, transform.position, Quaternion.identity);
            spellObject.transform.right = player.transform.position - transform.position;
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spellObject.GetComponent<Rigidbody2D>().velocity = direction * singleShotForce;
            spellObject.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }

    public void Multi()
    {
        if (player != null)
        {
            Vector2 myPos = transform.position;
            Vector2 target = multiPoint.transform.Find("Multi_0").position;
            Vector2 target1 = multiPoint.transform.Find("Multi_1").position;
            Vector2 target2 = multiPoint.transform.Find("Multi_2").position;
            Vector2 target3 = multiPoint.transform.Find("Multi_3").position;
            Vector2 target4 = multiPoint.transform.Find("Multi_4").position;
            Vector2 target5 = multiPoint.transform.Find("Multi_5").position;
            Vector2 target6 = multiPoint.transform.Find("Multi_6").position;
            Vector2 target7 = multiPoint.transform.Find("Multi_7").position;
            Vector2 target8 = multiPoint.transform.Find("Multi_8").position;

            GameObject spellObject = Instantiate(singleShot, transform.position, Quaternion.identity);
            Vector2 direction = (target - myPos).normalized;
            spellObject.transform.right = target - myPos;
            spellObject.GetComponent<Rigidbody2D>().velocity = direction * singleShotForce;
            spellObject.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

            GameObject spellObject1 = Instantiate(singleShot, transform.position, Quaternion.identity);
            Vector2 direction1 = (target1 - myPos).normalized;
            spellObject1.transform.right = target1 - myPos;
            spellObject1.GetComponent<Rigidbody2D>().velocity = direction1 * singleShotForce;
            spellObject1.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

            GameObject spellObject2 = Instantiate(singleShot, transform.position, Quaternion.identity);
            Vector2 direction2 = (target2 - myPos).normalized;
            spellObject2.transform.right = target2 - myPos;
            spellObject2.GetComponent<Rigidbody2D>().velocity = direction2 * singleShotForce;
            spellObject2.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

            GameObject spellObject3 = Instantiate(singleShot, transform.position, Quaternion.identity);
            spellObject3.transform.right = target3 - myPos;
            Vector2 direction3 = (target3 - myPos).normalized;
            spellObject3.GetComponent<Rigidbody2D>().velocity = direction3 * singleShotForce;
            spellObject3.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

            GameObject spellObject4 = Instantiate(singleShot, transform.position, Quaternion.identity);
            spellObject4.transform.right = target4 - myPos;
            Vector2 direction4 = (target4 - myPos).normalized;
            spellObject4.GetComponent<Rigidbody2D>().velocity = direction4 * singleShotForce;
            spellObject4.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

            GameObject spellObject5 = Instantiate(singleShot, transform.position, Quaternion.identity);
            spellObject5.transform.right = target5 - myPos;
            Vector2 direction5 = (target5 - myPos).normalized;
            spellObject5.GetComponent<Rigidbody2D>().velocity = direction5 * singleShotForce;
            spellObject5.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

            GameObject spellObject6 = Instantiate(singleShot, transform.position, Quaternion.identity);
            spellObject6.transform.right = target6 - myPos;
            Vector2 direction6 = (target6 - myPos).normalized;
            spellObject6.GetComponent<Rigidbody2D>().velocity = direction6 * singleShotForce;
            spellObject6.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

            GameObject spellObject7 = Instantiate(singleShot, transform.position, Quaternion.identity);
            spellObject7.transform.right = target7 - myPos;
            Vector2 direction7 = (target7 - myPos).normalized;
            spellObject7.GetComponent<Rigidbody2D>().velocity = direction7 * singleShotForce;
            spellObject7.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

            GameObject spellObject8 = Instantiate(singleShot, transform.position, Quaternion.identity);
            spellObject8.transform.right = target8 - myPos;
            Vector2 direction8 = (target8 - myPos).normalized;
            spellObject8.GetComponent<Rigidbody2D>().velocity = direction8 * singleShotForce;
            spellObject8.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
        }

    }

    public void Swipe()
    {

    }
}
