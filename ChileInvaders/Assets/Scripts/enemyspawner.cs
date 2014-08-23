// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class enemyspawner : MonoBehaviour {
	
	
	//here are the 3 enemys we want to spawn (the orb, asteroid, and ship)
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	//here is the minimum and maximum height we want them to spawn. it can be changed in the inspector
	public float maxHeight = 6.0f;
	public float minHeight = -6.0f;
	
	//here are private variables we use for the spawner
	private float counter = 0.0f;
	private GameObject player;
	private int randomChoice;
	private float spawnRate = 2.0f;
	private int level = 1;
	
	void  Update (){
		//counter counts based on time here so the spawner can spawn based on time
		counter += Time.deltaTime;
		//here we make the spawner slowly spawn faster until it is spawning 3 a second.
		if(spawnRate > 0.33f){
			spawnRate -= Time.deltaTime/80;
		}
		//if the counter is higher than the spawnrate number, it'll spawn an object
		if(counter > spawnRate){
			//before one is spawned we have to decide at random which one to spawn
			randomChoice = Random.Range(1,6);
			//asteroids take up 3 out of the 5 possible spawns, making it spawn the most often
			if(level < 2 || randomChoice >= 1 && randomChoice <= 3){
				Instantiate(enemy1, new Vector3(transform.position.x,0,Random.Range(minHeight,maxHeight)), Quaternion.Euler(-90,0,0));
			}
			//if the random number ends up being 4, it'll spawn the orb, set as enemy2
			else if(level < 3 || randomChoice == 4){
				Instantiate(enemy2, new Vector3(transform.position.x,0,Random.Range(minHeight/3,maxHeight/3)), Quaternion.Euler(-90,0,0));
			}
			//if the random number ends up being 5, it'll spawn the ship, set as enemy3
			else if(randomChoice == 5){
				Instantiate(enemy3, new Vector3(transform.position.x,0,Random.Range(minHeight,maxHeight)), Quaternion.Euler(-90,90,0));
			}
			
			counter = 0.0f;
		}
		
	}

	void  levelup ( int lvlNumber  ){
		level = lvlNumber;
		Debug.Log("level up" + lvlNumber);
	}
}