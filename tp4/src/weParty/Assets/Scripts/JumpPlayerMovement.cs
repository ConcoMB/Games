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
 
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0, 0);
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
