using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour
{
    public int life = 100;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
      //  life = GameObject.Find("fireball 1").GetComponent<BulletScript>().life;
        life = GameObject.Find("Rogue_weapon_01r").GetComponent<NojScript>().lives;
        if (life <= 0)
            Destroy(gameObject);
    }
    

}
