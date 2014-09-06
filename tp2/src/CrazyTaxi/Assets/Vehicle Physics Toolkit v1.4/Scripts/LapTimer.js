#pragma strict
var guiSkin : GUISkin;

var timer : float = 0;
var minute : float = 0;


function Start () {

}

function Update () {
timer += Time.deltaTime * 1;
}

function OnGUI(){
GUI.skin = guiSkin;


GUI.Label(Rect(100,110,300,50),"Time : " + timer);
}

