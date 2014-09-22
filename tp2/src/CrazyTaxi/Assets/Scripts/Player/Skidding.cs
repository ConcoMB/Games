using UnityEngine;
using System.Collections;

[AddComponentMenu("CarPhys/Scripts/Skidding")]
public class Skidding : MonoBehaviour {
			
	private float currentFrictionValue;	
	public float skidAt = 1.5f;	
	public float soundEmition = 15;	
	private float soundWait;	
	public GameObject skidSound;		
	public GameObject skidSmoke;		
	public float smokeDepth = 0.4f;	
	public float markWidth = 0.2f;	
	public bool  startSkid;		
	private int skidding;		
	private Vector3[] lastPos= new Vector3[2]; 	
	public Material skidMaterial;	
		
	void  Start (){
		skidSmoke.transform.position = new Vector3(transform.position.x, transform.position.y - smokeDepth,
			transform.position.z
		);
	}
	
	void  Update (){
		WheelHit hit;
		transform.GetComponent<WheelCollider>().GetGroundHit(out hit);
		currentFrictionValue = Mathf.Abs(hit.sidewaysSlip);
		float rpm= transform.GetComponent<WheelCollider>().rpm;
		if (skidAt <= currentFrictionValue && soundWait <= 0 || rpm < 300 && rpm > 10 && 
				Input.GetAxis("Vertical") > 0 && soundWait <= 0 && startSkid && hit.collider){
			Instantiate(skidSound,hit.point,Quaternion.identity);
			soundWait = 1;
		}
		soundWait -= Time.deltaTime*soundEmition;
		if (skidAt <= currentFrictionValue || rpm < 300 && rpm > 10 && Input.GetAxis("Vertical") > 0 && startSkid && hit.collider){
			skidSmoke.particleEmitter.emit = true;
			SkidMesh();
		}
		else {
			skidSmoke.particleEmitter.emit = false;
			skidding = 0;
		}
	}
	
	void  SkidMesh (){
		WheelHit hit;
		transform.GetComponent<WheelCollider>().GetGroundHit(out hit);
		GameObject mark = new GameObject("Mark");
		MeshFilter filter = mark.AddComponent<MeshFilter>();
		mark.AddComponent<MeshRenderer>();
		Mesh markMesh = new Mesh();
		Vector3[] vertices= new Vector3 [4];
		int[] triangles = new int[6];
		if (skidding == 0){
			vertices[0] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)* new Vector3(markWidth,0.01f,0);
			vertices[1] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)* new Vector3(-markWidth,0.01f,0);
			vertices[2] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)* new Vector3(-markWidth,0.01f,0);
			vertices[3] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)* new Vector3(markWidth,0.01f,0);
			lastPos[0] = vertices[2];
			lastPos[1] = vertices[3];
			skidding = 1;
		} else {
			vertices[1] = lastPos[0];
			vertices[0] = lastPos[1];
			vertices[2] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)* new Vector3(-markWidth,0.01f,0);
			vertices[3] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)* new Vector3(markWidth,0.01f,0);
			lastPos[0] = vertices[2];
			lastPos[1] = vertices[3];
		} 
		triangles = new int[6] {0,1,2,2,3,0};
		markMesh.vertices = vertices;
		markMesh.triangles = triangles;
		markMesh.RecalculateNormals();
		Vector2[] uvm = new Vector2[4];
		uvm[0] = new Vector2(1,0);
		uvm[1] = new Vector2(0,0);
		uvm[2] = new Vector2(0,1);
		uvm[3] = new Vector2(1,1);
		markMesh.uv = uvm;
		filter.mesh = markMesh;
		mark.renderer.material = skidMaterial;
	}
}

