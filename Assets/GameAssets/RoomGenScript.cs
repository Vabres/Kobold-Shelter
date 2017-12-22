

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGenScript : MonoBehaviour {

    public GameObject millieuGauche, millieuDroit, basGauche, basDroit, basMillieu, interieur;
    GameObject[,] room = new GameObject[10,4];
    int currentZ;
    GameObject selectedPrefab;
    public GameObject BackGround;
    public GameObject BackGroundPrefab;
    public bool isRssource;
    public bool isCraft;
    public bool isDorm;
    public bool isEntry;

    public bool leftConnexion;
    public bool rightConnexion;


    // Use this for initialization
    void Start () {
        GenerateRoom();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateRoom()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if (isCraft == false && isDorm == false && isRssource == false && isEntry == false)
                {
                    currentZ = 5;
                    selectedPrefab = interieur;
                }
                else if (i == 0 && j == 3)
                {
                    selectedPrefab = millieuGauche;
                    currentZ = -5;
                }
                else if (i == 0 && j != 0 && leftConnexion != true)
                {
                    selectedPrefab = millieuGauche;
                    currentZ = -5;
                }
                else if (i == 0 && j == 0)
                {
                    selectedPrefab = basGauche;
                    currentZ = -5;

                }
                else if (i == 9 && j == 3)
                {
                    currentZ = -5;
                    selectedPrefab = millieuDroit;
                }
                else if (i == 9 && j != 0 && rightConnexion != true)
                {
                    currentZ = -5;
                    selectedPrefab = millieuDroit;
                }
                else if (i == 9 && j == 0)
                {
                    currentZ = -5;
                    selectedPrefab = basDroit;
                }
                else if (j == 0)
                {
                    currentZ = -5;
                    selectedPrefab = basMillieu;
                }
                else
                {
                    selectedPrefab = null;
                }



                if (selectedPrefab != null)
                {
                    room[i, j] = Instantiate(selectedPrefab);
                    room[i, j].GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
                    room[i, j].GetComponent<Transform>().localPosition = new Vector3(i, j, currentZ);

                }
            }
        }
        BackGround = Instantiate(BackGroundPrefab);
        BackGround.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        BackGround.GetComponent<Transform>().localPosition = new Vector3(4.5f, 1.5f , 10);
        BackGround.GetComponent<Transform>().localScale = new Vector3(8, 3.4f, 0);


    }
}
