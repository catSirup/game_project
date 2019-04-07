using UnityEngine;
using System.Collections;

public class ObstacleOnOff : MonoBehaviour
{
    public GameObject[] go_Obstacles;
    public static int i_Count = 3;
    public static int num = 0;
    static bool isEnd = false;
    static bool isFirst = false;

    void OnEnable()
    {
        RandomValueSetting();

        for (int i = 0; i < go_Obstacles.Length; i++)
        {
            if (i == i_Count || i == i_Count - 1)
            {
                go_Obstacles[i].SetActive(false);
                go_Obstacles[i].GetComponent<Collider2D>().enabled = false;
            }

            else
            {
                go_Obstacles[i].SetActive(true);
                go_Obstacles[i].GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    void RandomValueSetting()
    {
        if (i_Count >= 1 && i_Count <= 4)
        {
            i_Count = Random.Range(i_Count - 1, i_Count + 3);
            if (i_Count == 0)
                i_Count = 1;
            else if (i_Count == 6)
                i_Count = 5;
        }

        else if (i_Count == 1)
        {
            if (!isFirst)
            {
                i_Count = Random.Range(1, 4);
                isFirst = true;
            }

            else
            {
                i_Count = 2;
                isFirst = false;
            }

        }

        else if (i_Count == 5)
        {
            if (!isEnd)
            {
                i_Count = Random.Range(3, 6);
                isEnd = true;
            }

            else
            {
                i_Count = 4;
                isEnd = false;
            }
        }
    }


}
