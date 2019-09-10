using UnityEngine;
using System.Collections;

public class Wolf : KingScripts {

    public float maxSpeed = 0.4f;
    public float jumpForce = 700f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
   
    public float move;
    public float spawnX, spawnY;
    bool iluss = false;
   
   



    private Animator animator;
    // Use this for initialization
    private CharState2 StateWolf
    {
        get { return (CharState2)animator.GetInteger("State2"); }
        set { animator.SetInteger("State2", (int)value); }
    }
    void Start()
    {
        spawnX = transform.position.x;
        spawnY = transform.position.y;
        animator = GetComponent<Animator>();




    }


    // Update is called once per frame
    void FixedUpdate()
    {


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        move = Input.GetAxis("Horizontal");

    }

    void Update()
    {
        


        StateWolf = CharState2.Wolf_Idle;
        if (Input.GetButton("Horizontal"))
        {
            StateWolf = CharState2.Wolf_run_0;
            Run(move, facingRight, maxSpeed);
            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
        }
        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            StateWolf = CharState2.Wolf_jump_0;
            Jump(jumpForce);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
      

    }
   /*/ private void Run()
    {
        StateWolf = CharState2.Wolf_run_0;
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, maxSpeed * Time.deltaTime);
        if (move > 0 && !facingRight)
            Flip();


        else if (move < 0 && facingRight)
            Flip();

    }
    private void Jump()
    {
        StateWolf = CharState2.Wolf_jump_0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
    }/*/
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
   
    }

public enum CharState2
{
    Wolf_Idle,
    Wolf_run_0,
    Wolf_jump_0
}
