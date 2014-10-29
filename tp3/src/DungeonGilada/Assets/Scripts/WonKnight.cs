using UnityEngine;
using System.Collections;

public class WonKnight : MonoBehaviour {

	public Animator animator;
	public float animationDelta = 3f;
	private float acum = 1;
	private Vector3 position;

	void Start () {
		position = transform.position;
		transform.Rotate (0, 180, 0);
	}

	void Update () {
		transform.position = position;
		acum += Time.deltaTime;
		if (acum <= animationDelta) {
			animator.SetBool ("LeftMouseClick", false);
			return;
		}
		acum = 0;
		animator.SetBool ("LeftMouseClick", true);
		animator.SetFloat ("HitFromX", 1);
		animator.SetFloat ("HitFromZ", 10);
	}

	IEnumerator InAction(){
		yield return null;
	}
	
	IEnumerator AnimationEnd(){
		yield return null;
	}
}
