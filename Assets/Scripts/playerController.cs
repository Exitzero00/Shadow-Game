using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{

	private Rigidbody2D myRigidBody;

	//movement variables
	public float movementSpeed;
	public float jumpForce;

	//ground check variables
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	private bool isGrounded;

	// Use this for initialization
	void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () 
	{
		isGrounded = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, groundLayer);
		//space to jump, apply force to y
		if (Input.GetButtonDown("Jump") && isGrounded) 
		{
			myRigidBody.AddForce (new Vector2 (0, jumpForce));
		}

		//Handles left and right movement
		float horizontal = Input.GetAxis ("Horizontal");
		myRigidBody.velocity = new Vector2 (horizontal * movementSpeed, myRigidBody.velocity.y);
	}
}
