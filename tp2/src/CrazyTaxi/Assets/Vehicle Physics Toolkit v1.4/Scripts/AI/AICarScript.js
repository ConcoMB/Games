#pragma strict
#pragma implicit
#pragma downcast
@script AddComponentMenu ("CarPhys/AIScripts/AICarScript")
var centerOfMass : Vector3; 
 
var path : Array;  
var pathGroup : Transform;  
var maxSteer : float = 15.0; 

var wheelFL : WheelCollider;   
var wheelFR : WheelCollider;  
var wheelRL : WheelCollider;   
var wheelRR : WheelCollider;  

var currentPathObj : int;  
var distFromPath : float = 20;  
var maxTorque : float = 50;  
var currentSpeed : float;  
var topSpeed : float = 150;  
var decellarationSpeed : float = 10;  
	
var breakingMesh : Renderer;  
var idleBreakLight : Material;  
var activeBreakLight : Material;  
var isBreaking : boolean;  
var inSector : boolean;  
var isControll = false;
var gearRatio : int[];
function Start () {  
rigidbody.centerOfMass = centerOfMass;  
GetPath();  
}  
  
function GetPath (){  
var path_objs : Array = pathGroup.GetComponentsInChildren(Transform);  
path = new Array();  
  
for (var path_obj : Transform in path_objs){  
  path.Add(path_obj);  
}  
}  
 
function EngineSound(){
for (var i = 0; i < gearRatio.length; i++){
if(gearRatio[i]> currentSpeed){
break;
}
}
var gearMinValue : float = 0.00;
var gearMaxValue : float = 0.00;
if (i == 0){
gearMinValue = 0;
}
else {
gearMinValue = gearRatio[i-1];
}
gearMaxValue = gearRatio[i];
var enginePitch : float = ((currentSpeed - gearMinValue)/(gearMaxValue - gearMinValue))+1;
audio.pitch = enginePitch;
}

    
      
function Update () {
GetSteer(); 
if(isControll){
Move(); 
}
BreakingEffect ();  
EngineSound();
}  
 
function FixedUpdate () {
}  
function GetSteer(){  
var inUse: Transform = path[currentPathObj]as Transform;

var steerVector : Vector3 = transform.InverseTransformPoint(Vector3(inUse.position.x, inUse.position.y,inUse.position.z));
var newSteer : float = maxSteer * (steerVector.x / steerVector.magnitude);  
wheelFL.steerAngle = newSteer;  
wheelFR.steerAngle = newSteer;  

if (steerVector.magnitude <= distFromPath){  
currentPathObj++;
}  
if (currentPathObj >= path.length ){  
currentPathObj = 0; 
} 

  
}  
  
function Move (){  
currentSpeed = 2*(22/7)*wheelRL.radius*wheelRL.rpm * 60 / 1000;  
currentSpeed = Mathf.Round (currentSpeed);  
if (currentSpeed <= topSpeed && !inSector){  
wheelRL.motorTorque = maxTorque;  
wheelRR.motorTorque = maxTorque;  
wheelRL.brakeTorque = 0;  
wheelRR.brakeTorque = 0;  
}  
else if (!inSector){  
wheelRL.motorTorque = 0;  
wheelRR.motorTorque = 0;  
wheelRL.brakeTorque = decellarationSpeed;  
wheelRR.brakeTorque = decellarationSpeed;  
}  
}  
  
function BreakingEffect (){  
if (isBreaking){  
breakingMesh.material = activeBreakLight;  
}  
else {  
breakingMesh.material = idleBreakLight;  
}  
  
} 


 