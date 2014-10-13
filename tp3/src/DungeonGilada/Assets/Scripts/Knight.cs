using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Knight : MonoBehaviour {

	public PlayerDataManager manager;
	public Animator animator;
	public bool leftMouseClick=false;
	public bool rightMouseClick=false;
	public bool canControl=true;
	public float leftMouseClicks;
	public int health = 10;
	public int strength = 1;
	public int armor = 0;
	public Status status = Status.Idle;
	public float inputX;
	public float inputY;
	public float inputJump;
	private float shift_axis_late;
	private float animLayer2;
	private bool getHit;

	public enum Status{Idle, Hit, Attacking, Defending};

	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void OnAnimatorIK(){
		animator.SetLayerWeight(1, 1f);
		animator.SetLayerWeight(2, animLayer2);
		if (canControl) {
			Vector3 camDir =  transform.position - Camera.main.transform.position;
			Vector3 lookPos = transform.position + camDir;
			lookPos.y = transform.position.y -(Camera.main.transform.position.y - transform.position.y) + 10f;
		}
	}
	
	void Update () {
		if (leftMouseClick) {
			status = Status.Attacking;
			Attack();
			StartCoroutine(WaitForAttackToEnd());
			StartCoroutine ("TimerClickTime");
		} 
		if (getHit) {
			status = Status.Hit;
			StartCoroutine ("TimerClickTime");
		} 
		if (animator) {	
			shift_axis_late = Mathf.Clamp((shift_axis_late - 0.005f), 0.0f, 1.1f);
			animLayer2 = Mathf.Clamp((animLayer2 - 0.01f), 0.0f, 1.0f);
			animator.SetBool("LeftMouseClick", leftMouseClick);
			animator.SetFloat("LeftShift_axis", shift_axis_late);
			animator.SetFloat("Axis_Horizontal", inputX);
			animator.SetFloat("Axis_Vertical", inputY);
			animator.SetFloat("Jump_axis", inputJump);
			animator.SetBool("RightMouse", rightMouseClick);
			animator.SetBool ("GetHit", getHit);

		}
		if (canControl) {
			inputX = Input.GetAxis("Horizontal");
			inputY = Input.GetAxis("Vertical");
			inputJump = Input.GetAxis("Jump");
			leftMouseClick = Input.GetMouseButtonDown(0);
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				shift_axis_late += 0.25f;
			}
			if (Input.GetAxis("Fire2") > 0) {
					rightMouseClick=true;
					animLayer2=0.5f;
			} else {
				rightMouseClick=false;
			}	
			if(inputX+inputY!=0){
				Vector3 camDir =  transform.position - Camera.main.transform.position;
				Vector3 lookPos = transform.position + camDir;
				lookPos.y = transform.position.y;
				transform.LookAt(lookPos);
			}
		}
	}

	void FightCombo(){   //every left mouse click +1 to animation number counter
		leftMouseClicks += 1f;
		animator.SetFloat("LeftMouseClicks", leftMouseClicks);

		if (leftMouseClicks > 2f){
			leftMouseClicks = 0f;
		}
	}	
	
	void Hit(int hit) {
		getHit = true;
		health -= (hit - armor);
		manager.SendMessage("UpdateHealth", health, SendMessageOptions.DontRequireReceiver);
		if (health <= 0) {
			// perdiste
		}

	}

	IEnumerator TimerClickTime(){ 
		yield return new WaitForSeconds(0.1f);
		leftMouseClick=false;
		getHit = false;
		yield return null;
	}

	IEnumerator InAction(){
		yield return null;
	}

	IEnumerator AnimationEnd(){
		yield return null;
	}

	void Attack() {
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy")) {
			float distance = Vector3.Distance(enemy.transform.position, transform.position);
			if (distance < 4) {
				enemy.SendMessage("Hit", strength, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	IEnumerator WaitForAttackToEnd() {
		yield return new WaitForSeconds(1f);
		status = Status.Idle;
		yield return null;	
	}
}
