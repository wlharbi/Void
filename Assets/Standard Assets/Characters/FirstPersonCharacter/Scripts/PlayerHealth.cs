﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    FirstPersonController playerController;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;


    void Awake()
    {
        //anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerController = GetComponent<FirstPersonController>();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //TakeDamage(10);
        }
            
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects ();

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerController.Die();
        //playerShooting.enabled = false;
    }


    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
