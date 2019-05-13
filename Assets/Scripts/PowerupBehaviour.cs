using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    private Rigidbody2D powerupBody;
    private Vector3 direction;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = PlayerMove.facingRight;
        if (facingRight)
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
        facingRight = !facingRight;

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {

        }
        else
        {
            Vector3 temp = direction;
            if ((temp.x / Mathf.Abs(temp.x)) == -1)
                temp.x = Mathf.Abs(temp.x);
            else
                temp.x *= -1;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            direction = temp;
        }
    }
}
