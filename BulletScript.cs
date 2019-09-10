using UnityEngine;
using System.Collections;

public class BulletScript :KingScripts {

    public GameObject g;
    public GameObject g1;
    public GameObject g2;
    public GameObject item;
    void Start()
    {
        // уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
    }
    void Update()
    {
           
        
    }
        void OnCollisionEnter2D(Collision2D col)
    {
        
if(col.gameObject.name== "Rogue_06" )
        {
          
            Destroy(gameObject);
            Destroy(g);
            var boar2 = new Vector3(g.transform.position.x, g.transform.position.y + 3, g.transform.position.z);
            Create(item, boar2);

        }
        if (col.gameObject.name == "Rogue_05")
        {
            Destroy(gameObject);
            Destroy(g1);
        }
        if (col.gameObject.name == "Rogue_04 (1)")
        {
            Destroy(gameObject);
            Destroy(g2);
            var boar2 = new Vector3(g2.transform.position.x, g2.transform.position.y + 3, g2.transform.position.z);
            Create(item, boar2);
        }
    }
    }

