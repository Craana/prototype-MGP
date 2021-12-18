using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class CharacterMoverScript : MonoBehaviour
{
   
	//TODO: Take a RB, make use of it and add jumping, sliding etc to rb mover script. 

 
	[SerializeField] private float playerSpeed = 2.0f;
	[SerializeField] private float jumpForce = 1.0f;
	public bool isJumping = false;
	public bool isSliding = false;
	private BoxCollider boxCollider;
	private Rigidbody rb;
	private Animator animator;
	float distToGround;
	[SerializeField] float verticalMultiplier;
	private string currentAnimaton;
	const string PLAYER_IDLE = "Idle";
	const string PLAYER_RUN = "Run";
	const string PLAYER_SLIDE = "RunningSlide";
	const string PLAYER_JUMP = "Jump";
	int mask = 1 << 6;
 


	// Start is called before the first frame update
	void Start()
	{

		animator = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider>();
		distToGround = boxCollider.bounds.extents.y;
		rb = GetComponent<Rigidbody>();
		InvokeRepeating("AddSpeed", 5f, 10f);
	}


	//fixedupdate here having Vector3 forwardmove transform.forward * speed* time.fixeddeltatime, Vector3 verticalmove = transoform.up * speed * time.fixeddeltatime * verticalMultiplier. rb.moveposition(rb.position + forwardmove + verticalmove);
	 void FixedUpdate()
	{

		Vector3 forwardMove = transform.forward * playerSpeed * Time.deltaTime;
		rb.MovePosition(rb.position + forwardMove);
		if (isSliding == false && isJumping == false && isGrounded())
		{
			ChangeAnimationState(PLAYER_RUN);
			
		}
		jump();
	}

	// Update is called once per frame
	void Update()
	{

		StartCoroutine(Slide());
		SlideChecker();
		//Debug.Log("Am I grounded? " + isGrounded());
		
	}

	void jump()
	{
		if (isJumping == true && isGrounded())
		{
			rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);

			ChangeAnimationState(PLAYER_JUMP);
		}
		else if (!isGrounded())
		{
			isJumping = false;
		}
	}

	void SlideChecker()
	{
			//When sliding happens, it will changes size of boxcollider for small to ensure that character actually doesn't collide with objects
		if (isSliding == true)
		{
			boxCollider.size = new Vector3(1f, 0.50f, 0.39f);
		}
		else
		{
			boxCollider.size = new Vector3(1f, 1.65f, 0.39f);
		}
	}

	IEnumerator Slide()
	{
		//TODO: change the height of the collider smaller so it shows like its doing something

		var clipLength = animator.GetCurrentAnimatorStateInfo(0).length;


		if (isSliding == true && isGrounded())
		{
		   // boxCollider.size = new Vector3(1f, 0.45f, 0.39f);
			ChangeAnimationState(PLAYER_SLIDE);
			yield return new WaitForSeconds(clipLength);
			isSliding = false;
			//boxCollider.size = new Vector3(1f, 1.79f, 0.39f);
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
		return Physics.Raycast(transform.position, -Vector3.up, distToGround, mask);
	}

	void AddSpeed()
	{
		playerSpeed += 1f;
	}

}
