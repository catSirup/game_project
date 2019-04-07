using UnityEngine;
using System.Collections;

public class ObstacleFuncManager : MonoBehaviour
{
    [SerializeField]
    int i_PoolCount;

    public GameObject go_ObstaclePrefab;
    public Transform t_ObstacleCreateSpot;
    public CharacterManager characterMgr;

    bool isCreateObstacle = false;
    ObjectPoolManager pool = new ObjectPoolManager();
    GameObject[] go_Obstacle;

    void Start()
    {
        pool.Create(go_ObstaclePrefab, i_PoolCount);
        go_Obstacle = new GameObject[i_PoolCount];

        for (int i = 0; i < go_Obstacle.Length; i++)
        {
            go_Obstacle[i] = null;
        }
    }

    void OnEnable()
    {
        isCreateObstacle = false;

        if (ReinforceManager.i_CurObstacleGraphicsUpgradeLevel == 0)
            ObstacleSpriteManager.count = 0;

        else if (ReinforceManager.i_CurObstacleGraphicsUpgradeLevel == 1)
            ObstacleSpriteManager.count = 1;

        else if (ReinforceManager.i_CurObstacleGraphicsUpgradeLevel == 2)
            ObstacleSpriteManager.count = 2;

        else if (ReinforceManager.i_CurObstacleGraphicsUpgradeLevel == 3)
            ObstacleSpriteManager.count = 5;
    }

    void OnApplicationQuit()
    {
        pool.Dispose();
    }

    public IEnumerator CreateObstacle()
    {
        if (!isCreateObstacle && !CharacterManager.isBumped)
        {
            for (int i = 0; i < go_Obstacle.Length; i++)
            {
                if (go_Obstacle[i] == null)
                {
                    if (i != 0 && go_Obstacle[i - 1].transform.position.x < 4)
                    {
                        isCreateObstacle = true;
                        go_Obstacle[i] = pool.NewItem();
                        go_Obstacle[i].transform.position = t_ObstacleCreateSpot.position;
                    
                        go_Obstacle[i].SetActive(true);
                    }

                    else if (i == 0)
                    {
                        isCreateObstacle = true;
                        go_Obstacle[i] = pool.NewItem();
                        go_Obstacle[i].transform.position = t_ObstacleCreateSpot.position;
                    
                        go_Obstacle[i].SetActive(true);
                    }

                    break;
                }
            }

            yield return null;
            //yield return new WaitForSeconds(f_Time);
            isCreateObstacle = false;
        }
    }

    public void DeleteObstacle()
    {
        for (int i = 0; i < go_Obstacle.Length; i++)
        {
            if (go_Obstacle[i] && go_Obstacle[i].transform.position.x < - 8)
            {
                pool.RemoveItem(go_Obstacle[i]);
                go_Obstacle[i] = null;
            }
        }
    }

    public void Resolution()
    {
        for (int i = 0; i < go_Obstacle.Length; i++)
        {
            if (go_Obstacle[i])
            {
                go_Obstacle[i].transform.position = gameObject.transform.position;
                pool.RemoveItem(go_Obstacle[i]);
                go_Obstacle[i] = null;
            }
        }
    }
}
