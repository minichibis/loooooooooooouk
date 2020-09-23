/*
* (Greg Brandt)
* (Project 2)
* Allows the player to respond to input
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;
	[SerializeField] float jumpForce = 1;
	[SerializeField] float fallingVelocityJumpThreshold = 0.2f;
	[SerializeField] bool isBlock;
	public Vector2 velocity;
	public bool isPlayable = false;

	private void Start()
	{
		if(!isBlock) { isPlayable = true; }
	}


	//Compensates for the height of the collider 
	float distToGround;

	Rigidbody2D rigidbody;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
	}

	private void Update()
	{
		if (isPlayable)
		{
			//Move Left and Right
			float horizontalInput = Input.GetAxis("Horizontal");
			transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
		}
	}

	private void FixedUpdate()
	{
		//Jump
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isBlock)
		{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	//Checks if there is a collider under the player
	bool IsGrounded()
	{
		RaycastHit2D hit =  Physics2D.Raycast(transform.position - new Vector3(0, distToGround + 0.1f, 0), -Vector3.up, 0.5f);
		if (hit)
		{
			Debug.Log(hit.collider.tag);
			if (!hit.collider.CompareTag("Player")) { return hit; }
			else { return false; }
		}
		return false;
	}
}
