using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    private Rigidbody2D powerupBody;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    { 
        if (PlayerMove.facingRight)
            direction = new Vector3(-3, 0, 0);
        else
            direction = new Vector3(3, 0, 0);

        powerupBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "WallLeft")
        {
            Vector3 temp = direction;
            temp.x *= -1;
            direction = temp;
        }
        else if (collision.gameObject.tag == "WallRight")
        {
            Vector3 temp = direction;
            temp.x = Mathf.Abs(temp.x);
            direction = temp;
        }
        else if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
