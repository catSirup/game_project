using UnityEngine;
using System.Collections;

public class BigBangTimeValue : MonoBehaviour {

    private float time;

	void Start () {
        time = 0;
	}
    public void SetTime(float time)
    {
        this.time = time;
    }

    public float GetTime()
    {
        return time;
    }
}
