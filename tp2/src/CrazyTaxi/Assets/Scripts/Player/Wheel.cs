using UnityEngine;
using System.Collections;

[AddComponentMenu ("CarPhys/Scripts/Wheel Script")]
public class Wheel : MonoBehaviour {
		
	public enum wheelType { Steer , SteerAndMotor , Motor , JustAWheel}; //
	public wheelType typeOfWheel;	
	public bool  handBreakable = false;	
	public bool  invertSteer = false;	
	public Transform wheelTransform;		
	private float speedFactor;	
	private WheelCollider wheelCollider;		
	private CarController carScript;		
	private float mySidewayFriction;	
	private float myForwardFriction;	
	private float slipSidewayFriction;	
	private float slipForwardFriction;	
	
	void  Start (){
		wheelCollider = gameObject.GetComponent<WheelCollider>();
		carScript = transform.root.gameObject.GetComponent<CarController>();
		SetValues();
	}
	
	void  SetValues (){
		myForwardFriction  = wheelCollider.forwardFriction.stiffness;
		mySidewayFriction  = wheelCollider.sidewaysFriction.stiffness;
		slipForwardFriction = 0.05f;
		slipSidewayFriction = 0.085f;
		
	}
	
	
	void  Update (){
		WheelPosition();
		ReverseSlip();
		wheelTransform.Rotate(wheelCollider.rpm/60*360*Time.deltaTime,0,0);
		if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor)
			wheelTransform.localEulerAngles = new Vector3(
				wheelTransform.localEulerAngles.x,
				wheelCollider.steerAngle - wheelTransform.localEulerAngles.z,
				wheelTransform.localEulerAngles.z
			);
	}
	
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
	
	void  Decellaration (){
		if (Input.GetButton("Vertical")==false){
			wheelCollider.brakeTorque = carScript.decellarationSpeed;
		}
		else{
			wheelCollider.brakeTorque = 0;
		}
	}
	
	void  SteerControle (){
		speedFactor = transform.parent.root.rigidbody.velocity.magnitude/carScript.lowestSteerAtSpeed;
		float currentSteerAngel= Mathf.Lerp(carScript.lowSpeedSteerAngel,carScript.highSpeedSteerAngel,speedFactor);
		if (invertSteer)
			currentSteerAngel *= -Input.GetAxis("Horizontal");
		else 
			currentSteerAngel *= Input.GetAxis("Horizontal");
		wheelCollider.steerAngle = currentSteerAngel;
	}
	
	void  TorqueControle (){
		if (carScript.currentSpeed < carScript.topSpeed && carScript.currentSpeed > -carScript.maxReverseSpeed && !carScript.braked){
			wheelCollider.motorTorque = carScript.maxTorque * Input.GetAxis("Vertical");
		}
		else {
			wheelCollider.motorTorque =0;
		}
	}

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
	
	void  ReverseSlip (){
		if (carScript.currentSpeed < 0){
			SetFrontSlip(slipForwardFriction ,slipSidewayFriction); 
		} else {
			SetFrontSlip(myForwardFriction ,mySidewayFriction);
		}
	}
	
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