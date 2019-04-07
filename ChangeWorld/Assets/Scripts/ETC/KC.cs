using UnityEngine;
using System.Collections;

public class KC : MonoBehaviour {
    public Transform Popup;

    int d = 0;
    int p = 0;
    int g = 0;

    void OnEnable()
    {
        d = 0;
        p = 0;
        g = 0;

        Popup.gameObject.SetActive(false);
    }

    void Update()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && Input.GetMouseButtonDown(0) && ReinforceManager.isOpenCharacterSelect)
        {
            if (hit.collider.gameObject.name == "D")
                d += 1;

            if (hit.collider.gameObject.name == "P" && d >= 5)
                p += 1;

            if (hit.collider.gameObject.name == "G" && d>= 5 && p >= 5)
                g += 1;

            if (hit.collider.gameObject.name == "popup")
                Popup.gameObject.SetActive(false);
        }

        if (!CharacterOpenValue.isOpenKC && g >= 5)
        {
            CharacterOpenValue.isOpenKC = true;
            Popup.gameObject.SetActive(true);
        }

    }
}
