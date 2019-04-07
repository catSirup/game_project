using UnityEngine;
using System.Collections;

public class StageOverNumber : MonoBehaviour {
    Transform stage1;
    Transform stage2;
    Transform stage3;
    Transform stage4;
    Transform stage5;

	void Start () {
        stage1 = GameObject.Find("StageOverFont").transform.Find("Stage1");
        stage2 = GameObject.Find("StageOverFont").transform.Find("Stage2");
        stage3 = GameObject.Find("StageOverFont").transform.Find("Stage3");
        stage4 = GameObject.Find("StageOverFont").transform.Find("Stage4");
        stage5 = GameObject.Find("StageOverFont").transform.Find("Stage5");
	}
	

	void Update () {
        if (StageManager.stage1)
        {
            this.stage1.gameObject.SetActive(true);
            this.stage2.gameObject.SetActive(false);
            this.stage3.gameObject.SetActive(false);
            this.stage4.gameObject.SetActive(false);
            this.stage5.gameObject.SetActive(false);
        }

        else if (StageManager.stage2)
        {
            this.stage1.gameObject.SetActive(false);
            this.stage2.gameObject.SetActive(true);
            this.stage3.gameObject.SetActive(false);
            this.stage4.gameObject.SetActive(false);
            this.stage5.gameObject.SetActive(false);
        }

        else if (StageManager.stage3)
        {
            this.stage1.gameObject.SetActive(false);
            this.stage2.gameObject.SetActive(false);
            this.stage3.gameObject.SetActive(true);
            this.stage4.gameObject.SetActive(false);
            this.stage5.gameObject.SetActive(false);
        }

        else if (StageManager.stage4)
        {
            this.stage1.gameObject.SetActive(false);
            this.stage2.gameObject.SetActive(false);
            this.stage3.gameObject.SetActive(false);
            this.stage4.gameObject.SetActive(true);
            this.stage5.gameObject.SetActive(false);
        }

        else if (StageManager.stage5)
        {
            this.stage1.gameObject.SetActive(false);
            this.stage2.gameObject.SetActive(false);
            this.stage3.gameObject.SetActive(false);
            this.stage4.gameObject.SetActive(false);
            this.stage5.gameObject.SetActive(true);
        }
	}
}
