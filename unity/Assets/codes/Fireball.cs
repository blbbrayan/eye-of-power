using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			GameObject obj = GameObject.Instantiate ((GameObject)Resources.Load ("fireball"));
			obj.transform.position = gameObject.transform.position;
		}
	}
}
