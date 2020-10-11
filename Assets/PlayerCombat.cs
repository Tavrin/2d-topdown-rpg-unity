using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int damage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currIdle = animator.GetInteger("CurrentIdle");
        switch (currIdle)
        {
            case 0:
                attackPoint.localPosition= new Vector2 (0, -1);

                break;
            case 1:
                attackPoint.localPosition = new Vector2(0, 0.5f);

                break;
            case 2:
                attackPoint.localPosition = new Vector2(-0.5f, 0);

                break;
            case 3:
                attackPoint.localPosition = new Vector2(0.5f, 0);

                break;
        }
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
      Collider2D[] attackEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);
        
        foreach(Collider2D enemy in attackEnemies)
        {
            Debug.Log(enemy);
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint ==null) {
            return;
                }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
