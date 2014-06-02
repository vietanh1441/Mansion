using UnityEngine;
using System.Collections;

public class Medicine : MonoBehaviour {

    public static float speed = 0.5f;
    public static bool isGrounded = false;

    public static int[] pos = new int[1];

    void Start()
    {
        pos[0] = 10;
        pos[1] = 10;
    }
    // Update is called once per frame
    void FixedUpdate()
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
      

    


    /*   public void OnCollisionEnter( Collision theCollision){
           if (theCollision.gameObject.name == "Table" || theCollision.gameObject.name == "Virus")
           {
               isGrounded = true;
           }
       
   }*/

    public bool is_grounded()
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
    }

    public bool is_child()
    {
        if (transform.parent == null)
            return false;
        else
            return true;
    }

}
