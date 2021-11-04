using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoverScript : MonoBehaviour
{
   
    private Vector3 playerVelocity = Vector3.zero;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    public bool isJumping = false;
    private BoxCollider boxCollider;
    float distToGround;
    

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        distToGround = boxCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity = new Vector3(0,0,playerSpeed);

        gameObject.transform.Translate(playerVelocity * Time.deltaTime);
        playerVelocity.y += gravityValue * Time.deltaTime;

        jump();
        Slide();
    }

    void jump()
    {
        if (isJumping == true && isGrounded())
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        else if (!isGrounded())
        {
            isJumping = false;
        }
    }

    void Slide()
    {

    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }

}
