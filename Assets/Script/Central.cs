using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Central : MonoBehaviour {
    public GameObject virus;
    public GameObject mole;
    public List<GameObject> list;
    public static bool signal = false;
	// Use this for initialization
    void Awake()
    {
        Generate_mole();
        Generate_mole();
        Generate_mole();
        Generate_mole();
        for (int i = 0; i < 5; i++)
        {
            Generate_virus();
            
        }
    }

    void Start()
    {
        signal = true;
    }

	// Update is called once per frame
	void Update () {
        if (signal)
        {
            Make_mole();
            signal = false;
        }
	}

    //Making mole but instead of calling from the start, set condition to it
    void Make_mole()
    {
        
            Generate_mole();
            GameObject hmm = list[0];
            hmm.SendMessage("Set_enable", 1);
            //Debug.Log("Send enable message");
            list.Remove(hmm);
        
    }

    void Generate_virus()
    {
        //Set random and send to virus
        GameObject hmm = (GameObject)Instantiate(virus);
        hmm.name = "BasicVirus";
        int x,y,z;
        x = Random.Range(0, 8);
        y = Random.Range(0, 8);
        while(Block_Pos.is_occupy(x, y))
        {
            x = Random.Range(0, 8);
            y = Random.Range(0, 8);
        }
        hmm.SendMessage("Set_x", x);
        hmm.SendMessage("Set_y", y);
        z = Random.Range(0, 3);
        hmm.SendMessage("Set_type", z);
        
    }

    void Generate_mole()
    {
        //Set random and send to mole
        GameObject hmm = (GameObject)Instantiate(mole);
        int z;
        hmm.name = "Basicmole";
        hmm.SendMessage("Set_x", 5f);
        hmm.SendMessage("Set_y", 20f);
        z = Random.Range(0, 3);
        hmm.SendMessage("Set_type", z);
        list.Add(hmm);
    }
}
