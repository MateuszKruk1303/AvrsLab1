using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public CharacterController player;
    public float speed = 10.0f;
    public float gravity = -10.0f;
    public float jumpHeight = 6f;
    public Vector3 velocity;


    public Transform checkGround;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(checkGround.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (!isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            gravity = 0f;
            velocity.y = -1.5f;

        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        player.Move(move * speed * Time.deltaTime);
        player.Move(velocity * Time.deltaTime);
        gravity = -10.0f;

    }
}
