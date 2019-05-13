using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D characterBody;
    public float characterSpeed;
    public float characterJumpSpeed;
    public Animator animator;
    public AudioClip jumpSfx;
    public AudioClip hurtSfx;
    public AudioClip deathSfx;
    public AudioClip powerUpSfx;
    public AudioClip oneUpSfx;
    public bool poweredUp;
    public int powerupPhase;
    public bool allowEndlessJump;

    //statics
    public static bool facingRight;
    public static int totalCoins;
    public static int currentLives;
    public static string levelName;

    private AudioSource audioSource;
    private float actualSpeed;
    private bool grounded;
    private bool jumping;
    private bool dead;
    private bool sfxPlayed;
    

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        characterBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        jumping = false;
        facingRight = true;
        dead = false;
        sfxPlayed = false;
        poweredUp = false;
        powerupPhase = 0;
        grounded = true;
    }

    // Update is called once per frame
    void Update() {

        float movement = Input.GetAxisRaw("Horizontal");

        //checks if char is jumping
        if (Input.GetKeyDown("space") && grounded)
            CharacterJump();

        if (Input.GetKeyDown("escape"))
        {
            audioSource.PlayOneShot(deathSfx);
            Application.Quit();
        }

        //checks movement direction, and flips the boolean accordingly
        if ((movement > 0) && !facingRight)
            Flip();
        else if (movement < 0 && facingRight)
            Flip();

        //calculate the speed
        if (movement != 0)
        {
            actualSpeed = Mathf.Lerp(characterBody.velocity.x, movement * characterSpeed * Time.deltaTime, Time.deltaTime * 10);

            //apply the velocity to the rigidbody
            animator.SetFloat("speed", Mathf.Abs(movement));  //changes animation, whether going left or right
            characterBody.velocity = new Vector2(actualSpeed, characterBody.velocity.y);
        }
        else
        {
            animator.SetFloat("speed",0);  //changes animation, whether going left or right
        }

        if ((!sfxPlayed) && (transform.position.y < -4))
        {
            audioSource.PlayOneShot(deathSfx);
            currentLives--;

            sfxPlayed = true;
        }

        if (transform.position.y < -12)
        {
            if(currentLives < 1)
                SceneManager.LoadScene("GameOver");
            else
                SceneManager.LoadScene("LevelTransitionScreen");
        }
    }

    //jump function
    private void CharacterJump(){
        if (!jumping){
            jumping = true;
            audioSource.PlayOneShot(jumpSfx);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * characterJumpSpeed, ForceMode2D.Impulse);
        }

        jumping = false;
    }
    
    //flip function
    private void Flip(){
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MushroomPowerup")
        {
            if (poweredUp && (powerupPhase < 1))
            {
                powerupPhase += 1;
            }
            else
            {
                poweredUp = true;
                powerupPhase = 1;
                audioSource.PlayOneShot(powerUpSfx);
            }
            animator.SetInteger("powerUpState", Mathf.Abs(powerupPhase));
        }
        else if(collision.gameObject.tag == "OneupPowerup")
        {
            currentLives++;
            audioSource.PlayOneShot(oneUpSfx);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            if (!allowEndlessJump)
            {
                grounded = true;
            }
         }
        else if(collision.gameObject.tag == "Enemy")
        {
            if(powerupPhase == 1)
            {
                powerupPhase--;
                animator.SetInteger("powerUpState", Mathf.Abs(powerupPhase));
                audioSource.PlayOneShot(hurtSfx);
            }
            else
            {
                animator.SetInteger("powerUpState", Mathf.Abs(powerupPhase));
                audioSource.PlayOneShot(deathSfx);
                currentLives--;
                if(currentLives < 1)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                    SceneManager.LoadScene("LevelTransitionScreen");
                }
            }

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (!allowEndlessJump)
            {
                grounded = false;
            }
        }
    }

}
