using UnityEngine;
using System.Collections;

public class BulletFuncManager : MonoBehaviour
{

    #region Values

    [SerializeField]
    int i_PoolCount = 20;

    [SerializeField]
    float f_InitBulletCycle = 2.75f;
    [SerializeField]
    float f_InitBulletDamage = 2;
    [SerializeField]
    float f_InitBulletArea = 40;

    public static float f_BulletCycle = 0;
    public static float f_BulletDamage = 0;
    public static float f_BulletArea = 0;

    float f_PlusBulletDamage = 1.5f;
    float f_PlusBulletArea = 10;
    float f_MinusBulletCycle = 0.25f;

    bool isCreateObject = false;

    #endregion

    public AudioClip shootSound;

    public GameObject go_BulletPrefab;
    public Transform t_BulletCreateSpot;

    ObjectPoolManager pool = new ObjectPoolManager();
    GameObject[] go_Bullets;

    public CharacterManager characterMgr;

    void Awake()
    {
        pool.Create(go_BulletPrefab, i_PoolCount);
        go_Bullets = new GameObject[i_PoolCount];

        for (int i = 0; i < go_Bullets.Length; i++)
        {
            go_Bullets[i] = null;
        }
    }

    public void Init()
    {
        isCreateObject = false;

        f_BulletDamage = f_InitBulletDamage + (ReinforceManager.i_CurBulletDamageLevel * f_PlusBulletDamage);
        f_BulletArea = f_InitBulletArea + (ReinforceManager.i_CurBulletAreaLevel * f_PlusBulletArea);
        f_BulletCycle = f_InitBulletCycle - (ReinforceManager.i_CurBulletCycleLevel * f_MinusBulletCycle);
    }

    void OnApplicationQuit()
    {
        pool.Dispose();
    }

    public IEnumerator CreateBullet()
    {
        yield return new WaitForSeconds(f_BulletCycle / 2);
        if (!isCreateObject && !CharacterManager.isBumped && ReinforceManager.b_CanFire)
        {
            for (int i = 0; i < go_Bullets.Length; i++)
            {
                if (go_Bullets[i] == null)
                {
                    go_Bullets[i] = pool.NewItem();
                    go_Bullets[i].transform.parent = gameObject.transform;
                    go_Bullets[i].transform.position = t_BulletCreateSpot.position;
                    go_Bullets[i].SetActive(true);
                    isCreateObject = true;

                    if (Explanation.b_IsDisapear)
                        AudioSource.PlayClipAtPoint(shootSound, transform.position);

                    break;
                }
            }
            yield return new WaitForSeconds(f_BulletCycle / 2);
            isCreateObject = false;
        }
    }

    public void DeleteBullet()
    {
        for (int i = 0; i < go_Bullets.Length; i++)
        {
            if (go_Bullets[i])
            {
                go_Bullets[i].transform.position = gameObject.transform.position;
                pool.RemoveItem(go_Bullets[i]);
                go_Bullets[i] = null;
            }
        }
    }

    public void Resolution()
    {
        for (int i = 0; i < go_Bullets.Length; i++)
        {
            if (go_Bullets[i] && go_Bullets[i].transform.position.x > 8)
            {
                go_Bullets[i].transform.position = gameObject.transform.position;
                pool.RemoveItem(go_Bullets[i]);
                go_Bullets[i] = null;
            }
        }
    }
}


