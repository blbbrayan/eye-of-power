using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestHttp : MonoBehaviour {

	// Use this for initialization
	void Start() {
		StartCoroutine(Upload());
	}

	IEnumerator Upload() {
		WWWForm form = new WWWForm();
		form.AddField( "path", "test" );
		form.AddField( "key", "1" );
		form.AddField( "foo", "hello world" );
		byte[] rawData = form.data;
		string url = "http://localhost:3001/data/set";

		// Post a request to an URL with our custom headers
		WWW www = new WWW(url, rawData);
		yield return www;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
