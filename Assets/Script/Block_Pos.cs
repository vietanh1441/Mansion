using UnityEngine;
using System.Collections;

public class Block_Pos : MonoBehaviour {

   //Making a 2 dimensional array which return whether a pos is occupy or not
    public static GameObject[,] pos = new GameObject[30,30];


    //Initialize
    public void Awake()
    {
        Debug.Log("Run Start");
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 30; j++)
                pos[i, j] = null;
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

    //Check for lining up: Input position x,y then return if 
    // that position make something line up
    public static void check_line_up(int x, int y)
    {
        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;
        bool far_left = false;
        bool far_right = false;
        bool far_up = false;
        bool far_down = false;

        //First check for left
        if (is_occupy(x - 1, y))
        {
            if (x >= 1)
            {
                if (pos[x - 1, y].tag == pos[x, y].tag)
                {
                    //Debug.Log("left");
                    left = true;
                }
            }
        }
        //Then check for right
        if (is_occupy(x + 1, y))
        {
            if (pos[x + 1, y].tag == pos[x, y].tag)
            {
                //Debug.Log("right");
                right = true;
            }
        }

        if (is_occupy(x - 2, y))
        {
            if (x >= 2)
            {
                if (pos[x - 2, y].tag == pos[x, y].tag)
                    far_left = true;
            }
        }

        if (is_occupy(x + 2, y))
        {
            if (pos[x + 2, y].tag == pos[x, y].tag)
                far_right = true;
        }

        if (is_occupy(x, y +1))
        {
            if (pos[x, y + 1].tag == pos[x, y].tag)
                up = true;
        }
        if (is_occupy(x, y -1))
        {
            if (y >= 1)
            {
                if (pos[x, y - 1].tag == pos[x, y].tag)
                    down = true;
            }
        }
        if (is_occupy(x, y +2))
        {
           
                if (pos[x, y + 2].tag == pos[x, y].tag)
                    far_up = true;
            
        }
        if (is_occupy(x, y -2))
        {
            if (y >= 2)
            {
                if (pos[x, y - 2].tag == pos[x, y].tag)
                    far_down = true;
            }
        }
        //If both is true => check far left and far right then destroy all 3 
        if (left)
        {
           
            if (right)
            {
                destroy_piece(x, y);
                destroy_piece(x - 1, y);
                destroy_piece(x + 1, y);
                if (far_left)
                    destroy_piece(x - 2, y);
                if (far_right)
                    destroy_piece(x + 2, y);
            }
            else
            {
                if (far_left)
                {
                    destroy_piece(x, y);
                    destroy_piece(x - 1, y);
                    destroy_piece(x - 2, y);
                }
            }
        }
        if (right)
        {
            if (far_right)
            {
                destroy_piece(x, y);
                destroy_piece(x + 1, y);
                destroy_piece(x + 2, y);
            }
        }
        if (up)
        {
            if (down)
            {
                destroy_piece(x, y);
                destroy_piece(x , y+1);
                destroy_piece(x, y -1);
                if (far_up)
                    destroy_piece(x, y +2);
                if (far_down)
                    destroy_piece(x, y-2);
            }
            else
            {
                if (far_up)
                {
                    destroy_piece(x, y);
                    destroy_piece(x, y+1);
                    destroy_piece(x, y+2);
                }
            }
        }
        if (down)
        {
            if (far_down)
            {
                destroy_piece(x, y);
                destroy_piece(x, y - 1);
                destroy_piece(x, y - 2);
            }
        }

        //if only left or right is true, check far left or far right

        //Up and down is the same principle
    }

    //Destroy a position, input x and y and destroy that object, then free up space
    public static void destroy_piece(int x, int y)
    {
        GameObject trans = pos[x, y];
        Destroy(trans);
        pos[x, y] = null;
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

    public static void make_occupy(int x, int y, GameObject gameobj)
    {
        pos[x, y] = gameobj;
        /*Debug.Log("Make this pos 1");
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(pos[x, y]);*/
    }

    public static void make_available(int x, int y)
    {
        pos[x, y] = null;
    }
    public static bool is_occupy(int x, int y)
    {
        if (y <= -1)
            return true;
        if (x <= -1) 
            return true;
        else if (pos[x, y] != null)
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
