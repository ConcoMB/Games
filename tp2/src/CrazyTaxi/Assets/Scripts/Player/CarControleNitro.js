#pragma strict
@script AddComponentMenu ("CarPhys/Scripts/CarControleNitro")
var thisPC = false;
private var nitro = false;
private var currentTorque = 0.0f;
var maxNitroAccelaration = 50;
var maxTorque = 20;
var nitroVolume = 80f;
var maxNitrovolume = 100;
private var carTorque = 0;
var particleEffectLeft : GameObject;
var particleEffectRight : GameObject;
var guiSkin : GUISkin;

function Start(){
particleEffectLeft.GetComponent(ParticleEmitter).emit = false;
particleEffectRight.GetComponent(ParticleEmitter).emit = false;
particleEffectLeft.GetComponent(LensFlare).enabled = false;
particleEffectRight.GetComponent(LensFlare).enabled = false;
}

function Update () {
Swipe();
Nitro();
carTorque = gameObject.GetComponent(CarControleScript).maxTorque = currentTorque;
if(nitroVolume<=0){
nitro = false;
nitroVolume = 0;
currentTorque = maxTorque;
particleEffectLeft.GetComponent(ParticleEmitter).emit = false;
particleEffectRight.GetComponent(ParticleEmitter).emit = false;
particleEffectLeft.GetComponent(LensFlare).enabled = false;
particleEffectRight.GetComponent(LensFlare).enabled = false;
}
if(nitroVolume> maxNitrovolume){
nitroVolume = maxNitrovolume;
}
if(Input.GetKey(KeyCode.Z)){
nitro = true;
}else{
nitro = false;
}
if(Input.touchCount == 0 ){
nitro = false;
}
}
var touchFacing : Vector2;
var initTouchPos : Vector2;	

function Swipe(){
var fingerCount : int = 0;				
if(fingerCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Ended)
{
touchFacing = (initTouchPos - Input.GetTouch(0).position).normalized;					
if(Vector2.Dot(touchFacing, -Vector2.up) > 0.8 && Vector2.Distance(initTouchPos, Input.GetTouch(0).position) > 20)
{
nitro = true;
}
}
}



function Nitro(){
if(nitro){
currentTorque = maxNitroAccelaration;
nitroVolume -= 1;
particleEffectLeft.GetComponent(ParticleEmitter).emit = true;
particleEffectRight.GetComponent(ParticleEmitter).emit = true;
particleEffectRight.GetComponent(LensFlare).enabled = true;
particleEffectLeft.GetComponent(LensFlare).enabled = true;
}
if(!nitro){
currentTorque = maxTorque;
nitroVolume += 1;
particleEffectLeft.GetComponent(ParticleEmitter).emit = false;
particleEffectRight.GetComponent(ParticleEmitter).emit = false;
particleEffectLeft.GetComponent(LensFlare).enabled = false;
particleEffectRight.GetComponent(LensFlare).enabled = false;
}
}


function OnGUI(){
GUI.skin = guiSkin;

GUI.Label(Rect (100,50,300,100),"Current torque : " + currentTorque );
GUI.Label(Rect (100,80,300,100),"Nitro Volume : " + nitroVolume);
}




