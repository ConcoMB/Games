using UnityEngine;
using System.Collections;

public class JumpPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private bool isGrounded = false;


    void Update() {
		if (JumpGameControl.lost) {
			return;
		}
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0); 
		float moveInput = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;

		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];
			if (touch.position.x < Screen.width/2)
			{
				moveInput = - Time.deltaTime * movementSpeed;
			}
			else if (touch.position.x > Screen.width/2)
			{
				moveInput = Time.deltaTime * movementSpeed;
			}
		}

		transform.Translate(moveInput, 0, 0);
	}

    void Jump()
    {
		if (JumpGameControl.lost) {
			return;
		}
        if (!isGrounded) { return; }
        isGrounded = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.AddForce(new Vector3(0, 700, 0), ForceMode.Force);        
    }

    void FixedUpdate()
    {
		if (JumpGameControl.lost) {
			return;
		}
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 1.0f);
        if (isGrounded)
        {
            Jump(); 
        }
    }
       

}
