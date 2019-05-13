using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlockBehaviour : MonoBehaviour
{
    public GameObject coin;
    public AudioClip audioClip;
    public AudioClip emptyBlock;
    public Animator animator;
    public int numCoins;

    private AudioSource audioSource;

    void Start(){
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D c){
        Vector3 position = transform.position;
        position.y += 2;
        if ((c.collider.bounds.max.y < transform.position.y) && c.collider.tag == "Player"){
            if (numCoins >= 1)
            {
                audioSource.PlayOneShot(audioClip);
                GameObject temp = (GameObject)Instantiate(coin, position, Quaternion.identity);
                Object.Destroy(temp, 0.25F);
                PlayerMove.totalCoins++;
                numCoins--;
                if(numCoins == 0)
                    animator.SetBool("used", true);
            }
            else
            {
                audioSource.PlayOneShot(emptyBlock);
            }
            
        }
            
    }
}
