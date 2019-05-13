using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBlockBehaviour : MonoBehaviour{
    
    public AudioClip audioClip;
    public AudioClip emptyBlock;

    public GameObject powerup;
    public Animator animator;
    public bool hasPowerup;

    private AudioSource audioSource;

    void Start()
    {
        hasPowerup = true;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Vector3 position = transform.position;
        position.y += 1;
        if ((c.collider.bounds.max.y < transform.position.y) && c.collider.tag == "Player")
        {
            if (hasPowerup)
            {
                audioSource.PlayOneShot(audioClip);
                GameObject temp = (GameObject)Instantiate(powerup, position, Quaternion.identity);
                hasPowerup = false;
                animator.SetBool("used", true);
            }
            else
                audioSource.PlayOneShot(emptyBlock);

        }

    }
}
