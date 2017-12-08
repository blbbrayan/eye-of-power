using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;

public class CreateUser : MonoBehaviour {
	// Input Fields && Text Fields
	public InputField userName;
	public InputField email;
	public InputField password;
	public InputField cPassword;
	public Text errorMsg;
	private WWW www;
	private Dictionary<string, Object> jsonWWW;

	public void SubmitName()
	{
		if (isEmpty (userName) && isEmpty (email) && isEmpty (password) && isEmpty (password) && checkEmail() && checkUsername() && checkPasswords ()) {
			StartCoroutine (submit ());
		}
	}

	public IEnumerator submit(){
		Debug.Log (userName.text + email.text + password.text);
		WWWForm form = new WWWForm();
		form.AddField( "email", email.text );
		form.AddField( "username", userName.text);
		form.AddField( "password", password.text);
		byte[] rawData = form.data;
		string url = "http://localhost:3001/account/signup";

		// Post a request to an URL with our custom headers
		www = new WWW(url, rawData);
		yield return www;
		Debug.Log (userName.text + email.text + password.text);
		Debug.Log (www.text);
	}

	// Checks if the Input Fields are empty.
	private bool isEmpty(InputField inputField) {
		if (inputField.text.Trim () == "") {
			errorMsg.text = "* Make sure the fields are filled out.";
			return false;
		}
		return true;
	}

	// Checks if the Email is a valid email entry.
	private bool checkEmail(){
		if (new Regex ("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$").IsMatch(email.text)) {
			return true;
		}
		errorMsg.text = "* Enter a valid email.";
		return false;
	}
	// Checks if the Username fits the criteria that we need it too.
	private bool checkUsername() {
		if (userName.text.Length >= 4) {
			if (new Regex ("^[a-zA-Z]*$").IsMatch(userName.text)) {
				return true;
			} else {
				errorMsg.text = "* The Username can only be letters.";
			}
		} else {
			errorMsg.text = "* The Username length needs to be at least 4 characters.";
		}
		return false;
	}

	// Checks if the Password fits the criteria that we need it too.
	private bool checkPasswords() {
		if (password.text.Trim () == cPassword.text.Trim ()) {
			if (password.text.Trim ().Length >= 6) {
				return true;
			} else {
				errorMsg.text = "* The password length needs to be at least 6 characters.";
			}
		} else {
			errorMsg.text = "* The passwords do not match.";
		}
		return false;
	}

	void Update() {
	}

}
