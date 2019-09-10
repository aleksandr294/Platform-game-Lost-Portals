using UnityEngine;
using System.Collections;

public class Teleportation :KingScripts {
    public float maxSpeed = 0.4f;
    public float move;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
   
    // Use this for initialization
    void Start () {
	
	}
    void FixedUpdate()
    {


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        move = Input.GetAxis("Horizontal");

    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Horizontal")) Run(move, maxSpeed);
        if (Input.GetButton("Vertical")) vertical();
        
          
           
        
    }
  /*/  private void horizontal()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, maxSpeed * Time.deltaTime);
    }/*/
    private void vertical()
    {
        Vector3 direction = transform.up * Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, maxSpeed * Time.deltaTime);
    }
   
}
