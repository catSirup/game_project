using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatchmindScene : Scene
{
    [SerializeField]
    private GameObject catchmindText;
    [SerializeField]
    private GameObject tutorialText;

    [SerializeField]
    private Sprite[] questionImg;
    [SerializeField]
    private Image questionRenderer;
    [SerializeField]
    private Text[] answerText;

    [SerializeField]
    private Text readyTimeText;
    private float readyTime;

    [SerializeField]
    private Text timerText;
    private float time;
    private float checkTime;
    [SerializeField]
    private Image curTime;

    [SerializeField]
    private ResultWindow resultWindow;
    [SerializeField]
    private GameObject menuWindow;

    private bool b_Tutorial;
    private bool b_Start;
    private bool b_first;

    [SerializeField]
    private Text scoreText;
    private int score;

    [SerializeField]
    private GameObject[] correctAnim;

    private bool b_ChangeQustion;

    public override void Initialize()
    {
        Time.timeScale = 1;

        SoundManager.soundMgr.PlayES("StartingGame");
        SoundManager.soundMgr.StopBGM();
        SoundManager.soundMgr.PlayBGM("Catchmind_BGM");

        catchmindText.SetActive(true);
        tutorialText.SetActive(true);
        resultWindow.gameObject.SetActive(false);
        readyTimeText.gameObject.SetActive(false);

        readyTimeText.color = Color.black;
        curTime.rectTransform.sizeDelta = new Vector2(720, 100);
        questionRenderer.sprite = null;

        for (int i = 0; i < answerText.Length; i++ )
        {
            answerText[i].text = "";
        }

        b_Tutorial = true;
        b_Start = false;
        b_first = false;
        readyTime = 4;

        curTime.color = new Color32(255, 0, 216, 255);
        timerText.text = "60";

        time = 60;
        score = 0;
        scoreText.text = "000000";

        b_ChangeQustion = false;
    }

    public override void Updated()
    {
        Tutorial();
        ReadyTimeAnimation();
        TimerBarAnimation();

        if (b_ChangeQustion)
        {
            ChangeQuestion();
            b_ChangeQustion = false;
        }
    }

    public override void Exit()
    {
        catchmindText.SetActive(false);
    }

    private void Tutorial()
    {
        if (b_Tutorial)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tutorialText.SetActive(false);
                readyTimeText.gameObject.SetActive(true);
                b_Tutorial = false;
            }
        }

        else
            readyTime -= Time.deltaTime;
    }
    private void ReadyTimeAnimation()
    {
        if (readyTime > 1)
            readyTimeText.text = ((int)readyTime).ToString();
        else if (readyTime < 1 && readyTime > 0)
        {
            readyTimeText.color = new Color(1, 0.85f, 0);
            readyTimeText.text = "시작!";
        }
        else
        {
            readyTimeText.gameObject.SetActive(false);
            b_Start = true;
            checkTime = (int)time;

            if(!b_first)
            {
                b_ChangeQustion = true;
                b_first = true;
            }
        }
    }
    private void TimerBarAnimation()
    {
        if (b_Start)
        {
            time -= Time.deltaTime;
            timerText.text = ((int)time).ToString("00");
            if (time < checkTime && time > 0)
            {
                curTime.rectTransform.sizeDelta = new Vector2(720 * time / 60, 100);
                checkTime = (int)time;

                if (time < 10.8)
                    curTime.color = Color.red;
            }

            else if (time < 0)
            {
                time = 0;
                resultWindow.gameObject.SetActive(true);
                resultWindow.Init(score);
            }
        }
    }
    private void ChangeQuestion()
    {
        int randNum = Random.Range(0, 62);
        questionRenderer.sprite = questionImg[randNum];

        int correctAnswer = Random.Range(0, 3);

        for(int i = 0; i < 3;)
        {
            if (i == correctAnswer)
            {
                answerText[correctAnswer].text = questionImg[randNum].name;
                i++;
            }
            else
            {
                int tempNum = Random.Range(0, 62);

                if (tempNum != randNum)
                {
                    answerText[i].text = questionImg[tempNum].name;
                    i++;
                }

                else
                    continue;
                
            }
        }
    }
    private void CorrectionCheck(string answer)
    {
        if(questionRenderer.sprite.name == answer)
        {
            score += 500;
            scoreText.text = ((int)score).ToString("000000");
            StartCoroutine(CorrectAnim(correctAnim[0]));
            ChangeQuestion();
        }

        else
        {
            StartCoroutine(CorrectAnim(correctAnim[1]));
            ChangeQuestion();
        }
    }

    private IEnumerator CorrectAnim(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        obj.SetActive(false);
    }

    public void Button_1()
    {
        SoundManager.soundMgr.PlayES("BBOCKBBOCK");
        CorrectionCheck(answerText[0].text);
    }

    public void Button_2()
    {
        SoundManager.soundMgr.PlayES("BBOCKBBOCK");
        CorrectionCheck(answerText[1].text);
    }

    public void Button_3()
    {
        SoundManager.soundMgr.PlayES("BBOCKBBOCK");
        CorrectionCheck(answerText[2].text);
    }

    public void Button_Menu()
    {
        Time.timeScale = 0;
        menuWindow.SetActive(true);
    }
}
