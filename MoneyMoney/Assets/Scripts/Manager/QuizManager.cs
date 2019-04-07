using UnityEngine;
using System.Collections;

public class QuizManager : MonoBehaviour {
    public GameObject[] quizs;
    public GameObject correct;
    public GameObject incorrect;
    private int randonIndex;
    private int index;

    public void Initialize()
    {
        correct.SetActive(false);
        incorrect.SetActive(false);
    }

    void OnEnable()
    {
        SelectQuiz();
    }

    public void SelectQuiz()
    {
        randonIndex = Random.Range(0, quizs.Length);

        for (index = 0; index < quizs.Length; index++)
        {
            if (index == randonIndex)
                quizs[index].SetActive(true);
            else
                quizs[index].SetActive(false);
        }
    }
}
