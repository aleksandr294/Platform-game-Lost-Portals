using UnityEngine;
using System.Collections;

public class characterController : KingScripts
{ bool cr;
    bool key;
    public float maxSpeed = 0.4f;
    public float jumpForce = 700f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float life = 100f;
    private float lives = 3;
    public int score;
    public int k;
    public float move;
    public float spawnX, spawnY;
    private GameObject star;
    int fireball = 20;
    public GameObject prefab;
    public GameObject Rogue_01;
    GameObject teleport;
    bool on_off=false;
    int n = 0;
    bool money ;
  public  bool ShowDialogue;
    public int mushroom;
    public bool openquest=false;
    public float i = 13f;
    public bool questend;
    public int mon;
    int keus = 0;
    bool keys = false;
    public int mon1;
    public float speed =20; // скорость пули
    public Rigidbody2D bullet; // префаб нашей пули
    public Transform gunPoint; // точка рождения
    public float fireRate = 1; // скорострельность
    public Transform zRotate; // объект для вращения по оси Z
    bool end = false;
    // ограничение вращения
    public float minAngle = -40;
    public float maxAngle = 40;
    bool zak = false;
    private float curTimeout;
   bool table=false;
    public Texture[] Table = new Texture[5];
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }
    private Animator animator;
    // Use this for initialization

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

        State = CharState.Idle;
        if (on_off == false)
        {
            if (Input.GetButton("Horizontal"))
            {
                State = CharState.Rogue_run_01;
                Run(move, facingRight, maxSpeed);
                if (move > 0 && !facingRight)
                    Flip();
                else if (move < 0 && facingRight)
                    Flip();
            }
            if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) Jump(jumpForce);
            if (Input.GetKeyDown(KeyCode.F)) attack();
            if (Input.GetKeyDown(KeyCode.Q))
            {if(fireball>=0)
                   
                fire();
                fireball--;
            }
            else
            {
                curTimeout = 100;
            }

            if (zRotate) SetRotation();
            if (Input.GetKeyDown(KeyCode.C)) health();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            on_off = true;
            CreationOfPortals(); }
        if (Input.GetKeyDown(KeyCode.J)) on_offfonc();


          /*/  if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        /*/
           

        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (life <= 0)
        {

            Application.LoadLevel(Application.loadedLevel);
        }
        openquest = GameObject.Find("2D-Fantasy-Wizards-Sprite-Sheets-4").GetComponent<Dialog>().quest;
      
        if (openquest==true)
        {
            QuestMushroomSearch();
        }
    }
   /*/ private void Run()
    {
        State = CharState.Rogue_run_01;
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, maxSpeed * Time.deltaTime);
        if (move > 0 && !facingRight)
            Flip();


        else if (move < 0 && facingRight)
            Flip();

    }/*/
  /*/  private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
    }/*/
    private void attack()
    {


        State = CharState.Rogue_attack_01;


    }
    private void fire()
    {
        curTimeout += Time.deltaTime;

        if (curTimeout > fireRate)
        {
            curTimeout = 0;
            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
            clone.name = "fireball";
            clone.velocity = transform.TransformDirection(gunPoint.right * speed);
            clone.transform.right = gunPoint.right;
        }
    }
    void SetRotation()
    {
        Vector3 mousePosMain = Input.mousePosition;
        mousePosMain.z = Camera.main.transform.position.z;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void  CreationOfPortals()
    {
      
            var position = Rogue_01.transform.position;
           var x = position.x; x = x + 10;
            var y = position.y; y = y + 5;
         teleport = Instantiate(prefab) as GameObject;
          teleport.transform.position = new Vector3(x, y, 9);
     /*/   var position = new Vector3(Rogue_01.transform.position.x+10, Rogue_01.transform.position.y + 10,Rogue_01.transform.position.z);
            teleport = prefab;
            Create(prefab,position);/*/
            teleport.AddComponent<Rigidbody2D>();
            n++;
            teleport.name = "Teleport" + n;
            teleport.GetComponent<Teleportation>().enabled = true;
        if (n == 2)
            n = 0;
        
    
    }
    public void QuestMushroomSearch()
    { 

        if (mushroom == 3)
        {
            questend = true;
        }
      
           
    }
    private void on_offfonc ()
    {
        on_off = false;
        
    teleport.GetComponent<Teleportation>().enabled = false;

        
        }
		
private void health()
        {
        if (lives > 0)
        {
            life = life + 50;
            lives--;
        }
        }
    void Flip()
      {
          facingRight = !facingRight;
          Vector3 theScale = transform.localScale;
          theScale.x *= -1;
          transform.localScale = theScale;
      }
   

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "money")
        {
            Destroy(col.gameObject);
            mon++;
        }
        if (col.gameObject.name == "2D-Fantasy-Wizards-Sprite-Sheets-4")
        {
           ShowDialogue=true;
           // ShowDialogue = GameObject.Find("2D-Fantasy-Wizards-Sprite-Sheets-4").GetComponent<Dialog>().ShowDialogue;
           
        }
       
        if (col.gameObject.name == "crystal")
        {
            Destroy(col.gameObject);
            k++;
        }
      
        if (col.gameObject.name == "Teleport1")
        {
           
            GameObject teleport2 = GameObject.Find("Teleport1");
            teleport = GameObject.Find("Teleport2");
            var position = teleport.transform.position;
            var x = position.x;
            var y = position.y;
          Rogue_01.transform.position = new Vector3(x, y, 9);
            Destroy(teleport,0.5f);
            Destroy(teleport2, 0.5f);
        }
        if (col.gameObject.name == "main_кристалл" || col.gameObject.name == "main_кристалл(Clone)")
        {
            Destroy(col.gameObject);
            mushroom++;
        }
        if (col.gameObject.name == "keys(Clone)")
        {
            Destroy(col.gameObject);
            keus++;
            keys = true;
        }
        if (col.gameObject.name == "Rogue_weapon_05r" || col.gameObject.name == "Rogue_weapon_04r")
        {
            life = life - 10;
        }
        if(col.gameObject.name=="table")
        {
            table = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "2D-Fantasy-Wizards-Sprite-Sheets-4")
            ShowDialogue = false;
        if (col.gameObject.name == "table")
        {
            table = false;
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        for (int i = 0; i < 12; i++)
        { if (col.gameObject.name == "saw"+i )
            {
                GameObject saw = GameObject.Find("saw"+i);
                var position = saw.transform.position;
                var x = position.x - 15;
                var y = position.y - 10;
                var z = position.z + 7;
                transform.position = new Vector3(x, y, z);
                State = CharState.Rogue_death_0;
                //transform.position = new Vector3(spawnX, spawnY, transform.position.z);
                life = life - 15;
            }
        }
      
       if (col.gameObject.name == "dieCollider" || col.gameObject.name == "Water")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
      


        if (col.gameObject.name == "Пещера")
            zak = true;
        if (col.gameObject.name != "Пещера")
            zak =false;
        if (col.gameObject.name == "Выход")
            Application.LoadLevel("Forest of the Tavern");
        if (col.gameObject.name == "№_17 (43)")
            Application.LoadLevel("Prancing Bear Tavern");
        if (col.gameObject.name == "prancing_bear_tavern" && keus==1)
            Application.LoadLevel("Cave");
        if (col.gameObject.name == "prancing_bear_tavern" && keus == 0)
            key = true;
        if (col.gameObject.name == "teleporter_visible__x1_portal_png_1354836401.1384784518_0 (2)" && k==3)
            end = true;
        if (col.gameObject.name == "teleporter_visible__x1_portal_png_1354836401.1384784518_0 (2)" && k<3)
            cr = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Пещера")
            zak = false;
        if (col.gameObject.name == "prancing_bear_tavern")
            key = false;
        if (col.gameObject.name == "teleporter_visible__x1_portal_png_1354836401.1384784518_0 (2)")
           cr = false;
    }
        void OnGUI()
    {
        money = GameObject.Find("2D-Fantasy-Wizards-Sprite-Sheets-4").GetComponent<Dialog>().money;
        if (money == true)
        {
            score = +100;
            money = false;
        }
        mon1 = score + mon;
        GUI.Box(new Rect(0, 0, 100, 100), "Монеты: " + mon1 + "\n" +"Фаерболы: " +fireball+"\n"+ "Кристаллы: " + k+ "/3"+"\n" +"Жизнь:"+life +"\n"+ "Пополнение:"+lives);
       if(openquest==true)
            GUI.Box(new Rect(0, 110, 100, 50), "Грибы:"+mushroom);
        if (keys == true)
            GUI.Box(new Rect(0, 110, 100, 50), "Ключ:" + keus);
        if (end == true)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Вітаю! Ви пройшли гру"))
                Application.LoadLevel("Menu");
        }
        if(zak==true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Прохід завалено");
        }
        if (zak ==false)
        {

        }
        if (key == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Для входу потрібен ключ");
        }
        if (key == false)
        {

        }
        if (cr == true)
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 300, 100), "Щоб пройти через портал потрібно 3 кристали");
        if (cr == false)
        {

        }
        if(table==true)
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 250), Table[0]);

    }
    
}
public enum CharState
{
    Idle,
    Rogue_run_01,
    Rogue_attack_01,
       Rogue_death_0
}