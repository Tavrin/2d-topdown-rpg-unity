using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;
    public Slider HealthBar;

    public float Health = 100;

    private float _currentHealth;

    void Start()
    {
        _currentHealth = Health;
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
       
        matDefault = sr.material;

    }

    // Update is called once per frame
    public void TakeDamage(float damage)

    {
 StartCoroutine(materials());
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        HealthBar.value = _currentHealth;
       


    }
    IEnumerator materials()
    {
        sr.material = matWhite;

         yield return new WaitForSeconds(0.05f);

         sr.material = matDefault;
        yield return new WaitForSeconds(0.05f);
          sr.material = matWhite;

         yield return new WaitForSeconds(0.05f);

         sr.material = matDefault;
    }
}
