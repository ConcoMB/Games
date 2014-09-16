using UnityEngine;
using System.Collections;

[AddComponentMenu ("CarPhys/Scripts/Wheel Script")]
public class WheelScriptPC : MonoBehaviour {
		
	public enum wheelType { Steer , SteerAndMotor , Motor , JustAWheel}; //types of wheel
	public wheelType typeOfWheel;	//Object of wheelType
	public bool  handBreakable = false;	//can apply handbrakes
	public bool  invertSteer = false;	//invert the steer control
	public Transform wheelTransform;		//Mesh of the wheel
	private float speedFactor;	//switch between steer angles
	private WheelCollider wheelCollider;		//wheel collider attached to the same game object
	private CarControleScript carScript;		//Scripts attached on the car object at the top
	private float mySidewayFriction;	//default value
	private float myForwardFriction;	//default value
	private float slipSidewayFriction;	//Custom value
	private float slipForwardFriction;	//Custom value
	
	//Start
	
	void  Start (){
		wheelCollider = gameObject.GetComponent<WheelCollider>();
		carScript = transform.root.gameObject.GetComponent<CarControleScript>();
		SetValues();
	}
	
	//Assign values
	
	void  SetValues (){
		
		myForwardFriction  = wheelCollider.forwardFriction.stiffness;
		mySidewayFriction  = wheelCollider.sidewaysFriction.stiffness;
		slipForwardFriction = 0.05f;
		slipSidewayFriction = 0.085f;
		
	}
	
	
	void  Update (){
		WheelPosition();
		ReverseSlip();
		//Rotation Control
		wheelTransform.Rotate(wheelCollider.rpm/60*360*Time.deltaTime,0,0);
		if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor)
			wheelTransform.localEulerAngles = new Vector3(
				wheelTransform.localEulerAngles.x,
				wheelCollider.steerAngle - wheelTransform.localEulerAngles.z,
				wheelTransform.localEulerAngles.z
			);
	}
	
	
	//Triggers to different types of wheels and for handbrake
	
	void  FixedUpdate (){
		if (typeOfWheel == wheelType.Motor || typeOfWheel == wheelType.SteerAndMotor){
			TorqueControle ();
		}
		if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor){
			SteerControle ();
		}
		if(handBreakable){
			HandBrake();
		}
		if(!carScript.braked){
			Decellaration();
		}
	}
	
	//Position the wheel
	
	void  WheelPosition (){
		RaycastHit hit;
		Vector3 wheelPos = new Vector3();
		
		if (Physics.Raycast(transform.position, -transform.up,out hit,wheelCollider.radius+wheelCollider.suspensionDistance) ){
			wheelPos = hit.point+transform.up * wheelCollider.radius;
		} else {
			wheelPos = transform.position -transform.up* wheelCollider.suspensionDistance; 
		}
		wheelTransform.position = wheelPos;
	}
	
	
	//Decellaration
	
	void  Decellaration (){
		if (Input.GetButton("Vertical")==false){
			wheelCollider.brakeTorque = carScript.decellarationSpeed;
		}
		else{
			wheelCollider.brakeTorque = 0;
		}
	}
	
	//Steer Control
	
	void  SteerControle (){
		speedFactor = transform.parent.root.rigidbody.velocity.magnitude/carScript.lowestSteerAtSpeed;
		float currentSteerAngel= Mathf.Lerp(carScript.lowSpeedSteerAngel,carScript.highSpeedSteerAngel,speedFactor);
		if (invertSteer)
			currentSteerAngel *= -Input.GetAxis("Horizontal");
		else 
			currentSteerAngel *= Input.GetAxis("Horizontal");
		wheelCollider.steerAngle = currentSteerAngel;
	}
	
	
	
	
	//Torque Control
	
	void  TorqueControle (){
		if (carScript.currentSpeed < carScript.topSpeed && carScript.currentSpeed > -carScript.maxReverseSpeed && !carScript.braked){
			wheelCollider.motorTorque = carScript.maxTorque * Input.GetAxis("Vertical");
		}
		else {
			wheelCollider.motorTorque =0;
		}
	}
	
	//Hand Brake
	
	void  HandBrake (){
		WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
		if(carScript.braked){
			if(carScript.currentSpeed > 1){
				SetRearSlip(slipForwardFriction ,slipSidewayFriction); 
			}
			else if (carScript.currentSpeed < 0){
				SetRearSlip(1 ,1); 
			}
			sidewaysFriction.extremumValue = 300;
			wheelCollider.brakeTorque = carScript.maxBrakeTorque;
			wheelCollider.motorTorque =0;
			if (carScript.currentSpeed < 1 && carScript.currentSpeed > -1){
				carScript.backLightObject.renderer.material = carScript.idleLightMaterial;
			}
			else {
				carScript.backLightObject.renderer.material = carScript.brakeLightMaterial;
			}
		}
		else {
			sidewaysFriction.extremumValue = 10000;
			wheelCollider.brakeTorque = 0;
			SetRearSlip(myForwardFriction ,mySidewayFriction); 
		}
		wheelCollider.sidewaysFriction = sidewaysFriction;
	}
	
	//Reverse Slip
	
	void  ReverseSlip (){
		if (carScript.currentSpeed <0){
			SetFrontSlip(slipForwardFriction ,slipSidewayFriction); 
		}
		else {
			SetFrontSlip(myForwardFriction ,mySidewayFriction);
		}
	}
	
	//Slip Settings
	
	void  SetRearSlip ( float currentForwardFriction ,  float currentSidewayFriction  ){
		WheelFrictionCurve forwardFriction = wheelCollider.forwardFriction;
		WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
		if (typeOfWheel == wheelType.Motor || typeOfWheel == wheelType.SteerAndMotor && !carScript.braked){
			forwardFriction.stiffness = currentForwardFriction;
			sidewaysFriction.stiffness = currentSidewayFriction;
		}
		wheelCollider.sidewaysFriction = sidewaysFriction;
		wheelCollider.forwardFriction = forwardFriction;
	}
	void  SetFrontSlip ( float currentForwardFriction ,  float currentSidewayFriction  ){
		WheelFrictionCurve forwardFriction = wheelCollider.forwardFriction;
		WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
		if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor && !carScript.braked){
			forwardFriction.stiffness = currentForwardFriction;
			sidewaysFriction.stiffness = currentSidewayFriction;
		}
		wheelCollider.sidewaysFriction = sidewaysFriction;
		wheelCollider.forwardFriction = forwardFriction;
	}
}