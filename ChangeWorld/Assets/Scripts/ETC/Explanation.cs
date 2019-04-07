using UnityEngine;
using System.Collections;

public class Explanation : MonoBehaviour {
    public static bool b_IsDisapear;

    public Transform t_Popup;


    void OnEnable()
    {
        StartCoroutine(Disapear());

        if (CharacterManager.i_DeadCount >= 2 && !ReinforceManager.b_CanFire)
        {
            t_Popup.gameObject.SetActive(true);
        }

        else
        {
            t_Popup.gameObject.SetActive(false);
        }
    }

    IEnumerator Disapear()
    {
        b_IsDisapear = false;

        while (!b_IsDisapear)
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Explanation"))
                {
                    gameObject.SetActive(false);
                    b_IsDisapear = true;
                }
            }
            yield return null;
        }
    }
}
