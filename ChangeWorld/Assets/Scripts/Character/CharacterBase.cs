using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour {
    // 캐릭터 고유 사운드
    public AudioClip[] characterSound;

    // 그래픽 업그레이드 별 캐릭터.
    public GameObject[] go_Character;

    void OnEnable()
    {
        setCharacter(ReinforceManager.i_CurCharacterGraphicsUpgradeLevel);
    }

    public void setCharacter(int rainforceNum)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == rainforceNum)
            {
                go_Character[i].SetActive(true);
            }
            else
            {
                go_Character[i].SetActive(false);
            }
        }
    }
}
