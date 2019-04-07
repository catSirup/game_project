using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordGameScene : Scene
{
    [SerializeField]
    private GameObject wordGameText;
    [SerializeField]
    private Image curTimeImg;
    [SerializeField]
    private Text curTimeText;
    [SerializeField]
    private Text curWord;
    [SerializeField]
    private Text countText;
    [SerializeField]
    private GameObject tutorialWindow;
    [SerializeField]
    private ResultWindow resultWindow;
    [SerializeField]
    private MenuWindow menuWindow;
    [SerializeField]
    private Text scoreText;
    private float time;
    private int checkTime;

    private bool b_Start;

    public TextReader textReader;

    [SerializeField]
    private GameObject[] answerButtons;
    [SerializeField]
    private Text[] ThreeWords;
    [SerializeField]
    private Text[] FourWords;
    [SerializeField]
    private Text[] FiveWords;

    [SerializeField]
    private Image[] buttonImg;

    private bool b_getChangeWord;  // 단어 설정이 됐는지 안됐는지
    [SerializeField]
    private int[] arr_Word;     // 랜덤 설정용 배열

    private string curAnswer;   // 누를 때마다 문자가 합쳐짐.
    [SerializeField]
    private bool[] b_click;     // 클릭 여부 체크
    private bool b_correct;

    public int score;

    [SerializeField]
    private GameObject O_animation;
    [SerializeField]
    private GameObject X_animation;

    private bool b_tutorial;

    private bool b_gameOver;

    public override void Initialize()
    {
        SoundManager.soundMgr.StopBGM();
        SoundManager.soundMgr.PlayBGM("Word_BGM");

        time = 64;
        textReader.LoadText("WordList");
        wordGameText.SetActive(true);
        b_Start = false;
        curAnswer = "";
        scoreText.text = "000000";
        b_getChangeWord = false;
        b_tutorial = false;
        score = 0;

        curTimeText.text = "60";
        curTimeText.color = Color.black;
        curWord.text = "";
        countText.gameObject.SetActive(true);
        countText.text = "";
        curTimeImg.rectTransform.sizeDelta = new Vector2(720, 100);
        b_correct = true;
        b_gameOver = false;

        for(int i = 0; i < 3; i++)
        {
            answerButtons[i].SetActive(false);
        }

        b_click = new bool[12];
        for (int j = 0; j < 12; j++)
        {
            b_click[j] = false;
        }

        tutorialWindow.SetActive(true);
    }

    public override void Updated()
    {
        if (!b_tutorial)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tutorialWindow.SetActive(false);
                b_tutorial = true;
            }
        }

        else
        {
            CountBar();

            if (b_getChangeWord)
            {
                ChangeWord();
                b_getChangeWord = false;
            }

            if (!b_correct)
            {
                time -= 5;
                b_correct = true;
            }
        }
    }

    public override void Exit()
    {
        wordGameText.SetActive(false);
    }

    #region Personal Function
    // 카운터 바 애니메이션
    public void CountBar()
    {
        time -= Time.deltaTime;

        if (b_Start)
        {
            countText.gameObject.SetActive(false);
            curTimeText.text = time.ToString("00");

            if (time < checkTime && time > 0)
            {
                curTimeImg.rectTransform.sizeDelta = new Vector2(720 * time / 60, 100);
                checkTime = (int)time;

                if (time < 10.8)
                    curTimeText.color = Color.red;
            }

            else if (time < 0)
            {
                if (!b_gameOver)
                {
                    SoundManager.soundMgr.PlayES("GameOver");
                    b_gameOver = true;
                }
                time = 0;
                resultWindow.gameObject.SetActive(true);
                resultWindow.Init(score);
            }
        }

        else
        {
            countText.text = ((int)(time - 60)).ToString();
            if (time < 60)
            {
                b_getChangeWord = true;
                checkTime = (int)time;
                b_Start = true;
            }
        }
    }

    // 단어 변경
    public void ChangeWord()
    {
        ReturnButtonColor();
        for (int j = 0; j < 12; j++)
        {
            b_click[j] = false;
        }
        curWord.text = textReader.wordList[Random.Range(0, 150)];
        SetWord();
    }

    public void SetWord()
    {
        for (int i = 0; i < 3; i++)
        {
            if (curWord.text.Length == i + 3)
                answerButtons[i].SetActive(true);

            else
                answerButtons[i].SetActive(false);
        }

        SetSyllable(curWord.text.Length);
    }

    public void SetSyllable(int length)
    {
        arr_Word = new int[5] { 0, 1, 2, 3, 4 };
        switch(length)
        {
            case 3:
                for (int i = 0; i < length;)
                {
                    int temp = arr_Word[Random.Range(0, length)];

                    if (temp != -1)
                    {
                        ThreeWords[i].text = curWord.text[temp].ToString();
                        arr_Word[temp] = -1;
                        i++;
                    }
                }
                break;

            case 4:
                for (int i = 0; i < length;)
                {
                    int temp = arr_Word[Random.Range(0, length)];

                    if (temp != -1)
                    {
                        FourWords[i].text = curWord.text[temp].ToString();
                        arr_Word[temp] = -1;
                        i++;
                    }
                }
                break;

            case 5:
                for (int i = 0; i < length;)
                {
                    int temp = arr_Word[Random.Range(0, length)];
                   
                    if (temp != -1)
                    {
                        FiveWords[i].text = curWord.text[temp].ToString();
                        arr_Word[temp] = -1;
                        i++;
                    }
                }
                break;
        }
    }

    public void CorrectionCheck()
    {
        for (int i = 0; i < curAnswer.Length; i++)
        {
            if (curAnswer[i] != curWord.text[i])
            {
                b_correct = false;
                b_getChangeWord = true;
                curAnswer = "";
                StartCoroutine(CorrectAnim(X_animation));
                SoundManager.soundMgr.PlayES("Word_Incorrect");
                break;
            }

            else if (curAnswer[curAnswer.Length - 1] == curWord.text[curAnswer.Length - 1] && curAnswer.Length == curWord.text.Length)
            {
                b_correct = true;
                b_getChangeWord = true;
                curAnswer = "";
                score += 400;
                scoreText.text = score.ToString("000000");
                StartCoroutine(CorrectAnim(O_animation));

                SoundManager.soundMgr.PlayES("Word_Correct");
            }
        }
    }

    private IEnumerator CorrectAnim(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        obj.SetActive(false);
    }

    public void ReturnButtonColor()
    {
        for (int i = 0; i < 12; i++)
            buttonImg[i].color = new Color32(255, 239, 0, 255);
    }

    #endregion

    #region Button
    public void Button_Menu()
    {
        Time.timeScale = 0;
        menuWindow.gameObject.SetActive(true);
    }

    public void Button_Three_1()
    {
        if (!b_click[0])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += ThreeWords[0].text;
            CorrectionCheck();
            b_click[0] = true;
            buttonImg[0].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Three_2()
    {
        if (!b_click[1])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += ThreeWords[1].text;
            CorrectionCheck();
            b_click[1] = true;
            buttonImg[1].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Three_3()
    {
        if (!b_click[2])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += ThreeWords[2].text;
            CorrectionCheck();
            b_click[2] = true;
            buttonImg[2].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Four_1()
    {
        if (!b_click[3])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FourWords[0].text;
            CorrectionCheck();
            b_click[3] = true;
            buttonImg[3].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Four_2()
    {
        if (!b_click[4])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FourWords[1].text;
            CorrectionCheck();
            b_click[4] = true;
            buttonImg[4].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Four_3()
    {
        if (!b_click[5])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FourWords[2].text;
            CorrectionCheck();
            b_click[5] = true;
            buttonImg[5].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Four_4()
    {
        if (!b_click[6])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FourWords[3].text;
            CorrectionCheck();
            b_click[6] = true;
            buttonImg[6].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Five_1()
    {
        if (!b_click[7])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FiveWords[0].text;
            CorrectionCheck();
            b_click[7] = true;
            buttonImg[7].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Five_2()
    {
        if (!b_click[8])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FiveWords[1].text;
            CorrectionCheck();
            b_click[8] = true;
            buttonImg[8].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Five_3()
    {
        if (!b_click[9])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FiveWords[2].text;
            CorrectionCheck();
            b_click[9] = true;
            buttonImg[9].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Five_4()
    {
        if (!b_click[10])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FiveWords[3].text;
            CorrectionCheck();
            b_click[10] = true;
            buttonImg[10].color = new Color32(98, 91, 1, 255);
        }
    }

    public void Button_Five_5()
    {
        if (!b_click[11])
        {
            SoundManager.soundMgr.PlayES("Word_Click");
            curAnswer += FiveWords[4].text;
            CorrectionCheck();
            b_click[11] = true;
            buttonImg[11].color = new Color32(98, 91, 1, 255);
        }
    }
    #endregion
}
