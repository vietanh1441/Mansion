using UnityEngine;
using System.Collections;

public class Virus : MonoBehaviour {

    public static int[] pos = new int[2];


	void Start () {
	    //Random 2 number which will be the position
        pos[0] = 2;
        pos[1] = 2;
        transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
        
	}
	
	// Update is called once per frame
	void Update () {
        Block_Pos.make_occupy(pos[0], pos[1], transform);
	}


}
