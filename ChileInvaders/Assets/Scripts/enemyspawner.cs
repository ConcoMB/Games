// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class enemyspawner : MonoBehaviour {
	
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public float maxHeight = 6.0f;
	public float minHeight = -6.0f;
	
	private float counter = 0.0f;
	private GameObject player;
	private int randomChoice;
	private float spawnRate = 2.0f;
	
	void  Update (){
		counter += Time.deltaTime;
		if(spawnRate > 0.33f){
			spawnRate -= Time.deltaTime/80;
		}
		if(counter > spawnRate){
			randomChoice = Random.Range(1,6);
			if(randomChoice >= 1 && randomChoice <= 3){
				Instantiate(enemy1, new Vector3(transform.position.x,0,Random.Range(minHeight,maxHeight)), Quaternion.Euler(-90,0,0));
			}
			if(randomChoice == 4){
				Instantiate(enemy2, new Vector3(transform.position.x,0,Random.Range(minHeight/3,maxHeight/3)), Quaternion.Euler(-90,0,0));
			}
			if(randomChoice == 5){
				Instantiate(enemy3, new Vector3(transform.position.x,0,Random.Range(minHeight,maxHeight)), Quaternion.Euler(-90,90,0));
			}
			counter = 0.0f;
		}
		
	}
}