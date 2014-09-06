#pragma strict
@script ExecuteInEditMode;
var carScript : CarControleScript;
private var nitro : CarControleNitro;
var buttonBrake : Rect;
var buttonNitro : Rect;

function Start () {
carScript = transform.root.gameObject.GetComponent("CarControleScript");
nitro = transform.root.gameObject.GetComponent("CarControleNitro");
}

function Update () {
if(Input.GetKey(KeyCode.Y)){
carScript.braked = true;
}
}

function OnGUI(){
if(GUI.Button(buttonBrake,"Brake")){
carScript.braked = true;
}

}