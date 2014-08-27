using UnityEngine;
using System.Collections;

public class menuSpaceship : MonoBehaviour {

	public float maxUpAndDown = 0.1f;
	public float speed = 50;

	private float angle = -90;
	private float toDegrees = Mathf.PI / 180;
	private float startHeight;

	void  Start (){
		startHeight = transform.localPosition.y;
	}
	
	void  Update (){
		angle += speed * Time.deltaTime;
		if (angle > 270) 
			angle -= 360;
		transform.localPosition = new Vector2(transform.localPosition.x, startHeight 
		                                      + maxUpAndDown * (1 + Mathf.Sin(angle * toDegrees)) / 2);
	}
}