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
    public bool isJumping = false;
    private Animator animator;
    private string currentAnimaton;
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_RUN = "Run";
    const string PLAYER_SLIDE = "RunningSlide";
    const string PLAYER_JUMP = "Jump";

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
     
    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(0, 0, playerSpeed);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        if (playerSpeed > 0.1f && groundedPlayer && isJumping == false)
        {
            ChangeAnimationState(PLAYER_RUN);
            
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
                 ChangeAnimationState(PLAYER_JUMP);
         }
            isJumping = false;
     }


    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }


    public void Slide()
    {
        
    }
}
