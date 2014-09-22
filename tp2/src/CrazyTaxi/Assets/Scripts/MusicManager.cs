using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public bool musicPlaying = true;
	public AudioSource audio;

	void Update (){
		if (Input.GetKeyDown(KeyCode.M)) {
			if (musicPlaying) {
				audio.mute = true;
				musicPlaying = false;
			} else {
				audio.mute = false;
				musicPlaying = true;
			}
		}
	}
	
}
