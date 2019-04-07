using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YabaweeGameScene : Scene
{
    [SerializeField]
    private GameObject yabaweeText;
    [SerializeField]
    private GameObject tutorialWindow;
    [SerializeField]
    private GameObject menuWindow;

    [SerializeField]
    private GameObject[] cups;
    [SerializeField]
    private GameObject[] originCups;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject questText;
    [SerializeField]
    private ResultWindow resultWindow;

    private bool b_tutorial;
    private bool b_canShake;
    private bool b_canChoose;

    private int curBallPos;
    private int shakeCount;
    private float speedCount;
    private float delayTime;

    private int score;
    [SerializeField]
    private Text scoreText;

    private int curLife;
    [SerializeField]
    private GameObject[] lifes;

    public override void Initialize()
    {
        GameObject[] tempCups = new GameObject[3];
        tempCups = originCups;
        cups = tempCups;

        SoundManager.soundMgr.StopBGM();
        SoundManager.soundMgr.PlayBGM("Ball_BGM");

        ball.SetActive(true);
        ball.transform.position = new Vector2(-1.12f, 0);
        ball.transform.parent = gameObject.transform;

        yabaweeText.SetActive(true);
        tutorialWindow.SetActive(true);
        menuWindow.SetActive(false);
        questText.SetActive(false);
        resultWindow.gameObject.SetActive(false);
        b_tutorial = true;
        b_canShake = false;
        b_canChoose = false;
        curBallPos = 2;
        curLife = 4;

        for (int i = 0; i < 5; i++)
        {
            lifes[i].SetActive(true);
        }

        shakeCount = 5;
        speedCount = 1.5f;
        score = 0;
        delayTime = 1.5f;
    }

    public override void Updated()
    {
        if(b_tutorial)
        {
            if(Input.GetMouseButtonDown(0))
            {
                b_tutorial = false;
                b_canShake = true;
                tutorialWindow.SetActive(false);
            }
        }

        if(b_canShake && curLife > -1)
        {
            StartCoroutine(ShakeAnimation(shakeCount, speedCount, delayTime));
            b_canShake = false;
        }

        if(b_canChoose)
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if(Input.GetMouseButtonDown(0) && hit.collider != null)
            {
                if(hit.collider.gameObject == cups[curBallPos - 1])
                {
                    SoundManager.soundMgr.PlayES("Ball_Correct");
                    score += 500 * (shakeCount - 4);
                    scoreText.text = score.ToString("000000");
                    shakeCount++;
                    speedCount *= 1.5f;
                    questText.SetActive(false);
                    b_canShake = true;
                    b_canChoose = false;
                }

                else
                {
                    SoundManager.soundMgr.PlayES("Ball_Incorrect");
                    StartCoroutine(ShowBall(int.Parse(cups[int.Parse(hit.collider.gameObject.name)].name)));
                    ShowCurLife();
                    questText.SetActive(false);
                    b_canShake = true;
                    b_canChoose = false;
                }
            }
        }

        if(curLife == -1)
        {
            resultWindow.gameObject.SetActive(true);
            resultWindow.Init(score);
        }
    }

    public override void Exit()
    {
        Time.timeScale = 1;
        yabaweeText.SetActive(false);
    }

    private IEnumerator Shake12(float speed)
    {
        Vector2 originPos_cup1 = cups[0].transform.position;
        Vector2 originPos_cup2 = cups[1].transform.position;
        GameObject tempObj;

        float plusValue = 0;

        while(plusValue <= 1)
        {
            plusValue += 0.01f * speed;
            cups[0].transform.position = new Vector2(originPos_cup1.x + Mathf.Sin(Mathf.PI * plusValue) * 1.5f, originPos_cup1.y - (3.98f * plusValue));
            cups[1].transform.position = new Vector2(originPos_cup2.x - Mathf.Sin(Mathf.PI * plusValue) * 1.5f, originPos_cup2.y + (3.98f * plusValue));

            yield return new WaitForSeconds(0.01f);
        }

        tempObj = cups[0];
        cups[0] = cups[1];
        cups[1] = tempObj;

        cups[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
        cups[1].GetComponent<SpriteRenderer>().sortingOrder = 3;

        cups[0].transform.position = new Vector2(-0.27f, 3.98f);
        cups[1].transform.position = new Vector2(-0.27f, 0);

        if(curBallPos == 1)
        {
            curBallPos = 2;
            yield return null;
        }

        else if(curBallPos == 2)
        {
            curBallPos = 1;
            yield return null;
        }
    }

    private IEnumerator Shake13(float speed)
    {
        Vector2 originPos_cup1 = cups[0].transform.position;
        Vector2 originPos_cup3 = cups[2].transform.position;
        GameObject tempObj;

        float plusValue = 0;

        while (plusValue <= 1)
        {
            plusValue += 0.01f * speed;
            cups[0].transform.position = new Vector2(originPos_cup1.x + Mathf.Sin(Mathf.PI * plusValue) * 1.5f, originPos_cup1.y - (3.98f * plusValue * 2));
            cups[2].transform.position = new Vector2(originPos_cup3.x - Mathf.Sin(Mathf.PI * plusValue) * 1.5f, originPos_cup3.y + (3.98f * plusValue * 2));

            yield return new WaitForSeconds(0.01f);
        }

        tempObj = cups[0];
        cups[0] = cups[2];
        cups[2] = tempObj;

        cups[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
        cups[2].GetComponent<SpriteRenderer>().sortingOrder = 4;

        cups[0].transform.position = new Vector2(-0.27f, 3.98f);
        cups[2].transform.position = new Vector2(-0.27f, -3.98f);

        if (curBallPos == 1)
        {
            curBallPos = 3;
            yield return null;
        }

        else if (curBallPos == 3)
        {
            curBallPos = 1;
            yield return null;
        }
    }

    private IEnumerator Shake23(float speed)
    {
        Vector2 originPos_cup2 = cups[1].transform.position;
        Vector2 originPos_cup3 = cups[2].transform.position;
        GameObject tempObj;

        float plusValue = 0;

        while (plusValue <= 1)
        {
            plusValue += 0.01f * speed;
            cups[1].transform.position = new Vector2(originPos_cup2.x + Mathf.Sin(Mathf.PI * plusValue) * 1.5f, originPos_cup2.y - (3.98f * plusValue));
            cups[2].transform.position = new Vector2(originPos_cup3.x - Mathf.Sin(Mathf.PI * plusValue) * 1.5f, originPos_cup3.y + (3.98f * plusValue));

            yield return new WaitForSeconds(0.01f);
        }

        tempObj = cups[1];
        cups[1] = cups[2];
        cups[2] = tempObj;

        cups[1].GetComponent<SpriteRenderer>().sortingOrder = 3;
        cups[2].GetComponent<SpriteRenderer>().sortingOrder = 4;

        cups[1].transform.position = new Vector2(-0.27f, 0);
        cups[2].transform.position = new Vector2(-0.27f, -3.98f);

        if (curBallPos == 2)
        {
            curBallPos = 3;
            yield return null;
        }

        else if (curBallPos == 3)
        {
            curBallPos = 2;
            yield return null;
        }
    }

    private IEnumerator ShakeAnimation(int shakeCount, float speed, float delaytime)
    {
        int count = 0;
        int randNum = 0;

        StartCoroutine(ShowBall(curBallPos - 1));
        yield return new WaitForSeconds(2.1f);

        ball.transform.parent = cups[curBallPos - 1].transform;

        while(count < shakeCount)
        {
            randNum = Random.Range(0, 3);
            if(randNum % 3 == 0)
            {
                StartCoroutine(Shake12(speed));
                yield return new WaitForSeconds(delaytime);
                count++;
                continue;
            }

            else if (randNum % 3 == 1)
            {
                StartCoroutine(Shake13(speed));
                yield return new WaitForSeconds(delaytime);
                count++;
                continue;
            }

            else if (randNum % 3 == 2)
            {
                StartCoroutine(Shake23(speed));
                yield return new WaitForSeconds(delaytime);
                count++;
                continue;
            }
        }

        b_canChoose = true;
        questText.SetActive(true);
        ball.transform.parent = cups[curBallPos -1].transform.parent.parent;
        
        if(curBallPos == 1)
        {
            ball.transform.position = new Vector2(-1.12f, 3.98f);
        }

        else if(curBallPos == 2)
        {
            ball.transform.position = new Vector2(-1.12f, 0);
        }

        else if(curBallPos == 3)
        {
            ball.transform.position = new Vector2(-1.12f, -3.98f);
        }
    }

    private IEnumerator ShowBall(int num)
    {
        float count = 0;
        float tempX = 0;
        bool b_Up = true;
        while(true)
        {
            if (b_Up)
            {
                cups[num].transform.position = new Vector2(-0.27f + (0.9f * count * 0.02f), cups[num].transform.position.y);
                count += 2;
                yield return new WaitForSeconds(0.01f);

                if (cups[num].transform.position.x > 1.44f)
                {
                    tempX = cups[num].transform.position.x;
                    b_Up = false;
                    count = 0;
                }
            }

            else if(!b_Up)
            {
                cups[num].transform.position = new Vector2(tempX - (0.9f * count * 0.02f), cups[num].transform.position.y);
                count += 2;
                yield return new WaitForSeconds(0.01f);

                if (cups[num].transform.position.x < -0.27f)
                {
                    break;
                }
            }
        }
    }

    private void ShowCurLife()
    {
        curLife--;
        for(int i = 0; i < 5; i++)
        {
            if (i <= curLife)
                lifes[i].SetActive(true);
            else
                lifes[i].SetActive(false);
        }
    }

    #region Button
    public void Button_Menu()
    {
        Time.timeScale = 0;
        menuWindow.SetActive(true);
    }
    #endregion
}
