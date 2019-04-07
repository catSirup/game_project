using UnityEngine;
using System.Collections;

public class Character_Menu : MonoBehaviour {
    public GameObject[] go_Characters;
    
    void OnEnable()
    {
        if (gameObject.transform.rotation.y == 0)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.8f, 0);
        else
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.8f, 0);



        for (int i = 0; i < go_Characters.Length; i++)
        {
            if (i == CharacterSelectManager.i_CurSelectCharacterNumber)
            {
                go_Characters[i].SetActive(true);
            }
            else
            {
                go_Characters[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        if (gameObject.transform.position.x >= 10 && transform.rotation.y == 0)
        {
            gameObject.transform.position = new Vector2(-10, gameObject.transform.position.y);
        }
        else if(gameObject.transform.position.x <= -10 && transform.rotation.y != 0)
            gameObject.transform.position = new Vector2(10, gameObject.transform.position.y);

    }
}
