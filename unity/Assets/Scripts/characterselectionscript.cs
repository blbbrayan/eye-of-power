using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class characterselectionscript : MonoBehaviour {
	//This is the character name and Images
	public string characterTitle;
	public Sprite characterImage;
	public Sprite characterImageDisabled;
	//Boolean to see if the player owns the character
	public bool isEnabled;
	//This is the Class type of the character
	public string role;
	//This is the description of the Character
	public string characterDesciptionText;
	// The ranks are 1 through 3 on a rating scale
	public int healthRank;
	public int damageRank;
	public int speedRank;
	//Images for the ranks
	public Sprite rank0;
	public Sprite rank1;
	public Sprite rank2;
	public Sprite rank3;
	//Images for the classes
	public Sprite Tank;
	public Sprite Dps;
	public Sprite Support; 

	// Use this for initialization
	void Start () {
		if (isEnabled) {
			gameObject.GetComponent<Image> ().sprite = characterImage;
			gameObject.GetComponent<Button> ().interactable = true;
		} else {
			gameObject.GetComponent<Image> ().sprite = characterImageDisabled;
			gameObject.GetComponent<Button> ().interactable = false;
		}
	}
	public void changeSelected(){
		GameObject.Find ("CharacterTitle").GetComponent<Text> ().text = characterTitle;
		GameObject.Find("CharacterDescription").GetComponent<Text> ().text = characterDesciptionText;
		if (role == "Tank") {
			GameObject.Find ("ClassTitle").GetComponent<Text> ().text = role;
			//GameObject.Find ("ClassImage").GetComponent<Image> ().sprite = Tank;
		} else if (role == "DPS") {	
			GameObject.Find ("ClassTitle").GetComponent<Text> ().text = role;
			//GameObject.Find ("ClassImage").GetComponent<Image> ().sprite = Dps;
		} else if (role == "Support") {
			GameObject.Find ("ClassTitle").GetComponent<Text> ().text = role;
			//GameObject.Find ("ClassImage").GetComponent<Image> ().sprite = Support;
		} else {
			Debug.Log ("Error setting class from name");
		}
		GameObject.Find ("healthRank").GetComponent<Image> ().sprite = checkRank (healthRank);
		GameObject.Find ("damageRank").GetComponent<Image> ().sprite = checkRank (damageRank);
		GameObject.Find ("speedRank").GetComponent<Image> ().sprite = checkRank (speedRank);
	}
	private Sprite checkRank(int x) {
		if (x == 0) 
			return rank0;
		else if (x == 1) 
			return rank1;
		else if (x == 2) 
			return rank2;
		else 
			return rank3;
		

	}
	// Update is called once per frame
	void Update () {
	}
}
