using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Knight : MonoBehaviour {

	public AudioClip[] attackSounds;
	public AudioClip[] hitSounds;
	public AudioClip dieSound;
	public PlayerDataManager manager;
	public Animator animator;
	public GameObject playerDataManagerObj;
	public bool leftMouseClick=false;
	public bool rightMouseClick=false;
	public bool canControl=true;
	public float leftMouseClicks;
	public int health = 3;
	public int maxHealth = 10;
	public int strength = 1;
	public int armor = 0;
	public int expPoints = 0;
	public int level = 1;
	public Status status = Status.Idle;
	public float inputX;
	public float inputY;
	public float inputJump;
	private float shift_axis_late;
	private float animLayer2;
	private bool getHit;
	public int gold = 0;
	public int levelRate = 5;
	private PlayerDataManager playerDataManager;
	private int hitSoundIndex = 0;
	private int attackSoundIndex = 0;
	public AudioClip levelupSound;
	public ParticleSystem blood;

	public enum Status{Idle, Hit, Attacking};

	void Start () {
		animator = GetComponent<Animator>();
		playerDataManager = playerDataManagerObj.GetComponent<PlayerDataManager>();
		blood.Stop();

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
		Debug.Log (status);
		if (leftMouseClick && status == Status.Idle) {
			status = Status.Attacking;
			Attack();
			StartCoroutine(WaitForAttackToEnd());
			StartCoroutine ("TimerClickTime");
		} 
		if (getHit) {
			status = Status.Hit;
			StartCoroutine(WaitForHitToEnd());
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

	void FightCombo(){ 
		leftMouseClicks += 1f;
		animator.SetFloat("LeftMouseClicks", leftMouseClicks);

		if (leftMouseClicks > 2f){
			leftMouseClicks = 0f;
		}
	}	
	
	void Hit(int hit) {
		blood.Play();
		getHit = true;
		health -= (hit - armor);
		if (health <= 0) {
			AudioSource.PlayClipAtPoint (dieSound, Camera.main.transform.position);

			StartCoroutine (WaitForLost ());
		} else {
			AudioSource.PlayClipAtPoint (hitSounds [hitSoundIndex % hitSounds.Length], Camera.main.transform.position);
			hitSoundIndex++;
		}
		StartCoroutine (WaitForBlood ());

	}

	void Experience(int exp) {
		expPoints += exp;
		if (expPoints >= level * levelRate) {
			LevelUp();
		}
	}

	void LevelUp() {
		AudioSource.PlayClipAtPoint (levelupSound, Camera.main.transform.position);
		expPoints = 0;
		level++;
		maxHealth += level * 10;
		health += level * 10;
		strength += level;
		playerDataManager.SendMessage ("LevelUp", SendMessageOptions.DontRequireReceiver);
	}

	void EarnGold(int earnGold) {
		gold += earnGold;
	}

	IEnumerator TimerClickTime(){ 
		yield return new WaitForSeconds(1f);
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
		AudioSource.PlayClipAtPoint(attackSounds[attackSoundIndex % attackSounds.Length], Camera.main.transform.position);
		attackSoundIndex++;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit[] hits = Physics.RaycastAll (transform.position, fwd, 4.0f);
		for (int i = 0; i < hits.Length; i++) {
			RaycastHit hit = hits [i];
			if (hit.collider.tag == "enemy") {
				Debug.Log ("hit");
				GameObject enemy = hit.collider.gameObject;
				enemy.SendMessage ("Hit", strength, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	IEnumerator WaitForAttackToEnd() {
		yield return new WaitForSeconds(1.5f);
		status = Status.Idle;
		yield return null;	
	}

	IEnumerator WaitForLost() {
		yield return new WaitForSeconds(1f);
		Application.LoadLevel("Lost");
		yield return null;	
	}

	IEnumerator WaitForHitToEnd() {
		yield return new WaitForSeconds(0.25f);
		status = Status.Idle;
		yield return null;	
	}
	IEnumerator WaitForBlood() {
		yield return new WaitForSeconds(1f);
		blood.Stop ();
		yield return null;	
	}

	void PowerupStrength(int value) {
		strength += value;
		playerDataManager.SendMessage ("StrengthUp", SendMessageOptions.DontRequireReceiver);
	}

	void PowerupArmor(int value) {
		armor += value;
		playerDataManager.SendMessage ("ArmorUp", SendMessageOptions.DontRequireReceiver);
	}

	void PowerupHealth(int value) {
		health += value;
		if (health > maxHealth) {
			health = maxHealth;
		}
	}
}
