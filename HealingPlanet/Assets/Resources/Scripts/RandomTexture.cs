using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour {
    Material plan0;
    Material plan1;
    Material plan2;
    Material plan3;
    Material plan4;
    Material plan5;
    Material plan6;
    Material plan7;

    int i_SelectNum = 0;
    public Material[] plan = new Material[8];

	void Start () {
        i_SelectNum = Random.Range(1, plan.Length);
        RandomPlan();
	}


    public void RandomPlan()
    {
        gameObject.renderer.material = plan[i_SelectNum];
    }
}
