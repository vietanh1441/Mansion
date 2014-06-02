using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour {

    public static float speed = 0.5f;
    public static bool isGrounded = false;
    

    public static int[] pos = new int[2];

    void Start()
    {
         
        pos[0] = 10;
        pos[1] = 10;
        transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
        InvokeRepeating("do_work", 0, 2f);
    }

    //Fixed update every 1 second, move down a pos
    //Every time a key hit left or right, move accordingly
    //If hit down, go down 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Need to check for avaible
            pos[0] = pos[0] - 1;
            transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Need to check for avaible
            pos[0] = pos[0] + 1;
            transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pos[1] = Block_Pos.check_down(pos[0], pos[1]);
            transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
        }
    }

    void do_work()
    {
        //Debug.Log(pos[0]);
        //Debug.Log(pos[1]);
        if (is_grounded())
        {
            
            Debug.Log("Nothing");
        }
        else
        {
            Block_Pos.pos[pos[0], pos[1]] = 0;
            pos[1] = pos[1] - 1;
            transform.position = Vector3.Lerp(transform.position, Block_Pos.get_pos(pos[0], pos[1]), 1);
            //check for is grounded here
            //if grounded, do check lining up
            if (is_grounded())
            {
                Block_Pos.pos[pos[0], pos[1]] = 1;
                Debug.Log("Check for lining up");
            }
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
