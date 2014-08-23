using UnityEngine;
using System.Collections;

public class menuSpaceship : MonoBehaviour {

	float maxUpAndDown = 0.1f;
	float speed = 50;
	
	protected float angle = -90;
	protected float toDegrees = Mathf.PI / 180;
	protected float startHeight;
	private float x;

	void  Start (){
		startHeight = transform.localPosition.y;
		x = transform.localPosition.x;
	}
	
	void  Update (){
		angle += speed * Time.deltaTime;
		if (angle > 270) angle -= 360;
		Debug.Log(maxUpAndDown * Mathf.Sin(angle * toDegrees));
		transform.localPosition = new Vector2(x, startHeight + maxUpAndDown * (1 + Mathf.Sin(angle * toDegrees)) / 2);
	}
}