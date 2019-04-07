using UnityEngine;
using System.Collections;

public class ItemFuncManager : MonoBehaviour {
    [SerializeField]
    int i_PoolCount;
    [SerializeField]
    float f_Time = 5;

    public GameObject go_ItemPrefab;
    public Transform[] t_ItemCreateSpot;
    public CharacterManager characterMgr;

    bool isCreateItem = false;

    ObjectPoolManager pool = new ObjectPoolManager();
    GameObject[] go_Item;

    void Start()
    {
        pool.Create(go_ItemPrefab, i_PoolCount);
        go_Item = new GameObject[i_PoolCount];

        for (int i = 0; i < go_Item.Length; i++)
        {
            go_Item[i] = null;
        }
    }

    void OnEnable()
    {
        isCreateItem = false;
    }

    void OnApplicationQuit()
    {
        pool.Dispose();
    }

    public IEnumerator CreateItem()
    {
        if (!isCreateItem && !characterMgr.isDead)
        {
            for (int i = 0; i < go_Item.Length; i++)
            {
                if (go_Item[i] == null)
                {
                    isCreateItem = true;
                    yield return new WaitForSeconds(f_Time / 2);
                    go_Item[i] = pool.NewItem();
                    go_Item[i].transform.parent = gameObject.transform;
                    go_Item[i].transform.position = t_ItemCreateSpot[Random.Range(0, 30) % 6].position;
                    go_Item[i].SetActive(true);
                    break;
                }
            }
            yield return new WaitForSeconds(f_Time / 2);
            isCreateItem = false;
        }
    }

    public void DeleteItem()
    {
        for (int i = 0; i < go_Item.Length; i++)
        {
            if (go_Item[i] && go_Item[i].transform.position.x < -8)
            {
                pool.RemoveItem(go_Item[i]);
                go_Item[i] = null;
            }
        }
    }

    public void Resolution()
    {
        for (int i = 0; i < go_Item.Length; i++)
        {
            if (go_Item[i])
            {
                go_Item[i].transform.position = gameObject.transform.position;
                pool.RemoveItem(go_Item[i]);
                go_Item[i] = null;
            }
        }
    }
}
