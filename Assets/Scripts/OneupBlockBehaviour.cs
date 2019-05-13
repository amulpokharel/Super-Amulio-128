using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneupBlockBehaviour : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioClip emptyBlock;

    public GameObject oneUp;
    public Animator animator;
    public bool hasOneup;
    public bool isInvisible;

    private AudioSource audioSource;

    void Start()
    {
        hasOneup = true;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetBool("invisible", isInvisible);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Vector3 position = transform.position;
        position.y += 1;
        if ((c.collider.bounds.max.y < transform.position.y) && c.collider.tag == "Player")
        {
            if (hasOneup)
            {
                audioSource.PlayOneShot(audioClip);
                GameObject temp = (GameObject)Instantiate(oneUp, position, Quaternion.identity);
                hasOneup = false;
                animator.SetBool("used", true);
            }
            else
                audioSource.PlayOneShot(emptyBlock);
        }

    }
}
