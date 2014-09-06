
@script ExecuteInEditMode;

var thisRight : boolean;
var thisLeft : boolean;
var turnLeft : boolean;
var turnRight : boolean;

function Update(){
if(thisRight){
thisLeft = false;
thisRight = true;
}
if(thisLeft){
thisRight = false;
thisLeft = true;
}
}


function OnTriggerEnter(other : Collider){
if(other.collider.tag == "Car"){

}
}