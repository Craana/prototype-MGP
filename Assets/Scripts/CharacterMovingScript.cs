using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovingScript : MonoBehaviour
{

                 [SerializeField]  private CharacterController controller;
                    private Vector3 playerVelocity;
                     private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] float forwardSpeed;
    public bool isJumping = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(0, 0, forwardSpeed);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        jump();
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        Slide();
    }

   public void jump()
    {
        if (isJumping == true && groundedPlayer)
            {
              playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
         }
        isJumping = false;
     }

    public void Slide()
    {

    }
}
