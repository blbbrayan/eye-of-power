using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LogIn : MonoBehaviour {

    // Use this for initialization

    public Button btn;
    public Toggle tgl;
    public GameObject wrntxt;
    public InputField username;
    public InputField password;

    void Start() {

        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {

        if (username.text.Length <= 0 && password.text.Length <= 0)
        {
            wrntxt.SetActive(true);
        }
        else
        {
            wrntxt.SetActive(false);
        }
        

        if(username.text.Length >=0 && password.text.Length >= 0)
        {
            StartCoroutine(Upload());
        }
        

        if (tgl.isOn == false)
        {
            username.text = "";
            password.text = "";
        }

        

        


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
