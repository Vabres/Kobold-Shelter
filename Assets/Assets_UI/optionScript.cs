using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionScript : MonoBehaviour{

	public GameObject optionMenu;

	public void Start() {
		hideMenu ();
	}

	public void deployMenu() {
		optionMenu.SetActive (true);
	}


	public void hideMenu() {
		optionMenu.SetActive (false);
	}

}
