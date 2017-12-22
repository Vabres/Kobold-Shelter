using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnScript : MonoBehaviour {
    public bool isEntry;
    public GameObject kobboldPrefab;
    public GameObject kobbold;
    public GameObject UIPersoPrefab;
    public GameObject UIPerso;
    public GameObject UIParent;


    float spawnTime = 30;
    // Use this for initialization
    void Start () {
        if (this.GetComponent<RoomGenScript>().isEntry)
        {
            isEntry = true;
        }
        else
        {
            isEntry = false;
        }
        UIParent = GameObject.Find("Panel");
	}
	
	// Update is called once per frame
	void Update () {
        if (isEntry)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime >= 30)
            {
                spawning();
                spawnTime = 0;
            }
        }
	}

    void spawning()
    {
        kobbold = Instantiate(kobboldPrefab);
        kobbold.GetComponent<Transform>().SetParent(GameObject.Find("Start").GetComponent<Transform>());
        kobbold.GetComponent<Transform>().localPosition = this.GetComponent<Transform>().localPosition + new Vector3(2,1,0);
        Camera.main.GetComponent<generalScript>().Kob.Add(kobbold);

        UIPerso = Instantiate(UIPersoPrefab);
        UIPerso.GetComponent<persoListScript>().perso = kobbold;
        UIPerso.GetComponent<Transform>().SetParent(UIParent.GetComponent<Transform>());

        kobbold.GetComponent<kobScript>().UIPerso = UIPerso;
    }

}
