using UnityEngine;
using System.Collections;

public class PlayManager : MonoBehaviour
{
    public SceneManager sceneMgr;
    public MainManager mainMgr;
    public CharacterManager characterMgr;
    public ObstacleFuncManager obstacleFuncMgr;
    public BulletFuncManager bulletFuncMgr;
    public CoinFuncManager coinFuncMgr;
    public ItemFuncManager itemFuncMgr;
    
    public Transform t_Explanation;
    public Transform t_ResultWindow;
    public Transform t_Score;

    //bool isSave = false;

    void OnEnable()
    {
        characterMgr.Init();
        bulletFuncMgr.Init();
        Explanation.b_IsDisapear = false;
        t_Explanation.gameObject.SetActive(true);
        t_Score.gameObject.SetActive(false);
        t_ResultWindow.gameObject.SetActive(false);
        characterMgr.gameObject.SetActive(true);

        //isSave = false;
    }

    void OnDisable()
    {
        PointManager.i_CurHavePoint += characterMgr.i_GainPoint;

        //isSave = false;
    }

    void Update()
    {
        characterMgr.Move();

        if (Explanation.b_IsDisapear)
        {
            t_Score.gameObject.SetActive(true);
            StartCoroutine(obstacleFuncMgr.CreateObstacle());
            StartCoroutine(bulletFuncMgr.CreateBullet());
            StartCoroutine(coinFuncMgr.CreateCoin());
            StartCoroutine(itemFuncMgr.CreateItem());

            obstacleFuncMgr.DeleteObstacle();
            bulletFuncMgr.Resolution();
            itemFuncMgr.DeleteItem();
            coinFuncMgr.DeleteCoin();

            characterMgr.Sound();
        }

        if (characterMgr.isDead)
        {
            t_Score.gameObject.SetActive(false);
            obstacleFuncMgr.Resolution();
            coinFuncMgr.Resolution();
            itemFuncMgr.Resolution();
            bulletFuncMgr.DeleteBullet();
            t_ResultWindow.gameObject.SetActive(true);
            characterMgr.gameObject.SetActive(false);
            ObstacleVelocity.i_CurCreateCount = 0;
            ObstacleVelocity.f_PlusSpeed = 0;

            //if (!isSave)
            //{
            //    SceneManager.SaveData();
            //    isSave = true;
            //}
        }
    }
}
