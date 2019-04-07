using UnityEngine;
using System.Collections;

public class Quiz : MonoBehaviour {
    public GameObject[] answers;
    public Collider2D[] cols;
    public GameObject correct;
    public GameObject incorrect;
    public QuizManager quizMgr;
    public InputManager inputMgr;
    public int correctNumber;
    private bool isClear;

    void OnEnable()
    {
        isClear = false;
        StartCoroutine(SelectAnswer());

        for (int i = 0; i < cols.Length; i++)
            cols[i].enabled = true;
    }

    IEnumerator SelectAnswer()
    {
        while (!isClear)
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && inputMgr.isClick)
            {
                // 정답일 때
                if (hit.collider.gameObject == answers[correctNumber-1])
                {
                    StartCoroutine(Correct());
                    isClear = true;
                }

                // 아닐 때
                else
                {
                    StartCoroutine(Incorrect());
                    isClear = true;
                }
            }

            yield return null;
        }
    }

    IEnumerator Correct()
    {
        correct.SetActive(true);

        for (int i = 0; i < cols.Length; i++)
            cols[i].enabled = false;

        yield return new WaitForSeconds(1.5f);
        correct.SetActive(false);
        // 점수 올라가는 코드 작성
        PlayScene.score += 10;
        // 현재 목숨 상황 보여줌.
        PlayScene.callAnimation = true;
    }

    IEnumerator Incorrect()
    {
        incorrect.SetActive(true);

        for (int i = 0; i < cols.Length; i++)
            cols[i].enabled = false;

        yield return new WaitForSeconds(1.5f);
        incorrect.SetActive(false);
        // 목숨 하나 없애는 코드 작성
        LifeAnimation.lifeCount--;
        // 현재 목숨 상황 보여줌.
        PlayScene.callAnimation = true;
    }
}
