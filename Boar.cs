using UnityEngine;
using System.Collections;

public class Boar : KingScripts
{


    public float seeDistance = 2f;
    public float attackDistance = 2f;
    public float speed = 6;
    public Transform target;
   Rigidbody2D rigidbody2D;
    public Vector3 From;
    public Vector3 To;
    public float time;
   public bool toDir;
    public bool attack=false;
    int live;
    float direction = -1f;
    public GameObject boar;
    void Start()
    {
        //target = GameObject.FindWithTag("Player").transform;
        
    }
    
   

    void Update()
    {
        if (attack == false)
        {
            float speed = Mathf.Abs((To - From).magnitude) / time;
            if (transform.position == To)
            {
                toDir = false;

            }
            else if (transform.position == From)
            {
                toDir = true;

            }
            if (toDir)
            {
                transform.position = Vector3.MoveTowards(transform.position, To, speed);
                transform.localScale = new Vector3(direction, 1, 1);
            


            }
            else
            {
               
                transform.position = Vector3.MoveTowards(transform.position, From, speed);
                transform.localScale = new Vector3(direction, 1, 1);
            }
        }
           /*/ if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
            {
                if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
                {
                    //walk
                    transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);
                }
            }
            else
            {
                //idle
            }/*/
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "box")
            direction *= -1;
    }

}
    

