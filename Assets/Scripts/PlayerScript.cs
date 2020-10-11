using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public InventoryObject inventory;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.F5))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            inventory.Load();
        }



        if (Input.GetMouseButtonDown(0))
        {

            var data = getDistanceOnClick();
            if(data != null)
            {
                var currentObj = data.Value.obj;
                var currentDist = data.Value.dist;
                if(currentObj.CompareTag("Chest") && currentDist <= 2f)
                {
                    var item = currentObj.GetComponent<ChestLoot>();
                    if (item)
                    {
                        inventory.addItem(item.item, 1);
                        Destroy(currentObj);
                    }
                }
                ;
            }
            
           
        }

    }
    private (float dist,GameObject obj)? getDistanceOnClick()
    { 
        
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
            {
            var currentObj = hit.collider.gameObject;
            float dist = Vector2.Distance(hit.collider.gameObject.transform.position, this.transform.position);
            


            return (dist, currentObj);

            }
        return (null);
        
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}


