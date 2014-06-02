using UnityEngine;
using System.Collections;

public class Block_Pos : MonoBehaviour {

   //Making a 2 dimensional array which return whether a pos is occupy or not
    public static int[,] pos = new int[30,30];


    //Initialize
    public void Start()
    {
        Debug.Log("Run Start");
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 30; j++)
                pos[i, j] = 0;
        }
    }

     //Convert position of an object based on its coordinate
    public static Vector3 get_pos(int x, int y)
    {
        Vector3 pos = new Vector3(0, 0);

        pos.x = x * 0.05f;
        pos.y = y * 0.05f;
        pos.z = -8.8f;
        return pos;
    }



    //check down which cell is occupy
    public static int check_down(int x, int y)
    {
        for (int i = y; y >= 0 ; i--)
        {
            if (is_occupy(x, i))
                return i + 1;
        }
        return 0;
    }

    //Convert coordinate by position x
    // ?NO NEED?
    /* public static int get_x(Vector3 position)
     {
         int x;

         x = position.x / 0.05f;
     }*/

    //check if it is occupy by
    //coordinate

    public static void make_occupy(int x, int y)
    {
        pos[x, y] = 1;
        /*Debug.Log("Make this pos 1");
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(pos[x, y]);*/
    }


    public static bool is_occupy(int x, int y)
    {
        if (y == -1)
            return true;
        else if (pos[x, y] == 1)
        {
          //  Debug.Log("TOuch");
            return true;
        }
        else
        {
           /* Debug.Log(pos[x, y]);
            Debug.Log("Nope");
           Debug.Log(x);
           Debug.Log(y);*/
            return false;
        }
    }

  
}
