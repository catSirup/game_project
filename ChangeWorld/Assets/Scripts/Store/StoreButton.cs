using UnityEngine;
using System.Collections;

public class StoreButton : MonoBehaviour {
    public StoreManager storeMgr;

    void Update()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            if (storeMgr.curState == StoreManager.StoreState.CHARACTER && hit.collider.gameObject.CompareTag("System"))
            {
                storeMgr.curState = StoreManager.StoreState.SYSTEM;
            }

            else if (storeMgr.curState == StoreManager.StoreState.SYSTEM && hit.collider.gameObject.CompareTag("CharacterStore"))
            {
                storeMgr.curState = StoreManager.StoreState.CHARACTER;
            }
           
        }
    }
}
