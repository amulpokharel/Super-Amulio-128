using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    private Rigidbody2D enemyBody;
    private Vector3 direction;
    public bool facingRight;

    private bool visible;

    // Start is called before the first frame update
    void Start()
    {
        if (facingRight)
        {
            direction = new Vector3(2, 0, 0);
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else
        {
            direction = new Vector3(-2, 0, 0);
        }


        visible = false;
        enemyBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (visible)
        {
            transform.Translate(direction * Time.deltaTime);
        }

    }

    void OnBecameVisible()
    {
        visible = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        facingRight = !facingRight;

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
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
