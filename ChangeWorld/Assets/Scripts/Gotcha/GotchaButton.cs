using UnityEngine;
using System.Collections;

public class GotchaButton : MonoBehaviour
{
    public Transform t_Popup;
    public Transform t_Animation;
    public Transform t_Back;
    public SlotAnimation slotAnimation;
    int num;

    public PopupWindow popupWindow;

    public static bool isPushButton;
    public static bool isGotchaStart;

    public void Init()
    {
        t_Popup.gameObject.SetActive(false);
        t_Animation.gameObject.SetActive(false);
    }

    public void Gotcha()
    {
        if (!isPushButton && !isGotchaStart)
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.name == "Button")
                {
                    t_Back.GetComponent<Collider2D>().enabled = false;

                    if (PointManager.i_CurHavePoint >= 10 && !isGotchaStart)
                    {
                        StartCoroutine(Push());
                    }

                    else if(PointManager.i_CurHavePoint < 10)
                    {
                        t_Popup.gameObject.SetActive(true);

                        num = 13;

                        isPushButton = false;
                        isGotchaStart = false;
                        popupWindow.ImageInfoOnOff(num);
                        t_Back.GetComponent<Collider2D>().enabled = true;
                    }
                }

                if (hit.collider.gameObject.name == "Popup" && !SuccessfulAnimation.isAppear)
                {
                    slotAnimation.Animation();
                    t_Popup.gameObject.SetActive(false);
                    isGotchaStart = false;
                }
            }
        }
    }

    IEnumerator Push()
    {
        isGotchaStart = true;
        isPushButton = true;

        slotAnimation.Animation();
        yield return new WaitForSeconds(1.6f);
        num = popupWindow.RandomSelect(Random.Range(0, 200));
        popupWindow.ImageInfoOnOff(num);

        t_Animation.gameObject.SetActive(true);
        PointManager.i_CurHavePoint -= 10;

        yield return new WaitForSeconds(3.0f);

        t_Popup.gameObject.SetActive(true);
        isPushButton = false;
        isGotchaStart = false;
        t_Back.GetComponent<Collider2D>().enabled = true;
    }
}
