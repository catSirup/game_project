using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour {
    private Vector2 curDir;
    private bool b_changeDir;

    public void Init(Vector2 dir)
    {
        curDir = dir;
        b_changeDir = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == gameObject.name && col.CompareTag("FlowerObj"))
        {
            ColorSelectScene.remainCount -= 1;
            ColorSelectScene.score += 200;
            gameObject.SetActive(false);
        }

        else if (col.name != gameObject.name && col.CompareTag("FlowerObj"))
        {
            b_changeDir = true;
            gameObject.transform.position = new Vector3(0, 0, gameObject.transform.position.z);
        }
    }

    public IEnumerator MoveFlower(Vector2 dir)
    {
        Vector3 originPos = gameObject.transform.position;
        float count = 0;

        while (true)
        {
            if (!b_changeDir)
            {
                count += Time.deltaTime;

                gameObject.transform.position = new Vector3(originPos.x + 5 * dir.x * count, originPos.y + 5 * dir.y * count, originPos.z);
                yield return new WaitForSeconds(0.01f);

                if (dir == Vector2.right)
                {
                    if (gameObject.transform.position.x > 3)
                        break;
                }

                else if (dir == Vector2.left)
                {
                    if (gameObject.transform.position.x < -3)
                        break;
                }

                else if (dir == Vector2.up)
                {
                    if (gameObject.transform.position.y > 3)
                        break;
                }

                else if (dir == Vector2.down)
                {
                    if (gameObject.transform.position.y < -3)
                        break;
                }
            }
            else
                break;
        }

        yield return new WaitForSeconds(0.1f);
        b_changeDir = false;
    }
}
