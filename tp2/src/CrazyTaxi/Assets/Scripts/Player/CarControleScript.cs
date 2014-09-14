using UnityEngine;
using System.Collections;

public class CarControleScript : MonoBehaviour {		

	public Vector3 centerOfMass = new Vector3(0f,-1.2f,0f);	//Center of mass
	public WheelCollider dataWheel;	//Wheel Collider from which you want to calculate the speed
	public float lowestSteerAtSpeed = 50;	//if lowestSteerAtSpeed < currentSpeed the steer Angle = highSpeedSteerAngel
	public float lowSpeedSteerAngel = 23;	//This could be a high value
	public float highSpeedSteerAngel = 5;	//This shouldn't be a high value (recomended for stability of car)
	public float decellarationSpeed = 40;	//How fast the car will decellarate
	public float maxTorque  = 10;	//Maximum Torque
	public float currentSpeed = 0;		//Current Speed of car
	public float topSpeed = 140;		//Highest speed at which the car can go
	public float maxReverseSpeed = 40; 	//Highest Reverse speed
	public GameObject backLightObject;	//Mesh for reverse light
	public Material idleLightMaterial;	//for idle state
	public Material brakeLightMaterial; 	//Braked state
	public Material reverseLightMaterial;	//Reverse state
//	@HideInInspector
	bool braked = false;	//Brake trigger
	public float maxBrakeTorque = 100; 	//Braking speed
	public Texture2D speedOMeterDial;	//GUI Texture for dial
	public Texture2D speedOMeterPointer;		//GUI Texture for needle
	public int[] gearRatio;		//Shift gear at speed
	//GameObject spark;		//OnCollision Spark
	public GameObject collisionSound;	//OnCollision Sound
	public int minAnglePointer = -90;
	public int maxAnglePointer = 180;
	
	void  Start (){
		rigidbody.centerOfMass=centerOfMass; //Center of mass , for this the car should be pointing on z axis
	}
	
	void  FixedUpdate (){
		HandBrake();
	}
	void  Update (){
		BackLight ();
		EngineSound();
		CalculateSpeed();
	}
	
	//Speed Calculation
	
	void  CalculateSpeed (){
		currentSpeed = 2*22/7*dataWheel.radius*dataWheel.rpm*60/1000;
		currentSpeed = Mathf.Round(currentSpeed);
	}
	
	//Light Control
	
	void  BackLight (){
		if (currentSpeed > 0 && Input.GetAxis("Vertical")<0&&!braked){
			backLightObject.renderer.material = brakeLightMaterial;
		}
		else if (currentSpeed < 0 && Input.GetAxis("Vertical")>0&&!braked){
			backLightObject.renderer.material = brakeLightMaterial;
		}
		else if (currentSpeed < 0 && Input.GetAxis("Vertical")<0&&!braked){
			backLightObject.renderer.material = reverseLightMaterial;
		}
		else if (!braked){
			backLightObject.renderer.material = idleLightMaterial;
		}
	}
	
	//Brake Trigger
	
	void  HandBrake (){
		if (Input.GetButton("Jump")){
			braked = true;
		}
		else{
			braked = false;
		}
	}
	//Engine Sound
	
	void  EngineSound (){
		int i;
		for (i= 0; i < gearRatio.Length; i++){
			if(gearRatio[i]> currentSpeed){
				break;
			}
		}
		float gearMinValue = 0.00f;
		float gearMaxValue = 0.00f;
		if (i == 0){
			gearMinValue = 0;
		}
		else {
			gearMinValue = gearRatio[i-1];
		}
		gearMaxValue = gearRatio[i];
		float enginePitch = ((currentSpeed - gearMinValue)/(gearMaxValue - gearMinValue))+1;
		audio.pitch = enginePitch;
	}
	
	//Speedometer
	
	void  OnGUI (){
		GUI.DrawTexture( new Rect(Screen.width - 300,Screen.height - 300,300,300),speedOMeterDial);
		float speedFactor = currentSpeed / topSpeed;
		float rotationAngle;
		Vector2 pivotPoint;
		if (currentSpeed >= 0){
			rotationAngle = Mathf.Lerp(minAnglePointer,maxAnglePointer,speedFactor);
		}
		else {
			rotationAngle = Mathf.Lerp(minAnglePointer,maxAnglePointer,-speedFactor);
		}
		pivotPoint = new Vector2(Screen.width - 150 ,Screen.height - 150);
		GUIUtility.RotateAroundPivot (rotationAngle, pivotPoint); 
		//GUIUtility.RotateAroundPivot(rotationAngle,Vector2(Screen.width - 150 ,Screen.height - 150));
		GUI.DrawTexture( new Rect(Screen.width - 300,Screen.height - 300,300,300),speedOMeterPointer);
	}
	
	//CollisioN FX
	
	void  OnCollisionEnter ( Collision other  ){
		
		if (other.transform != transform && other.contacts.Length != 0){
			for (int i= 0; i < other.contacts.Length ; i++){
				//Instantiate(spark,other.contacts[i].point,Quaternion.identity);
				GameObject clone = (GameObject)Instantiate(collisionSound,other.contacts[i].point,Quaternion.identity);
				clone.transform.parent = transform;
			}
		}
	}
	
	void  OnDrawGizmos (){
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (transform.position+centerOfMass, 0.1f);
	}
	
}