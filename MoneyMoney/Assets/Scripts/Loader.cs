using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    public GameObject gameMgr;
    GameObject obj;

    void Awake()
    {
        if (GameManager.instance == null)
            obj = Instantiate(gameMgr);

        obj.transform.parent = gameObject.transform;
    }
}
