using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//example json string (like the one from the server)
		var jsonString = "{\"name\": \"Steve\", \"age\": 42}";
		//looks like this {name: "Steve", age: 42}


		//how to turn it into a json
		JSONObject json = new JSONObject(jsonString);

		//how to access the data
		Debug.Log("name: " + json.GetField("name")); //gets the data of name
		Debug.Log("age: " + json.GetField("age")); //gets the data of age
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
