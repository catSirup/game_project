using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
    public MainManager mainMgr;

    void OnEnable()
    {
        StartCoroutine(BacktoMain());
    }

    IEnumerator BacktoMain()
    {
        while (mainMgr.curState != MainManager.MainState.MAIN)
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.name == "Back" && Input.GetMouseButtonDown(0))
                    mainMgr.curState = MainManager.MainState.MAIN;
            }
            yield return null;
        }
    }
}
