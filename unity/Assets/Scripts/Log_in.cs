using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Log_in : MonoBehaviour {

    // Use this for initialization

    public Button btn;
    public InputField username;
    public InputField password;

    void Start() {

        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        StartCoroutine(Upload());
    }


    

	IEnumerator Upload() {
		WWWForm form = new WWWForm();
		form.AddField( "username", username.text );
		form.AddField( "password", password.text );
		byte[] rawData = form.data;
		string url = "http://localhost:3001/account/login";

		// Post a request to an URL with our custom headers
		WWW www = new WWW(url, rawData);
		yield return www;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
