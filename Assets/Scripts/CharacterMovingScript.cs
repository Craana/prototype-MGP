using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovingScript : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] public bool isJumping = false;
    [SerializeField] public bool isSliding = false;
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
        controller.detectCollisions = false;

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
        if (playerSpeed > 0.1f && groundedPlayer && isSliding == false)
        {
            ChangeAnimationState(PLAYER_RUN);

        }
        jump();
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        StartCoroutine(Slide());

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


    IEnumerator Slide()
    {
        //TODO: change the height of the collider smaller so it shows like its doing something

        var clipLength = animator.GetCurrentAnimatorStateInfo(0).length;

        if (isSliding == true && groundedPlayer)
        {
            ChangeAnimationState(PLAYER_SLIDE);
            yield return new WaitForSeconds(clipLength);
            isSliding = false;
        }

    }
}
