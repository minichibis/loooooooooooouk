/*
* (Greg Brandt, Sam Carpenter)
* (Project 2)
* Allows the player to respond to input
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;
	[SerializeField] float jumpForce = 1;
	[SerializeField] float fallingVelocityJumpThreshold = 0.2f;
	//[SerializeField] bool isBlock;
	public Vector2 velocity;
	public bool isPlayable = true;
	
	public int coyoteframes = 0;
	public int coyotethresh = 3;
	
	public int gravy = 3;

	private void Start()
	{
		//if(!isBlock) { isPlayable = true; }
	}


	//Compensates for the height of the collider 
	float distToGround = 1.15f;

	Rigidbody2D rigidbody;
	public Tilemap pinktiles;
	public Tilemap greytiles;

	private void Awake()
	{
		rigidbody =  GetComponentInChildren<Rigidbody2D>();
		//distToGround = GetComponent<Collider2D>().bounds.extents.y;
	}

	private void Update()
	{
		if (isPlayable)
		{
			//Move Left and Right
			float horizontalInput = Input.GetAxis("Horizontal");
			transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
			//for use with transforming
			rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
			rigidbody.gravityScale = gravy;
			pinktiles.color = Color.white;
			greytiles.color = Color.clear;
		} else{
			//for use with transforming
			rigidbody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
			rigidbody.gravityScale = 0;
			pinktiles.color = Color.clear;
			greytiles.color = Color.white;
		}
	}
	
	//variable for testing purposes. expendable
	public bool canTransform = true;

	private void FixedUpdate()
	{
		bool g = IsGrounded();
		//Jump
		if (Input.GetKeyDown(KeyCode.Space) && isPlayable && (g || coyoteframes <= coyotethresh))
		{
			rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			coyoteframes = coyotethresh + 1;
		}
		
		if(!g){
			coyoteframes++;
		} else{
			coyoteframes = 0;
		}
		
		if (Input.GetKeyDown(KeyCode.Z) && canTransform) isPlayable = !isPlayable;
	}

	//Checks if there is a collider under the player
	bool IsGrounded()
	{
		RaycastHit2D[] hitsys = new RaycastHit2D[999];
		int hitnum = rigidbody.Cast(Vector2.down, hitsys, distToGround);
		if (hitnum > 0){
			//Debug.Log(hit.collider.tag);
			//if (!hit.collider.CompareTag("Player")) { return hit; }
			//else { return false; }
			return true;
		}
		return false;
	}
}
