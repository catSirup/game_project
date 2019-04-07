using UnityEngine;
using System.Collections;

public class CoinFuncManager : MonoBehaviour {
    [SerializeField]
    int i_PoolCount;
    [SerializeField]
    float f_Time = 5;

    public GameObject go_CoinPrefab;
    public Transform[] t_CoinCreateSpot;
    public CharacterManager characterMgr;

    bool isCreateCoin = false;
    int num = 0;

    ObjectPoolManager pool = new ObjectPoolManager();
    GameObject[] go_Coin;

    void Start()
    {
        pool.Create(go_CoinPrefab, i_PoolCount);
        go_Coin = new GameObject[i_PoolCount];

        for (int i = 0; i < go_Coin.Length; i++)
        {
            go_Coin[i] = null;
        }
    }

    void OnEnable()
    {
        isCreateCoin = false;
        num = 0;
    }

    void OnApplicationQuit()
    {
        pool.Dispose();
    }

    public IEnumerator CreateCoin()
    {
        if (!isCreateCoin && !CharacterManager.isBumped)
        {
            for (int i = 0; i < go_Coin.Length; i++)
            {
                if (go_Coin[i] == null && ObstacleVelocity.i_CurCreateCount % 8 == 0)
                {
                    isCreateCoin = true;
                    go_Coin[i] = pool.NewItem();
                    go_Coin[i].transform.parent = gameObject.transform;
                    go_Coin[i].transform.position = t_CoinCreateSpot[CreateSpot()].position;
                    go_Coin[i].SetActive(true);
                    break;
                }
            }
            yield return new WaitForSeconds(f_Time);
            isCreateCoin = false;
        }
    }

    public void DeleteCoin()
    {
        for (int i = 0; i < go_Coin.Length; i++)
        {
            if (go_Coin[i] && go_Coin[i].transform.position.x < -7)
            {
                pool.RemoveItem(go_Coin[i]);
                go_Coin[i] = null;
            }
        }
    }

    public void Resolution()
    {
        for (int i = 0; i < go_Coin.Length; i++)
        {
            if (go_Coin[i])
            {
                go_Coin[i].transform.position = gameObject.transform.position;
                pool.RemoveItem(go_Coin[i]);
                go_Coin[i] = null;
            }
        }
    }

    int CreateSpot()
    {
        switch (ObstacleOnOff.i_Count)
        {
            case 1:
                num = 0;
                break;
                
            case 2:
                num = 1;
                break;

            case 3:
                num = 2;
                break;

            case 4:
                num = 3;
                break;

            case 5:
                num = 4;
                break;
        }

        return num;
    }
}
