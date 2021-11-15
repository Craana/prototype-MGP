using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoverScript : MonoBehaviour
{
   
    //TODO: Take a RB, make use of it and add jumping, sliding etc to rb mover script. 

 
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpForce = 1.0f;
      public bool isJumping = false;
    public bool isSliding = false;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;
    private Animator animator;
    float distToGround;
    [SerializeField] float verticalMultiplier;
    private string currentAnimaton;
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_RUN = "Run";
    const string PLAYER_SLIDE = "RunningSlide";
    const string PLAYER_JUMP = "Jump";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        distToGround = capsuleCollider.bounds.extents.y;
        rb = GetComponent<Rigidbody>();
    }


    //fixedupdate here having Vector3 forwardmove transform.forward * speed* time.fixeddeltatime, Vector3 verticalmove = transoform.up * speed * time.fixeddeltatime * verticalMultiplier. rb.moveposition(rb.position + forwardmove + verticalmove);
     void FixedUpdate()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMove = transform.forward * playerSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);
        jump();
        StartCoroutine(Slide());
    }

    void jump()
    {
        if (isJumping == true && isGrounded())
        {
            rb.AddForce(transform.up * jumpForce);
        }
        else if (!isGrounded())
        {
            isJumping = false;
        }
    }

    IEnumerator Slide()
    {
        //TODO: change the height of the collider smaller so it shows like its doing something

        var clipLength = animator.GetCurrentAnimatorStateInfo(0).length;


        if (isSliding == true && isGrounded())
        {
            ChangeAnimationState(PLAYER_SLIDE);
            yield return new WaitForSeconds(clipLength);
            isSliding = false;
        }

    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }

}
