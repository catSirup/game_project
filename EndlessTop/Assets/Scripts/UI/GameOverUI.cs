using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour {
    Transform Background;
    Transform Gameover;
    Transform stageOverFont;

	void Start () {
        Background = GameObject.Find("GameOverUI"). transform.FindChild("GameOverBackground");
        Gameover = GameObject.Find("GameOverUI").transform.FindChild("GameOver");
	}

    void OnEnable()
    {

    }
	
	void Update () {
        Background.gameObject.SetActive(true);
        Gameover.gameObject.SetActive(true);
	}
}
