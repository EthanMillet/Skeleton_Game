using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class EnemyRecieveDamage : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public float dropForce;
    public float knockBackforce;

    public GameObject coin;
    public GameObject player;
    public Rigidbody2D enemyBody;

    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float flashTime = 0.25f;

    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;

    private Coroutine _damageFlashCoroutine;

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

        Vector2 hitDirection = (transform.position - player.transform.position).normalized;
        StartCoroutine(ImmuneAfterHit());
        CallDamageFlash();
        health -= damage;
        
        CheckDeath();
        enemyBody.velocity = new Vector2(hitDirection.x, hitDirection.y) * knockback;
    }

    private void CheckOverheal()
    {
        if (health > maxhealth) { 
        health = maxhealth;}
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            for(int i = 0;  i < Random.Range(1, 5); i++ )
            {
                GameObject loot = Instantiate(coin, transform.position, Quaternion.identity);
                Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                loot.GetComponent<Rigidbody2D>().velocity = new Vector2(dropDirection.x, dropDirection.y) * dropForce;
            }
            
        }
    }

    private IEnumerator ImmuneAfterHit()
    {
        yield return new WaitForSeconds(flashTime);
        gameObject.tag = "Enemy";
    }

    public void CallDamageFlash()
    {
        _damageFlashCoroutine = StartCoroutine(DamageFlasher()); 
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
}
