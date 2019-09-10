using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ProgressBar : MonoBehaviour {
   Image loading;
    Text text;
     int sceneID;
	// Use this for initialization
	void Start () {
        StartCoroutine(Asyncload(loading, text, sceneID));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public IEnumerator Asyncload(Image loading, Text text, int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loading.fillAmount = progress;
            text.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
