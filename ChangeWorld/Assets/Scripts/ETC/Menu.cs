using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public SceneManager sceneMgr;
    public MainManager mainMgr;

    public Sprite[] sprite_OnOff;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        spriteRenderer.sprite = sprite_OnOff[0];

        if (gameObject.CompareTag("Character"))
        {
            if (ReinforceManager.isOpenCharacterSelect)
                spriteRenderer.sprite = sprite_OnOff[1];
            else
                spriteRenderer.sprite = sprite_OnOff[0];
        }

        if (gameObject.CompareTag("Gotcha"))
        {
            if (ReinforceManager.isOpenGotcha)
                spriteRenderer.sprite = sprite_OnOff[1];
            else
                spriteRenderer.sprite = sprite_OnOff[0];
        }
    }

    void Update()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Start"))
            {
                StartCoroutine(Starting());
            }

            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Gotcha") && ReinforceManager.isOpenGotcha)
            {
                StartCoroutine(Gotcha());
            }

            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Character") && ReinforceManager.isOpenCharacterSelect)
            {
                StartCoroutine(CharacterSelect());
            }

            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Store"))
            {
                StartCoroutine(Store());
            }

            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Exit"))
            {
                StartCoroutine(Exit());
            }
        }
    }

    IEnumerator Starting()
    {
        if (gameObject.CompareTag("Start"))
        {
            spriteRenderer.sprite = sprite_OnOff[1];
            yield return new WaitForSeconds(0.2f);
            mainMgr.curState = MainManager.MainState.START;
        }
    }

    IEnumerator Gotcha()
    {
        if (gameObject.CompareTag("Gotcha"))
        {
            spriteRenderer.sprite = sprite_OnOff[2];
            yield return new WaitForSeconds(0.2f);
            mainMgr.curState = MainManager.MainState.GOTCHA;
        }
    }

    IEnumerator CharacterSelect()
    {
        if (gameObject.CompareTag("Character"))
        {
            spriteRenderer.sprite = sprite_OnOff[2];
            yield return new WaitForSeconds(0.2f);
            mainMgr.curState = MainManager.MainState.CHARACTERSELECT;
        }
    }

    IEnumerator Store()
    {
        if (gameObject.CompareTag("Store"))
        {
            spriteRenderer.sprite = sprite_OnOff[1];
            yield return new WaitForSeconds(0.2f);
            mainMgr.curState = MainManager.MainState.STORE;
        }
    }

    IEnumerator Exit()
    {
        if (gameObject.CompareTag("Exit"))
        {
            spriteRenderer.sprite = sprite_OnOff[1];
            yield return new WaitForSeconds(0.2f);
            sceneMgr.curState = SceneManager.SceneState.EXIT;
        }
    }
}
