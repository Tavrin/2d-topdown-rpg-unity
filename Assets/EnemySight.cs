using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Transform target;
    public float sightRange;
    Color newColor = new Color(1.0f, 0f, 0f);
    

    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        int layerMask = LayerMask.GetMask("Player") | LayerMask.GetMask("Obstacle");
        Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.magenta, 0.1f);
        var hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position, sightRange, layerMask);
            if(hit && hit.transform.gameObject.name == "Hero")
        {
            Debug.Log("We found Target!");
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }


        else if (hit)
        {
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log(hit.transform.gameObject.name);
            Debug.Log("hit something");
        }
        else
        {
            Debug.Log(hit.rigidbody);
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
