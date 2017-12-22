using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{
    public GameObject roomprefab;
    public GameObject emptySpace;

    int[,] sheltersetup = new int[20, 4];
    GameObject[,] shelterobj = new GameObject[20, 4];
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                sheltersetup[i, j] = 0;
            }
        }
        sheltersetup[0, 0] = 1;
        sheltersetup[1, 0] = 2;
        sheltersetup[2, 0] = 3;
        sheltersetup[3, 0] = 4;
        generateShelter();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateShelter()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 1; j++)
            {

                shelterobj[i, j] = Instantiate(roomprefab);
                switch (sheltersetup[i, j])
                {
                    case 0: //rien
                        shelterobj[i, j].GetComponent<RoomGenScript>().isCraft = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isDorm = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isRssource = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isEntry = false;
                        break;
                    case 1: //entrée
                        shelterobj[i, j].GetComponent<RoomGenScript>().isCraft = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isDorm = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isRssource = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isEntry = true;
                        break;
                    case 2: //food
                        shelterobj[i, j].GetComponent<RoomGenScript>().isCraft = true;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isDorm = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isRssource = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isEntry = false;
                        break;
                    case 3: //dorm
                        shelterobj[i, j].GetComponent<RoomGenScript>().isCraft = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isDorm = true;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isRssource = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isEntry = false;
                        break;
                    case 4: //ressources
                        shelterobj[i, j].GetComponent<RoomGenScript>().isCraft = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isDorm = false;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isRssource = true;
                        shelterobj[i, j].GetComponent<RoomGenScript>().isEntry = false;
                        break;
                }
                if (i == 0 || sheltersetup[i - 1, j] != 0)
                {
                    shelterobj[i, j].GetComponent<RoomGenScript>().leftConnexion = true;

                }

                if (i != 20 || sheltersetup[i + 1, j] != 0)
                {
                    shelterobj[i, j].GetComponent<RoomGenScript>().rightConnexion = true;

                }

                shelterobj[i, j].GetComponent<Transform>().localPosition = new Vector3(i * 10, j * 4f, 0);

            }
        }
    }

    public GameObject findroom(string tag)
    {
     
        if (tag == "entry")
        {
            for (int i = 0; i < 20; i++)
            {
                

                    if (sheltersetup[i, 0] == 1)
                    {
                     
                        return shelterobj[i, 0];
                    }

                
            }
        }

        if (tag == "dorm")
        {
            for (int i = 0; i < 20; i++)
            {
        
                    if (sheltersetup[i, 0] == 3)
                    {
                        return shelterobj[i, 0];
                    }
                
            }
        }

        if (tag == "food")
        {
            for (int i = 0; i < 20; i++)
            {
                    if (sheltersetup[i, 0] == 2)
                    {
                        return shelterobj[i, 0];
                    }                
            }
        }

        if (tag == "ressources")
        {

            for (int i = 0; i < 20; i++)
            {
              
                   
                    if (sheltersetup[i,0] == 4)
                    {

                        return shelterobj[i, 0];
                    }

                
            }
        }

        return null;

    }

}
