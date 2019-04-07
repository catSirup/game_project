using UnityEngine;
using System.Collections;

public class DelayTimeValue : MonoBehaviour {
    private float delayTime1;
    private float delayTime2;
    private float delayTime3;
    private float delayTime4;
    private float delayTime5;
    private float delayTime6;

	void Start () 
    {
        SetDeleyTime1();
        SetDeleyTime2();
        SetDeleyTime3();
        SetDeleyTime4();
        SetDeleyTime5();
        SetDeleyTime6();
	}

    public void SetDeleyTime1()
    {
        delayTime1 = Time.time;
    }

    public void SetDeleyTime2()
    {
        delayTime2 = Time.time;
    }

    public void SetDeleyTime3()
    {
        delayTime3 = Time.time;
    }

    public void SetDeleyTime4()
    {
        delayTime4 = Time.time;
    }

    public void SetDeleyTime5()
    {
        delayTime5 = Time.time;
    }

    public void SetDeleyTime6()
    {
        delayTime6 = Time.time;
    }

    public float GetDeleyTime1()
    {
        return delayTime1;
    }

    public float GetDeleyTime2()
    {
        return delayTime2;
    }

    public float GetDeleyTime3()
    {
        return delayTime3;
    }

    public float GetDeleyTime4()
    {
        return delayTime4;
    }

    public float GetDeleyTime5()
    {
        return delayTime5;
    }

    public float GetDeleyTime6()
    {
        return delayTime6;
    }
}
