using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDamage : MonoBehaviour
{
    // Start is called before the first frame update

     private GameObject _player;

    private bool _collidedWithPlayer;

    private float lastDamage;

    public float attackRate = 1f;
    public int damage;
    float nextAttackTime = 0f;
    public bool stayDamage;

    void Start()
    {
         _player = GameObject.FindGameObjectWithTag("Player");
    }


 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _player)
        {
            if (Time.time >= nextAttackTime)
            {
                //print("test player");
                _collidedWithPlayer = true;
                _player.GetComponent<PlayerHealth>().TakeDamage(damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        //print("enter trigger with _player");
    }



void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == _player)
        {
           //print("test out player");
           _collidedWithPlayer = false;
        }
        //print("exit trigger with _player");
    }
    // Update is called once per frame

    
//     private void Update(){
// Attack();
//     }
    
    
     void FixedUpdate()
 {
     if (lastDamage >= 1)
     {
         lastDamage = 0;
     }
     lastDamage += Time.fixedDeltaTime;
 }
 
 void OnTriggerStay2D(Collider2D other)
 {
        if(stayDamage == true)
        {
            if (Time.time >= nextAttackTime)
            {
                print(lastDamage);

                if (_player != null && lastDamage >= 1)
                {

                    //print("test if trigger");
                    _player.GetComponent<PlayerHealth>().TakeDamage(damage);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
   
 }
//     private void Attack()
//     {
        
//         if (_collidedWithPlayer && _player.GetComponent<PlayerHealth>().HealthBar.value >= 10)
//         {  
//             _player.GetComponent<PlayerHealth>().TakeDamage(10);
//         }
//     }
}
