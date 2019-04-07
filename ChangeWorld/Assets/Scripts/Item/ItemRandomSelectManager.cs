using UnityEngine;
using System.Collections;

public class ItemRandomSelectManager : MonoBehaviour {
    public GameObject[] go_Items;

    void OnEnable()
    {
        int num = Random.Range(0, 3);

        for (int i = 0; i < go_Items.Length; i++)
        {
            if (i == num)
            {
                go_Items[i].SetActive(true);
            }
            else
            {
                go_Items[i].SetActive(false);
            }
        }
    }
}
