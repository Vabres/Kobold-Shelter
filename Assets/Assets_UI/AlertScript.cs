using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AlertScript : MonoBehaviour {

	public Image cadre, alertIcon2;
	public GameObject alertNotif;
	public bool startAlert = false, stopAlert = false;
	public generalScript capitan;


	IEnumerator alerte(){
		float timer = 0f;
		alertNotif.SetActive (true);
		cadre.enabled = true;
		startAlert = false;

		while (!capitan.stopAlert) {
			timer += Time.deltaTime;
			if (timer >= 0.5f) {
				timer = 0f;
				alertIcon2.enabled = !alertIcon2.enabled;
				cadre.enabled = !cadre.enabled;
			}
			/*else if(timer = ) {
			}*/
			yield return null;
		}
		alertNotif.SetActive (false);

		stopAlert = false;
	}


	// Use this for initialization
	void Start () {
		cadre.enabled = false;
		alertIcon2.enabled = false;
		alertNotif.SetActive (false);
		capitan = Camera.main.GetComponent<generalScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (capitan.startAlert) {
			StartCoroutine (alerte ());
		}
	}
}
