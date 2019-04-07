using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorSelectScene : Scene
{
    [SerializeField]
    private GameObject colorText;
    [SerializeField]
    private GameObject[] prefab_objs;
    [SerializeField]
    private Transform obj_Parent;
    [SerializeField]
    private Text remainText;
    [SerializeField]
    private Text countText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject[] objs;
    [SerializeField]
    private GameObject menuWindow;
    [SerializeField]
    private ResultWindow resultWindow;
    [SerializeField]
    private GameObject tuturialWindow;

    private float readyTime;
    private bool b_Start;

    private float time;

    /// <summary>
    /// 드래그 관련
    /// </summary>
    private bool b_touchDown;               // 터치를 했는지 안했는지 체크
    private Vector2 touch_offset;           // 차이.
    private Vector2 originVec;              // 처음 터치한 위치
    [SerializeField]
    private float correction;
    private GameObject touchObj;

    public static int remainCount;
    public static int score;

    private bool b_tutorial;

    public override void Initialize()
    {
        SoundManager.soundMgr.StopBGM();
        SoundManager.soundMgr.PlayBGM("Flower_BGM");

        colorText.SetActive(true);
        remainText.gameObject.SetActive(false);
        countText.gameObject.SetActive(true);
        tuturialWindow.gameObject.SetActive(true);

        objs = new GameObject[20];
        CreateFlower();
        readyTime = 4;
        b_Start = false;
        time = 180;
        countText.color = Color.black;

        b_touchDown = false;
        touch_offset = Vector2.zero;

        remainCount = 19;

        score = 0;

        b_tutorial = true;
    }

    public override void Updated()
    {
        if(b_tutorial)
        {
            if(Input.GetMouseButtonDown(0))
            {
                tuturialWindow.SetActive(false);
                b_tutorial = false;
            }
        }

        else
            readyTime -= Time.deltaTime;

        if (readyTime > 1)
            countText.text = ((int)readyTime).ToString();
        else if (readyTime < 1 && readyTime > 0)
        {
            countText.color = new Color(1, 0.85f, 0);
            countText.text = "시작!";
        }
        else
        {
            countText.gameObject.SetActive(false);
            remainText.gameObject.SetActive(true);
            b_Start = true;
        }


        if (b_Start && remainCount != -1)
        {
            time -= Time.deltaTime;

            DragFlower();
        }

        remainText.text = (remainCount + 1).ToString("0");
        scoreText.text = score.ToString("000000");

        if(remainCount == -1)
        {
            remainText.gameObject.SetActive(false);
            resultWindow.gameObject.SetActive(true);
            resultWindow.Init(score + (int)(time / 5) * 5);
            scoreText.text = (score + (int)(time / 5) * 5).ToString();
            Time.timeScale = 0;
        }
    }

    public override void Exit()
    {
        colorText.SetActive(false);

        for (int i = 0; i < objs.Length; i++)
            Destroy(objs[i]);
    }

    private void CreateFlower()
    {
        for(int i = 0; i < 20; i++)
        {
            int c = Random.Range(0, 4);
            GameObject clone = GameObject.Instantiate(prefab_objs[c]);
            clone.name = prefab_objs[c].name;
            clone.transform.parent = obj_Parent;
            clone.GetComponent<SpriteRenderer>().sortingOrder = i + 3;
            clone.transform.position = new Vector3(0, 0, i * -0.1f);
            objs[i] = clone;
        }
    }

    private void DragFlower()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if(Input.GetMouseButtonDown(0)  && hit.collider != null)
        {
            if (hit.collider.CompareTag("Flower"))
            {
                b_touchDown = true;
                touchObj = hit.collider.gameObject;
                originVec = ray.origin;
            }
        }

        if(b_touchDown)
        {
            touch_offset = ray.origin - originVec;

            if(touch_offset.magnitude >= correction && Input.GetMouseButtonUp(0))
            {
                // 좌 또는 우 드래그
                if (Mathf.Abs(touch_offset.x) > Mathf.Abs(touch_offset.y))
                {
                    if (touch_offset.x >= 0)
                    {
                        StartCoroutine(touchObj.GetComponent<Flower>().MoveFlower(Vector2.right));
                    }
                    else
                    {
                        StartCoroutine(touchObj.GetComponent<Flower>().MoveFlower(Vector2.left));
                    }
                    SoundManager.soundMgr.PlayES("Flower_Drag1");
                    b_touchDown = false;
                }

                else if (Mathf.Abs(touch_offset.x) < Mathf.Abs(touch_offset.y))
                {
                    if (touch_offset.y >= 0)
                    {
                        StartCoroutine(touchObj.GetComponent<Flower>().MoveFlower(Vector2.up));
                    }
                    else
                    {
                        StartCoroutine(touchObj.GetComponent<Flower>().MoveFlower(Vector2.down));
                    }
                    SoundManager.soundMgr.PlayES("Flower_Drag2");
                    b_touchDown = false;
                }
            }
        }
    }

    public void Button_Window()
    {
        Time.timeScale = 0;
        menuWindow.SetActive(true);
    }
}
