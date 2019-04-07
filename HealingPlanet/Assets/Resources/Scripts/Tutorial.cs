using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
    public Texture2D tu1;
    public Texture2D tu2;
    public Texture2D tu3;
    public Texture2D tu4;
    public Texture2D tu5;
    public Texture2D tu6;
    public Texture2D tu7;
    public Texture2D tu8;
    public Texture2D tu9;
    public Texture2D tu10;
    public Texture2D tu11;
    public Texture2D tu12;
    public Texture2D tu13;
    public Texture2D tu14;
    public Texture2D tu15;

    int Count = 0;

	void Start () 
    {
        guiTexture.texture = tu1;
        Count = 0;
	}

	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
            Count += 1;

        if (Count >= 15)
        {
            if (Input.GetMouseButtonDown(0))
                Application.LoadLevel("Scene");
        }

        switch (Count)
        {
            case 0:
                guiTexture.texture = tu1;
                break;

            case 1:
                guiTexture.texture = tu2;
                break;

            case 2:
                guiTexture.texture = tu3;
                break;

            case 3:
                guiTexture.texture = tu4;
                break;

            case 4:
                guiTexture.texture = tu5;
                break;

            case 5:
                guiTexture.texture = tu6;
                break;

            case 6:
                guiTexture.texture = tu7;
                break;

            case 7:
                guiTexture.texture = tu8;
                break;

            case 8:
                guiTexture.texture = tu9;
                break;

            case 9:
                guiTexture.texture = tu10;
                break;

            case 10:
                guiTexture.texture = tu11;
                break;

            case 11:
                guiTexture.texture = tu12;
                break;

            case 12:
                guiTexture.texture = tu13;
                break;

            case 13:
                guiTexture.texture = tu14;
                break;

            case 14:
                guiTexture.texture = tu15;
                break;
        }
	}
}
