using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //GameEvents.current.onChestClick += OnChestClickOpen;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null && hit.collider == hit.collider.gameObject.CompareTag("Chest"))
            {
                isAnimating = !isAnimating; // because "true = !false" and vice versa
                animator.SetBool("openChest", isAnimating);
            }
        }

    }
    private void OnChestClickOpen()
    {
        animator.SetBool("openChest", isAnimating);
    }

}
