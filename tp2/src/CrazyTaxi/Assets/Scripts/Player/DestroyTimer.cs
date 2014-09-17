using UnityEngine;
using System.Collections;

[AddComponentMenu ("CarPhys/Scripts/Destroy Timer")]
public class DestroyTimer : MonoBehaviour {
	
	public float destroyAfter = 7; 	//Waitin time to destroy a object in seconds
	private float timer; 	//Counting time
	
	//Calculation
	
	void  Update (){
		timer += Time.deltaTime;
		if (destroyAfter <= timer){
			Destroy(gameObject);
		}
	}
}