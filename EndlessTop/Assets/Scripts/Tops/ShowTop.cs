using UnityEngine;
using System.Collections;

public class ShowTop : MonoBehaviour {
    Transform EnemyTop1;
    Transform EnemyTop2;
    Transform EnemyTop3;
    Transform EnemyTop4;

    Transform Player;
    Transform ProtectTop;

    public UI ui;

	void Start () {
	    EnemyTop1 = GameObject.Find("2 - Foreground").transform.Find("EnemyTop1");
        EnemyTop2 = GameObject.Find("2 - Foreground").transform.Find("EnemyTop2");
        EnemyTop3 = GameObject.Find("2 - Foreground").transform.Find("EnemyTop3");
        EnemyTop4 = GameObject.Find("2 - Foreground").transform.Find("EnemyTop4");

        Player = GameObject.Find("2 - Foreground").transform.Find("Player");
        ProtectTop = GameObject.Find("2 - Foreground").transform.Find("ProtectTop");

        ui = GameObject.Find("UI").GetComponent<UI>();
	}
	
	void Update () {
        if (ui.pushSpaceKey)
        {
            EnemyTop1.gameObject.SetActive(true);
            EnemyTop2.gameObject.SetActive(true);
            EnemyTop3.gameObject.SetActive(true);
            EnemyTop4.gameObject.SetActive(true);

            Player.gameObject.SetActive(true);
            ProtectTop.gameObject.SetActive(true);
        }
	}
}
