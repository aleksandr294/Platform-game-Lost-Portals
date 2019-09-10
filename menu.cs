using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour
{
    public int window=0;
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            window = 1;
            Time.timeScale = 0;
            
        }
    }
    void OnGUI()
    {
        if (window == 1)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
            if (GUI.Button(new Rect(10, 30, 180, 30), "Играть"))
            {
                window = 0;
                Time.timeScale = 1;
            }
            if (GUI.Button(new Rect(10, 70, 180, 30), "Настройки"))
            {

            }
            if (GUI.Button(new Rect(10, 110, 180, 30), "Журнал"))
            {
                window = 3;
            }
            if (GUI.Button(new Rect(10, 150, 180, 30), "Выход"))
            {
                Application.Quit();
            }
                GUI.EndGroup();
            if(window==3)
            {
                // GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
                if (GUI.Button(new Rect(10, 110, 180, 30), "Журнал"))
                    GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 200, 250), "34dfgdgdgdgdgdgdfg5S");

               // GUI.EndGroup();
            }
        }
    }
}
    