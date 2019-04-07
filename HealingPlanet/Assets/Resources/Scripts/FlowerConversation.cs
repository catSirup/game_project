using UnityEngine;
using System.Collections;

public class FlowerConversation : MonoBehaviour {
    public Texture2D num1;
    public Texture2D num2;

    public bool isActive = false;
    private int num = 0;
	void Start () {
        gameObject.SetActive(false);
        num = 0;
        isActive = false;
	}

    void OnEnable()
    {
        Render();
    }

	void Render () {
        if (!isActive)
        {
            if (num == 0) guiTexture.texture = num1;
            else if (num == 1) guiTexture.texture = num2;
            else gameObject.SetActive(false);
            isActive = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            num += 1;
        }
	}
}
