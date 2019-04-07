using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour {

    public SceneManager sceneManager;
    public ObstacleFuncManager obstacleFuncMgr;
    public CharacterSelectManager characterSelectMgr;

    #region Value

    public static int i_PassCount = 0;

    [SerializeField]
    float f_MaxSpeed;

    [SerializeField]
    float f_MoveSpeed;

    public static bool isBumped;
    public int i_GainPoint = 0;
    public static int i_GainScore = 0;

    public bool isDead = false;
    public static bool isNeverDead = false;

    public static int i_DeadCount;

    bool isJumpSoundPlaying = false;
    bool isKCSoundPlaying = false;

    #endregion

    #region Manage Character Selecting

    [SerializeField]
    int i_NumberofCharacter;
    public GameObject[] go_Characters;
    public GameObject NeverDead;

    #endregion

    #region Sounds
    public AudioClip coinSound;
    public AudioClip[] deadSound;

    public AudioClip jumpSound;
    //public AudioClip[] jumpSound;
    public AudioClip exJumpSound;
    #endregion

    #region Function

    public void Init() // 게임 새로 시작될 때마다 불릴 함수.
    {
        for (int i = 0; i < go_Characters.Length; i++)
        {
            if (i == CharacterSelectManager.i_CurSelectCharacterNumber)
            {
                // 캐릭터 변경
                go_Characters[i].SetActive(true);
            }
            else
                go_Characters[i].SetActive(false);
        }

        gameObject.transform.position = new Vector2(0, 0);
        gameObject.GetComponent<Collider2D>().enabled = true;
        i_PassCount = 0;
        i_GainPoint = 0;
        i_GainScore = 0;
        isBumped = false;
        isDead = false;
        NeverDead.SetActive(false);
        isNeverDead = false;
        gameObject.transform.localScale = new Vector2(1, 1);
    }

    public void Move()
    {
        if (Explanation.b_IsDisapear)
        {
            if (!isBumped)
            {
                if (Input.GetMouseButton(0))
                {
                    if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
                        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1.2f);

                    GetComponent<Rigidbody2D>().gravityScale = -0.5f;

                    if (gameObject.GetComponent<Rigidbody2D>().velocity.y < f_MaxSpeed)
                        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * f_MoveSpeed);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    isJumpSoundPlaying = true;
                }

                else if (Input.GetMouseButton(0))
                {
                    isJumpSoundPlaying = false;
                }
            }

            else
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            }

            if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0))
            {
                GetComponent<Rigidbody2D>().gravityScale = 0.5f;

                isJumpSoundPlaying = false;

                if (gameObject.GetComponent<Rigidbody2D>().velocity.y < f_MaxSpeed)
                    gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.up * f_MoveSpeed);
            }
        }

        else if (!Explanation.b_IsDisapear && !isBumped)
            gameObject.transform.position = new Vector3(0, 0, 0);
    }

    public void Sound()
    {
        if (isJumpSoundPlaying && Explanation.b_IsDisapear)
        {
            if (characterSelectMgr.curState == CharacterSelectManager.CharacterState.KC && !isKCSoundPlaying && CharacterSelectManager.i_CurSelectCharacterNumber == 13)
            {
                StartCoroutine(KC_SOUND());
            }

            else
            {
                AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Background") && !isNeverDead)
        {
            isBumped = true;

            if (characterSelectMgr.curState == CharacterSelectManager.CharacterState.KC && CharacterSelectManager.i_CurSelectCharacterNumber == 13)
            {
                AudioSource.PlayClipAtPoint(deadSound[1], transform.position);
            }

            else
            {
                AudioSource.PlayClipAtPoint(deadSound[0], transform.position);
            }

            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DelayDeathTime());
        }

        if (coll.gameObject.CompareTag("Obstacles") && !isNeverDead)
        {
            isBumped = true;

            if (characterSelectMgr.curState == CharacterSelectManager.CharacterState.KC && CharacterSelectManager.i_CurSelectCharacterNumber == 13)
            {
                AudioSource.PlayClipAtPoint(deadSound[1], transform.position);
            }

            else
            {
                AudioSource.PlayClipAtPoint(deadSound[0], transform.position);
            }
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DelayDeathTime());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Obstacles"))
        {
            i_PassCount++;
            i_GainScore += 1 + ReinforceManager.i_CurObstacleGraphicsUpgradeLevel + ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel + ReinforceManager.i_CurCharacterGraphicsUpgradeLevel;
        }

        if (col.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            i_GainPoint += 1 + (int)(ReinforceManager.i_CurPlusPointLevel * 0.5f);
            col.transform.parent.transform.parent.SendMessage("Resolution", SendMessageOptions.DontRequireReceiver);
        }

        if (col.CompareTag("Big"))
        {
            StartCoroutine(Big());
            col.transform.parent.transform.parent.SendMessage("Resolution", SendMessageOptions.DontRequireReceiver);
        }

        if (col.CompareTag("Small"))
        {
            StartCoroutine(Small());
            col.transform.parent.transform.parent.SendMessage("Resolution", SendMessageOptions.DontRequireReceiver);
        }

        if (col.CompareTag("Star"))
        {
            StartCoroutine(Star());
            col.transform.parent.transform.parent.SendMessage("Resolution", SendMessageOptions.DontRequireReceiver);
        }
    }

    IEnumerator DelayDeathTime()
    {
        yield return new WaitForSeconds(1.5f);
        isDead = true;
        i_DeadCount++;
        obstacleFuncMgr.Resolution();
    }

    IEnumerator Big()
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);

        gameObject.transform.localScale = new Vector2(2.2f, 2.2f);
        yield return new WaitForSeconds(3);
        gameObject.transform.localScale = new Vector2(1, 1);
    }

    IEnumerator Small()
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);

        gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
        yield return new WaitForSeconds(3);
        gameObject.transform.localScale = new Vector2(1, 1);
    }

    IEnumerator Star()
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);

        gameObject.GetComponent<Collider2D>().isTrigger = true;
        NeverDead.SetActive(true);
        isNeverDead = true;
        yield return new WaitForSeconds(3);
        isNeverDead = false;
        NeverDead.SetActive(false);
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Collider2D>().isTrigger = false;
    }

    IEnumerator KC_SOUND()
    {
        isKCSoundPlaying = true;
        AudioSource.PlayClipAtPoint(exJumpSound, transform.position);
        yield return new WaitForSeconds(1.5f);
        isKCSoundPlaying = false;
    }
    #endregion

}
