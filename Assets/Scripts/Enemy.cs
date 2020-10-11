using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public float maxHealth;
    public float currentHealth;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;


    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;

        matDefault = sr.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(materials());

        Debug.Log(damage);
        currentHealth -= damage;
        Debug.Log("enemy health : " + currentHealth);
        if(currentHealth <= 0)
        {
            Debug.Log("killed enemy");
            Die();
        }
    }

    void Die()
    {
        Destroy(transform.gameObject);
    }

    IEnumerator materials()
    {
        sr.material = matWhite;

        yield return new WaitForSeconds(0.05f);

        sr.material = matDefault;
    }
    }
