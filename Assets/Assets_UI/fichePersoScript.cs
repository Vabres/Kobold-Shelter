using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class fichePersoScript : MonoBehaviour {

	public Text nameTxt, jobTxt, capAtkTxt, capArtTxt, capIntTxt;
	public GameObject fichePerso, perso;
	public Image barreFaim, barreVie, barreSommeil;
	public GameObject btnWar, btnGat;
	public kobScript kob;


	public void affichage(GameObject g){
		fichePerso.SetActive (true);
		kob = g.GetComponent<kobScript>();
		nameTxt.text = kob.name;
		jobTxt.text = kob.job;
		capArtTxt.text = kob.Artisanat.ToString();
		capAtkTxt.text = kob.Atk.ToString();
		capIntTxt.text = kob.Intel.ToString();
        barreSommeil.GetComponent<RectTransform>().sizeDelta = new Vector2((float)kob.Sleep, barreSommeil.GetComponent<RectTransform>().sizeDelta.y);
        barreFaim.GetComponent<RectTransform>().sizeDelta = new Vector2((float)kob.Hunger, barreFaim.GetComponent<RectTransform>().sizeDelta.y);
        barreVie.GetComponent<RectTransform>().sizeDelta = new Vector2((float)kob.PV * 33, barreVie.GetComponent<RectTransform>().sizeDelta.y);
		perso = g;
		if (jobTxt.text == "warrior") {
			jobChoiceWar ();
		}
		else if (jobTxt.text == "gatherer") {
			jobChoiceGat ();
		} 
		else {
			btnGat.SetActive (true);
			btnGat.GetComponent<Button> ().enabled = true;

			btnWar.SetActive (true);
			btnWar.GetComponent<Button> ().enabled = true;
		}

        kob.locked = true;

	}

	public void jobChoiceWar(){
		btnGat.SetActive (false);
		btnWar.GetComponent<Button> ().enabled = false;
		kob.job = "warrior";
	}
	public void jobChoiceGat() {
		btnWar.SetActive (false);
		btnGat.GetComponent<Button> ().enabled = false;
		kob.job = "gatherer";
	}

	public void masquage(){
		fichePerso.SetActive (false);
        kob.locked = false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fichePerso.activeSelf) {
			barreSommeil.GetComponent<RectTransform>().sizeDelta = new Vector2((float)kob.Sleep, barreSommeil.GetComponent<RectTransform>().sizeDelta.y);
			barreFaim.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((float)kob.Hunger, barreFaim.GetComponent<RectTransform> ().sizeDelta.y);
			barreVie.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((float)kob.PV * 33, barreVie.GetComponent<RectTransform> ().sizeDelta.y);
		}
	}
}
