using UnityEngine;
using System.Collections;

public class DanceSkelleton : MonoBehaviour {

	void Start () {
		animation.Play ("dance");
		animation["dance"].wrapMode = WrapMode.Loop;
	}
}
