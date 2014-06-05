using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour {

    public static float speed = 0.5f;
    public static bool isGrounded = false;
    private bool enable = false;
    private bool control_enable = false;
    private int[] pos = new int[2];
    private int color = 0;

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
    void Set_enable(int a)
    {
        enable = true;
    }
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

    //Fixed update every 1 second, move down a pos
    //Every time a key hit left or right, move accordingly
    //If hit down, go down 

    void Update()
    {
        
        if (enable)
        {
            //Debug.Log("call do work");
            control_enable = true;
            call_for_work();
            enable = false;
        }
        if (control_enable)
            control();
    }

    public void call_for_work()
    {
        InvokeRepeating("do_work", 0, 0.5f);
    }

    void control()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Need to check for avaible
            if (!Block_Pos.is_occupy(pos[0] - 1, pos[1]))
            {
                pos[0] = pos[0] - 1;
                transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Need to check for avaible
            if (!Block_Pos.is_occupy(pos[0] + 1, pos[1]))
            {
                pos[0] = pos[0] + 1;
                transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pos[1] = Block_Pos.check_down(pos[0], pos[1]);
            transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 2f);
            landing(pos[0], pos[1], gameObject);   
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!Block_Pos.is_occupy(pos[0], pos[1] - 1))
            {
                pos[1] = pos[1] - 1;
                transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
            }
            if(Block_Pos.is_occupy(pos[0], pos[1] - 1))
                landing(pos[0], pos[1], gameObject);
        }
    }


    void do_work()
    {
        //Debug.Log(pos[0]);
        //Debug.Log(pos[1]);
        if (is_grounded())
        {

            landing(pos[0], pos[1], gameObject);
        }
        else
        {
            Block_Pos.make_available(pos[0], pos[1]);
            pos[1] = pos[1] - 1;
            transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
            //check for is grounded here
            //if grounded, do check lining up
            if (is_grounded())
            {
                landing(pos[0], pos[1], gameObject);
            }
        }
    }

    void landing(int x, int y, GameObject gameobj)
    {
        Block_Pos.make_occupy(pos[0], pos[1], gameobj);
        Block_Pos.check_line_up(pos[0], pos[1]);
        if (control_enable)
        {
            Central.signal = true;
            control_enable = false;
        }
    }

    public bool is_grounded()
    {
        if (pos[1] == 0)
            return true;
        else if (Block_Pos.is_occupy(pos[0], pos[1] - 1))
            return true;
        else
            return false;
    }
	// Update is called once per frame
   /* void FixedUpdate()
    {
        if (!is_child())
        {
            if (!is_grounded())
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);

                //  transform.Translate( , Space.World);
            }
            else
            {
                Debug.Log("Ground");
            }
        }
        else
        {
            Debug.Log(transform.tag);
            Debug.Log("Do Nothing");
         }
    
    }
    */

 /*   public void OnCollisionEnter( Collision theCollision){
        if (theCollision.gameObject.name == "Table" || theCollision.gameObject.name == "Virus")
        {
            isGrounded = true;
        }
       
}*/



    /*public bool is_grounded()
    {
        RaycastHit hit;
        float dist;
        Vector3 dir;

        dist = 0.05f;
        dir = new Vector3(0, -1, 0);

        Debug.DrawRay(transform.position, dir * dist, Color.green);
        if (Physics.Raycast(transform.position, dir, out hit, dist))
        {
            Debug.Log("Hit");
            return true;
        }
        else
        {
            Debug.Log("Nope");
            return false;
        }
    }*/

    public bool is_child()
    {
        if (transform.parent == null)
            return false;
        else
            return true;
    }

//consider when character is jumping .. it will exit collision.
   /* public void OnCollisionExit(Collision theCollision ){
    if(theCollision.gameObject.name == "Virus")
    {
        isGrounded = false;
    }
}*/

    //Now when 
}
