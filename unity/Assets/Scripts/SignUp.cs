using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour {


    public Button btn;



	// Use this for initialization
	void Start () {
        btn.onClick.AddListener(TaskOnClick);
    }
	

    void TaskOnClick()
    {
        SceneManager.LoadScene("signup");
    }


	// Update is called once per frame
	void Update () {
		
	}
}
