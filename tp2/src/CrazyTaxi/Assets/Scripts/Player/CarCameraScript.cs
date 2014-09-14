using UnityEngine;
using System.Collections;

[AddComponentMenu("CarPhys/Scripts/Car Camera Script")]

public class CarCameraScript : MonoBehaviour {


	public Transform car;	//Car Transform
	public float distance = 6.4f;		//Distance from car
	public float height = 1.4f; 	//Value on Y axis according to car transform
	public float rotationDamping = 3.0f;	 //lower the value , faster the damping will be
	public float heightDamping = 2.0f;	 //lower the value , faster the damping will be
	public float zoomRacio = 0.5f;	//Change on FOV
	public float DefaultFOV = 60;	//Min FOV
	public bool  rotate = true;	//Look Back While Reversing
	private Vector3 rotationVector;	//Rotation Vector
	
	//Positioning
	void  LateUpdate (){
		float wantedAngel= rotationVector.y;
		float wantedHeight= car.position.y + height;
		float myAngel= transform.eulerAngles.y;
		float myHeight= transform.position.y;
		myAngel = Mathf.LerpAngle(myAngel,wantedAngel,rotationDamping*Time.deltaTime);
		myHeight = Mathf.Lerp(myHeight,wantedHeight,heightDamping*Time.deltaTime);
		Quaternion currentRotation= Quaternion.Euler(0,myAngel,0);
		transform.position = car.position;
		transform.position -= currentRotation*Vector3.forward*distance;
		transform.position = new Vector3(transform.position.x, myHeight, transform.position.z);
		transform.LookAt(car);
	}
	
	
	//Rotation And FOV Control
	void  FixedUpdate (){
		UnityEngine.Vector3 localVilocity= car.InverseTransformDirection(car.rigidbody.velocity);
		if (localVilocity.z<-0.5f && rotate){
			rotationVector.y = car.eulerAngles.y + 180;
		}
		else {
			rotationVector.y = car.eulerAngles.y;
		}
		float acc= car.rigidbody.velocity.magnitude;
		camera.fieldOfView = DefaultFOV + acc*zoomRacio;
	}

	
	[RPC]
	void  Test (){}
}