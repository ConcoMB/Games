@script AddComponentMenu ("CarPhys/Scripts/Wheel Script")
#pragma strict
enum wheelType { Steer , SteerAndMotor , Motor , JustAWheel}; //types of wheel
var typeOfWheel : wheelType;	//Object of wheelType
var handBreakable : boolean = false;	//can apply handbrakes
var invertSteer : boolean = false;	//invert the steer control
var wheelTransform : Transform;		//Mesh of the wheel
private var speedFactor : float;	//switch between steer angles
private var wheelCollider : WheelCollider;		//wheel collider attached to the same game object
private var carScript : CarControleScript;		//Scripts attached on the car object at the top
private var mySidewayFriction : float;	//default value
private var myForwardFriction : float;	//default value
private var slipSidewayFriction : float;	//Custom value
private var slipForwardFriction : float;	//Custom value

//Start

function Start () {
wheelCollider = gameObject.GetComponent(WheelCollider);
carScript = transform.root.gameObject.GetComponent("CarControleScript");
SetValues();
}

//Assign values

function SetValues(){

myForwardFriction  = wheelCollider.forwardFriction.stiffness;
mySidewayFriction  = wheelCollider.sidewaysFriction.stiffness;
slipForwardFriction = 0.05;
slipSidewayFriction = 0.085;

}


function Update () {
WheelPosition();
ReverseSlip();
//Rotation Control
wheelTransform.Rotate(wheelCollider.rpm/60*360*Time.deltaTime,0,0);
if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor)
wheelTransform.localEulerAngles.y = wheelCollider.steerAngle - wheelTransform.localEulerAngles.z;
}


//Triggers to different types of wheels and for handbrake

function FixedUpdate (){
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

function WheelPosition(){
var hit : RaycastHit;
var wheelPos : Vector3;

if (Physics.Raycast(transform.position, -transform.up,hit,wheelCollider.radius+wheelCollider.suspensionDistance) ){
wheelPos = hit.point+transform.up * wheelCollider.radius;
}
else {
wheelPos = transform.position -transform.up* wheelCollider.suspensionDistance; 
}
wheelTransform.position = wheelPos;
}


//Decellaration

function Decellaration(){
if (Input.GetButton("Vertical")==false){
wheelCollider.brakeTorque = carScript.decellarationSpeed;
}
else{
wheelCollider.brakeTorque = 0;
}
}

//Steer Control

function SteerControle (){
speedFactor = transform.parent.root.rigidbody.velocity.magnitude/carScript.lowestSteerAtSpeed;
var currentSteerAngel = Mathf.Lerp(carScript.lowSpeedSteerAngel,carScript.highSpeedSteerAngel,speedFactor);
if (invertSteer)
currentSteerAngel *= -Input.GetAxis("Horizontal");
else 
currentSteerAngel *= Input.GetAxis("Horizontal");
wheelCollider.steerAngle = currentSteerAngel;
}




//Torque Control

function TorqueControle (){
if (carScript.currentSpeed < carScript.topSpeed && carScript.currentSpeed > -carScript.maxReverseSpeed && !carScript.braked){
wheelCollider.motorTorque = carScript.maxTorque * Input.GetAxis("Vertical");
}
else {
wheelCollider.motorTorque =0;
}
}

//Hand Brake

function HandBrake(){
if(carScript.braked){
if(carScript.currentSpeed > 1){
SetRearSlip(slipForwardFriction ,slipSidewayFriction); 
}
else if (carScript.currentSpeed < 0){
SetRearSlip(1 ,1); 
}
wheelCollider.sidewaysFriction.extremumValue = 300;
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
wheelCollider.sidewaysFriction.extremumValue = 10000;
wheelCollider.brakeTorque = 0;
SetRearSlip(myForwardFriction ,mySidewayFriction); 
}
}

//Reverse Slip

function ReverseSlip(){
if (carScript.currentSpeed <0){
SetFrontSlip(slipForwardFriction ,slipSidewayFriction); 
}
else {
SetFrontSlip(myForwardFriction ,mySidewayFriction);
}
}

//Slip Settings

function SetRearSlip (currentForwardFriction : float,currentSidewayFriction : float){
if (typeOfWheel == wheelType.Motor || typeOfWheel == wheelType.SteerAndMotor && !carScript.braked){
wheelCollider.forwardFriction.stiffness = currentForwardFriction;
wheelCollider.sidewaysFriction.stiffness = currentSidewayFriction;
}
}
function SetFrontSlip (currentForwardFriction : float,currentSidewayFriction : float){
if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor && !carScript.braked){
wheelCollider.forwardFriction.stiffness = currentForwardFriction;
wheelCollider.sidewaysFriction.stiffness = currentSidewayFriction;
}
}