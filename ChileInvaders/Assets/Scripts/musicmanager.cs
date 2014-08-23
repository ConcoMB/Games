using UnityEngine;
using System.Collections;

public class musicmanager : MonoBehaviour {

	void  Start (){
		DontDestroyOnLoad(gameObject);
	}
}