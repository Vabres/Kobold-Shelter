using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class persoListScript : MonoBehaviour {

	public GameObject perso, fichePerso;
	public Text name;
	public Sprite wariorIcon, gathererIcon, workerIcon;
	public Image icon;
	public int nbDePerso = 0;
    public kobScript kob;

	// Use this for initialization
	void Start () {
        kob = perso.GetComponent<kobScript>();
        fichePerso = GameObject.Find("fichePerso");
		name = kob.name;
	}

	public void appui(){

		fichePerso.GetComponent<fichePersoScript> ().affichage (perso);
	
	}


	// Update is called once per frame
	void Update () {


		if (kob.job == "warior")
			icon.sprite = wariorIcon;
		if (kob.job == "gatherer") {
			icon.sprite = gathererIcon;
		}
		if (kob.job == "worker") {
			icon.sprite = workerIcon;
		}
	}
}
