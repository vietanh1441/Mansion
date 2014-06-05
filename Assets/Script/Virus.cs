using UnityEngine;
using System.Collections;

public class Virus : MonoBehaviour {

    private int[] pos = new int[2];
    private int color = 0;

  

   /* public static void starting(int x, int y)
    {
        //Random 2 number which will be the position
        pos[0] = x;
        pos[1] = y;
        
    }*/

    void Start()
    {
        if (color == 0)
        {
            gameObject.renderer.material.color = Color.yellow;
            gameObject.tag = "Yellow";
        }
        if (color == 1)
        {
            gameObject.renderer.material.color = Color.red;
            gameObject.tag = "Red";
        }
        if (color == 2)
        {
            gameObject.renderer.material.color = Color.green;
            gameObject.tag = "Green";
        }
        transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
        Block_Pos.make_occupy(pos[0], pos[1], gameObject);
    }

	// Update is called once per frame
	void Update () {
        
       
        if (Input.GetKeyDown(KeyCode.C))
        {
            Block_Pos.destroy_piece(pos[0], pos[1]);
        }
	}

    void Set_x(int x)
    {
        pos[0] = x;
    }

    void Set_y(int y)
    {
        pos[1] = y;
    }
    void Set_type(int z)
    {
        color = z;
    }
}
