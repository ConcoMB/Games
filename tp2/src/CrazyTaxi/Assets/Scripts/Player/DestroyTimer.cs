using UnityEngine;
using System.Collections;

[AddComponentMenu ("CarPhys/Scripts/Destroy Timer")]
public class DestroyTimer : MonoBehaviour {
	
	public float destroyAfter = 7; 	
	private float timer; 
	
	void  Update (){
		timer += Time.deltaTime;
		if (destroyAfter <= timer){
			Destroy(gameObject);
		}
	}
}