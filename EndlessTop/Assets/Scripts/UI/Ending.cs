using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {

    public float time = 0.0f;
    Transform repeat;
    Transform cong;

	void Start () {
        time = Time.time;
        repeat = GameObject.Find("Message").transform.FindChild("다시하세요");
        cong = GameObject.Find("Message").transform.FindChild("축하합니다");
	}
	
	// Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time - time);

        if (Time.time - time > 1.5f)
        {
            cong.gameObject.SetActive(true);
        }

        if (Time.time - time > 3.5f)
        {
            repeat.gameObject.SetActive(true);
        }

        if (Time.time - time > 5.5f)
        {
            Application.LoadLevel(0);
            StageManager.ending = false;
            StageManager.stage1 = true;
        }
    }


    void ResetTimer()
    {
        if (Time.time - time > 6.0f)
        {
            time = Time.time;
        }
    }
}
