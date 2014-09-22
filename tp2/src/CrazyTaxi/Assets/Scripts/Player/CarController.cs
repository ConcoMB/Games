using UnityEngine;
using System.Collections;

[AddComponentMenu ("CarPhys/Scripts/Car Controller")]
public class CarController : MonoBehaviour {
		
	public Vector3 centerOfMass;	
	public WheelCollider dataWheel;	
	public float lowestSteerAtSpeed = 50;	
	public float lowSpeedSteerAngel = 10;	
	public float highSpeedSteerAngel = 1;	
	public float decellarationSpeed = 30;	
	public float maxTorque  = 50;
	public float currentSpeed;		
	public float topSpeed = 150;	
	public float maxReverseSpeed = 50; 
	public GameObject backLightObject;	
	public Material idleLightMaterial;
	public Material brakeLightMaterial; 	
	public Material reverseLightMaterial;
	public bool braked = false;
	public float maxBrakeTorque = 100; 	
	public Texture2D speedOMeterDial;
	public Texture2D speedOMeterPointer;
	public int[] gearRatio;		
	public GameObject collisionSound;	
	public int minAnglePointer = -90;
	public int maxAnglePointer = 180;
	public GameObject pointsManager;

	void  Start (){
		rigidbody.centerOfMass=centerOfMass;
	}
	
	void  FixedUpdate (){
		HandBrake();
	}

	void  Update (){
		BackLight ();
		EngineSound();
		CalculateSpeed();
	}
	
	void  CalculateSpeed (){
		currentSpeed = 2*22/7*dataWheel.radius*dataWheel.rpm*60/1000;
		currentSpeed = Mathf.Round(currentSpeed);
	}
	
	void  BackLight (){
		if (currentSpeed > 0 && Input.GetAxis("Vertical") < 0 && !braked){
			backLightObject.renderer.material = brakeLightMaterial;
		}
		else if (currentSpeed < 0 && Input.GetAxis("Vertical") > 0 && !braked){
			backLightObject.renderer.material = brakeLightMaterial;
		}
		else if (currentSpeed < 0 && Input.GetAxis("Vertical") < 0 && !braked){
			backLightObject.renderer.material = reverseLightMaterial;
		}
		else if (!braked){
			backLightObject.renderer.material = idleLightMaterial;
		}
	}
	
	void  HandBrake (){
		braked = Input.GetKey(KeyCode.Space);
	}
	
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
		} else {
			gearMinValue = gearRatio[i-1];
		}
		gearMaxValue = gearRatio[i];
		float enginePitch = ((currentSpeed - gearMinValue)/(gearMaxValue - gearMinValue))+1;
		audio.pitch = enginePitch;
	}
	
	void  OnGUI (){
		GUI.DrawTexture( new Rect(Screen.width - 300,Screen.height - 300,300,300),speedOMeterDial);
		float speedFactor = currentSpeed / topSpeed;
		float rotationAngle;
		if (currentSpeed >= 0){
			rotationAngle = Mathf.Lerp(minAnglePointer,maxAnglePointer,speedFactor);
		}
		else {
			rotationAngle = Mathf.Lerp(minAnglePointer,maxAnglePointer,-speedFactor);
		}
		GUIUtility.RotateAroundPivot(rotationAngle, new Vector2(Screen.width - 150 ,Screen.height - 150));
		GUI.DrawTexture( new Rect(Screen.width - 300,Screen.height - 300,300,300),speedOMeterPointer);
	}
	
	void  OnCollisionEnter ( Collision other  ){
		if (other.transform != transform && other.contacts.Length != 0){
			for (int i= 0; i < other.contacts.Length ; i++){
				GameObject clone = (GameObject) Instantiate(collisionSound,other.contacts[i].point,Quaternion.identity);
				clone.transform.parent = transform;
				pointsManager.SendMessage("NotifyPoints", (int) currentSpeed, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void  OnDrawGizmos (){
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (transform.position+centerOfMass, 0.1f);
	}
}