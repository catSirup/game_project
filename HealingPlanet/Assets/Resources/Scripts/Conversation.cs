using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour {
    public Texture2D ran1;
    public Texture2D ran2;
    public Texture2D ran3;
    public Texture2D ran4;

    private int i_SelectNum = 0;
    private int randomCheck = 0;

	void Start () 
    {
        gameObject.SetActive(false);
	}

    void OnEnable()
    {
        i_SelectNum = Random.Range(0, 3);
        if (randomCheck == i_SelectNum)
        {
            i_SelectNum = Random.Range(0, 3);
        }

        Render();
    }

    public void Render()
    {
        if (i_SelectNum == 0) { guiTexture.texture = ran1; StartCoroutine(DisalbeConversation()); }
        else if (i_SelectNum == 1) { guiTexture.texture = ran2; StartCoroutine(DisalbeConversation()); }
        else if (i_SelectNum == 2) { guiTexture.texture = ran3; StartCoroutine(DisalbeConversation()); }
        else if (i_SelectNum == 3) { guiTexture.texture = ran4; StartCoroutine(DisalbeConversation()); }
    }

    IEnumerator DisalbeConversation()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
