using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    public int maxHealth = 100;
    [SerializeField] private Slider healthSlider;
    private float cooldown = 100f;
    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = 100;
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        currentTime -= Time.time;
    }

    public void TakeDamage(int damage)
    {
        if (currentTime > 0)
            return;

        health -= damage;
        healthSlider.value = health;
        currentTime = cooldown;

        if(health <= 0)
            SceneManager.LoadScene("MainMenu");
    }
}
