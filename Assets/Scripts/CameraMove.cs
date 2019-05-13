using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector2 velocity;
    public float adjustCameraSpeed;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void FixedUpdate()
    {
        float positionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, adjustCameraSpeed);

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
    }
}
