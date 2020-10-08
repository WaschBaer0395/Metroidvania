using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	//bool dashAxis = false;

	// Update is called once per frame
	void Update () {

	}

	public void Jump(InputAction.CallbackContext context){
		if(context.ReadValue<float>() == 1) jump = true;
	}

	public void Dash(InputAction.CallbackContext context){
		if(context.ReadValue<float>() == 1) dash = true;
	}

	public void Move(InputAction.CallbackContext context){

		horizontalMove = context.ReadValue<Vector2>().x * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}
}
