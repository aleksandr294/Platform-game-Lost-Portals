using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Menu1 : ProgressBar
{
    public Image loading;
    public Text text1;
    public int sceneID;
    public int i;
    public Texture text;
    public GameObject gameobject;
 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
   
    public void OnMouseUp()
    {
        if (i == 1)
        {
            StartCoroutine(Asyncload(loading, text1, sceneID));
            //Application.LoadLevel("Forest of the Tavern"); 
        }
        if(i==2)
        { gameobject.SetActive(true); }
        if (i == 3)
        { Application.Quit(); }
        if (i == 4)
        { gameobject.SetActive(false); }
        if (i == 5)
        { gameobject.SetActive(true); }
        if (i == 6)
        { gameobject.SetActive(false); }
    }
   
}
