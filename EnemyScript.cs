using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public Vector3 From; 
    public Vector3 To;
    public float time; 
    private bool toDir;
    bool facingRight = true;
    bool attackc = false;
    GameObject weaperin;
 float move= 1004.4f;
    private Animator animator;
    public float speed = 7f;
    float direction = -1f;
    public bool chark = false;
    public CharState3 State3
    {
        get { return (CharState3)animator.GetInteger("State3"); }
        set { animator.SetInteger("State3", (int)value); }
    }
   
    void Start () {
        animator = GetComponent<Animator>();
        weaperin = GameObject.Find("Rogue_weapon_05r");
    }

    // Update is called once per frame
    void Update() {


        float speed = Mathf.Abs((To - From).magnitude) / time;
        if (chark == false)
        {
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
                State3 = CharState3.Rogue_run_01;


            }
            else
            {
                State3 = CharState3.Rogue_run_01;
                transform.position = Vector3.MoveTowards(transform.position, From, speed);
                transform.localScale = new Vector3(direction, 1, 1);
            }
            // rigidbody2D.velocity = new Vector2(speed * direction, rigidbody2D.velocity.y);
        }
     
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Rogue_01")
        {
            State3 = CharState3.Rogue_attack_03;
            chark = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Rogue_01")
        {
            State3 = CharState3.Rogue_idle_01;
            chark = false;
        }
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "wall")
            direction *= -1f;
    }

}
public enum CharState3
{
    Rogue_idle_01,
    Rogue_attack_03,
    Rogue_run_01
}