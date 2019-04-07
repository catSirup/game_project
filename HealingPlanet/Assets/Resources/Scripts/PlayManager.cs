using UnityEngine;
using System.Collections;

public class PlayManager : MonoBehaviour 
{
    public UIManager uiManager;
    public PlayerController s_Player;
    public CollisionCheck c_Player;
    public RotationPlanet sky;
    public Sun sun;

    public Transform conversation;

    private bool isExit = false;

	void Start () 
    {
        StartCoroutine(DelayConversation());
	}

    public void Init()
    {
        s_Player.Init();
        c_Player.Init();
        isExit = false;
    }

    void Render()
    {
        uiManager.Render();
    }

    void SetupInput()
    {
        s_Player.MovePlayer();
    }

    void FixedUpdate()
    {
        Render();
        SetupInput();
        sky.RotatePlanet();
        sun.SunLight();

        if (Input.GetKeyUp(KeyCode.Escape) && !isExit)
        {
            isExit = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isExit)
        {
            Application.LoadLevel(0);
        }
    }

    void Update()
    {
        s_Player.InputKey();

        if (isExit)
        {
            StartCoroutine(DelayTime());
        }

    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(3);
        isExit = false;
    }

    IEnumerator DelayConversation()
    {
        yield return new WaitForSeconds(20);
        conversation.gameObject.SetActive(true);
        StartCoroutine(DelayConversation());
    }
}
