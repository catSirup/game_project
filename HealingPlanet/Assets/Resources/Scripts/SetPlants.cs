using UnityEngine;
using System.Collections;

public class SetPlants : MonoBehaviour {
    PlayerController player;

    void Start()
    {
        player = GameObject.Find("0 - Background").transform.FindChild("PlayManager").transform.FindChild("Player").GetComponent<PlayerController>();
    }

    IEnumerator OnMouseDown()
    {
        Vector3 scrSpace = Camera.main.WorldToScreenPoint (transform.position);
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));

        if (player.b_DontMove)
        {
            while (Input.GetMouseButton(0))
            {
                Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
                transform.position = curPosition;
                yield return null;
            }  
        }
    }
}
