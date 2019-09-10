using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {
    public DialogueNode[] node;
    public int _currentNode;
    public bool ShowDialogue = false;
    //public int quest;
    public bool quest;
    bool questend;
    public bool money;
    bool off = true;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ShowDialogue = GameObject.Find("Rogue_01").GetComponent<characterController>().ShowDialogue;
        questend = GameObject.Find("Rogue_01").GetComponent<characterController>().questend;
    }
    void OnGUI()
    {
        if (ShowDialogue == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height - 280, 500, 90), node[_currentNode].NpcText);
            for (int i = 0; i < node [_currentNode].PlayerAnswer.Length; i++) {
                if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height - 200 + 25 * i, 500, 25), node [_currentNode].PlayerAnswer [i].Text)) {
                    if (node [_currentNode].PlayerAnswer [i].SpeakEnd) {
                        ShowDialogue = false;
                    }
                    _currentNode = node [_currentNode].PlayerAnswer [i].ToNode;
                    if (off != false)
                    {
                        if (node[_currentNode].PlayerAnswer[i].ToNode == 1)
                        {
                            quest = true;
                            off = false;
                            // Debug.Log("true");
                        }
                    }
                    if (questend==true)
                    {
                        node[1].PlayerAnswer[0].Text = "Завдання виконано.";
                        //node[0].NpcText = "Что с заданием";
                        if(off!=false)
                        if (node[_currentNode].PlayerAnswer[i].ToNode == 1)
                        {
                            quest = false;
                            money = true;
                                off = false;
                        }
                    }
                    
                }
            }

        }
    }
    }

[System.Serializable]
public class DialogueNode
{
    public string NpcText;
    public Answer[] PlayerAnswer;
}
[System.Serializable]
public class Answer
{ 
    public string Text;
    public int ToNode;
    public bool SpeakEnd;
}