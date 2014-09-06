@script AddComponentMenu ("CarPhys/AIScripts/AIPath")
var path : Array = new Array();
var rayColor : Color = Color.white;


function OnDrawGizmos(){
Gizmos.color = rayColor;
var path_objs : Array = transform.GetComponentsInChildren(Transform);
for(var path_obj : Transform in path_objs){
path.Add(path_obj);
}




for(var path_obj : Transform in path_objs){
if(path_obj == transform){
path.Add(path_obj);
}
}

for(var i : int = 0; i <path.length-1; i++){

var posObj : Transform = path[i] as Transform;
var pos : Vector3 = posObj.position;


if(i>0){

var prevObj : Transform = path[i-1] as Transform;
var prev: Vector3 = prevObj.position;
Gizmos.DrawLine(prev,pos);

}
}
}

