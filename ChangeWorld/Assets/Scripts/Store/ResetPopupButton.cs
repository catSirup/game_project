using UnityEngine;
using System.Collections;

public class ResetPopupButton : MonoBehaviour {
    public Sprite[] sprite_OnOff;

    SpriteRenderer spriteRenderer;

    public SceneManager sceneMgr;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        spriteRenderer.sprite = sprite_OnOff[0];
    }

    void Update()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.gameObject.name == "Yes")
            {
                StartCoroutine(Yes());
            }

            else if (hit.collider.gameObject.name == "No")
            {
                StartCoroutine(No());
            }
        }
    }

    IEnumerator Yes()
    {
        if (this.gameObject.name == "Yes")
            spriteRenderer.sprite = sprite_OnOff[1];

        yield return new WaitForSeconds(0.5f);
        sceneMgr.InitData();
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator No()
    {
        if(this.gameObject.name == "No")
            spriteRenderer.sprite = sprite_OnOff[1];

        yield return new WaitForSeconds(0.5f);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
