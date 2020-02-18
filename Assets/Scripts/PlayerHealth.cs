using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float totalHealth = 100f;

    float currentHealth;

    public Image healthBar;

    [SerializeField] Canvas hitImage;
    [SerializeField] float hitImageTime;
    [SerializeField] AudioClip bloodSpaltSFX;

    // Start is called before the first frame update
    void Start()
    {
        hitImage.enabled = false;
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0f)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        healthBar.fillAmount = currentHealth / totalHealth;
        StopAllCoroutines();
        StartCoroutine(DisplayDamage());
        AudioSource.PlayClipAtPoint(bloodSpaltSFX, transform.position);
    }

    IEnumerator DisplayDamage()
    {
        hitImage.enabled = true;
        yield return new WaitForSeconds(hitImageTime);
        hitImage.enabled = false;
    }

}
