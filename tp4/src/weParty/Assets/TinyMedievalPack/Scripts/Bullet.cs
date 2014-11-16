using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
	
	void Update () {
        transform.position += Vector3.right * Time.deltaTime * 10f;
	}
}
