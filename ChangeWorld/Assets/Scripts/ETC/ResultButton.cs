using UnityEngine;
using System.Collections;

public class ResultButton : MonoBehaviour
{
    public SceneManager sceneMgr;
    public MainManager mainMgr;
    public Sprite[] sprite_OnOff;
    SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite_OnOff[0];
    }

    void Update()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && Input.GetMouseButtonUp(0))
        {
            StartCoroutine(Restart(hit));
            StartCoroutine(GotoStore(hit));
            StartCoroutine(GotoMain(hit));
        }
    }

    IEnumerator Restart(RaycastHit2D hit)
    {
        if (hit.transform.CompareTag("Restart") && gameObject.name == "Button_Restart")
        {
            spriteRenderer.sprite = sprite_OnOff[1];
            yield return new WaitForSeconds(0.2f);
            sceneMgr.curState = SceneManager.SceneState.LOADING;
        }
    }

    IEnumerator GotoStore(RaycastHit2D hit)
    {
        if (hit.transform.CompareTag("Store") && gameObject.name == "Button_Store")
        {
            spriteRenderer.sprite = sprite_OnOff[1];
            yield return new WaitForSeconds(0.2f);
            sceneMgr.curState = SceneManager.SceneState.MAIN;
            mainMgr.curState = MainManager.MainState.STORE;
        }
    }

    IEnumerator GotoMain(RaycastHit2D hit)
    {
        if (hit.transform.CompareTag("GotoMain") && gameObject.name == "Button_GotoMain")
        {
            spriteRenderer.sprite = sprite_OnOff[1];
            yield return new WaitForSeconds(0.2f);
            sceneMgr.curState = SceneManager.SceneState.MAIN;
            mainMgr.curState = MainManager.MainState.MAIN;
        }
    }
}
