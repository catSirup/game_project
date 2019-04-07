using UnityEngine;
using System.Collections;

public class CreatePlants : MonoBehaviour
{
    public UIManager uiManager;
    public CollisionCheck c_Player;

    private string s_Name = null;
    int i_SelectIndex;
    public GameObject[] go_Tree = new GameObject[3];

    public Transform t_CreateSpot;

    public Texture2D tx_Dis;
    public Texture2D tx_Nor;
    public Texture2D tx_Pot;

    #region NonSerialized_Value
    [System.NonSerialized]
    public bool b_InstallTreeA = false;
    [System.NonSerialized]
    public bool b_InstallTreeB = false;
    [System.NonSerialized]
    public bool b_InstallTreeC = false;
    [System.NonSerialized]
    public bool b_InstallFlowerB = false;
    [System.NonSerialized]
    public bool b_InstallFlowerP = false;
    [System.NonSerialized]
    public bool b_InstallFlowerY = false;
    [System.NonSerialized]
    public bool b_InstallAlter = false;
    [System.NonSerialized]
    public bool b_delayTreeA = false;
    [System.NonSerialized]
    public bool b_delayTreeB = false;
    [System.NonSerialized]
    public bool b_delayTreeC = false;
    [System.NonSerialized]
    public bool b_delayFlowerB = false;
    [System.NonSerialized]
    public bool b_delayFlowerP = false;
    [System.NonSerialized]
    public bool b_delayFlowerY = false;
    [System.NonSerialized]
    public int i_TreeATime = 0;
    [System.NonSerialized]
    public int i_TreeBTime = 0;
    [System.NonSerialized]
    public int i_TreeCTime = 0;
    [System.NonSerialized]
    public int i_FlowerBTime = 0;
    [System.NonSerialized]
    public int i_FlowerPTime = 0;
    [System.NonSerialized]
    public int i_FlowerYTime = 0;
    #endregion

    public void Init()
    {
        b_InstallTreeA = false;
        b_InstallTreeB = false;
        b_InstallTreeC = false;

        b_InstallFlowerB = false;
        b_InstallFlowerP = false;
        b_InstallFlowerY = false;

        b_InstallAlter = false;

        s_Name = null;
    }

    public void Render()
    {
        if (this.gameObject.name == "Tree_A")
        {
            if (!b_InstallTreeA)
            {
                guiTexture.texture = tx_Dis;
            }

            else if (b_InstallTreeA && !guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Nor;
            }

            else if (b_InstallTreeA && guiTexture.HitTest(Input.mousePosition))
            {

                guiTexture.texture = tx_Pot;
            }
        }

        if (this.gameObject.name == "Tree_B")
        {
            if (!b_InstallTreeB)
            {
                guiTexture.texture = tx_Dis;
            }

            else if (b_InstallTreeB && !guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Nor;
            }

            else if (b_InstallTreeB && guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Pot;
            }
        }

        if (this.gameObject.name == "Tree_C")
        {

            if (!b_InstallTreeC)
            {
                guiTexture.texture = tx_Dis;
            }

            else if (b_InstallTreeC && !guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Nor;
            }

            else if (b_InstallTreeC && guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Pot;
            }
        }

        if (this.gameObject.name == "Flower_B")
        {
            if (!b_InstallFlowerB)
            {
                guiTexture.texture = tx_Dis;
            }

            else if (b_InstallFlowerB && !guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Nor;
            }

            else if (b_InstallFlowerB && guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Pot;
            }
        }

        if (this.gameObject.name == "Flower_P")
        {
            if (!b_InstallFlowerP)
            {
                guiTexture.texture = tx_Dis;
            }

            else if (b_InstallFlowerP && !guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Nor;
            }

            else if (b_InstallFlowerP && guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Pot;
            }
        }

        if (this.gameObject.name == "Flower_Y")
        {
            if (!b_InstallFlowerY)
            {
                guiTexture.texture = tx_Dis;
            }

            else if (b_InstallFlowerY && !guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Nor;
            }

            else if (b_InstallFlowerY && guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Pot;
            }
        }

        if (this.gameObject.name == "Alter")
        {
            if (!b_InstallAlter)
            {
                guiTexture.texture = tx_Dis;
            }

            else if (b_InstallAlter && !guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Nor;
            }

            else if (b_InstallAlter && guiTexture.HitTest(Input.mousePosition))
            {
                guiTexture.texture = tx_Pot;
            }
        }
    }

    string GetName()
    {
        if (guiTexture.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            if (c_Player.b_CanInstallTreeA ||
                c_Player.b_CanInstallTreeB ||
                c_Player.b_CanInstallTreeC ||
                c_Player.b_CanInstallFlowerP ||
                c_Player.b_CanInstallFlowerY ||
                c_Player.b_CanInstallFlowerB ||
                c_Player.b_CanInstallAlter)
                s_Name = gameObject.name;
        }

        return s_Name;
    }

    public void InitName()
    {
        s_Name = null;
    }

    public void Create()
    {
        GameObject go_Plants;
        i_SelectIndex = Random.Range(0, 3);

        if ((GetName() == "Tree_A" && b_InstallTreeA) || (GetName() == "Tree_B" && b_InstallTreeB) || (GetName() == "Tree_C" && b_InstallTreeC))
        {
            go_Plants = Instantiate(go_Tree[i_SelectIndex], new Vector3(t_CreateSpot.position.x, t_CreateSpot.position.y, t_CreateSpot.position.z), Quaternion.identity) as GameObject;
            go_Plants.transform.rotation = Quaternion.Euler(c_Player.transform.rotation.x, c_Player.transform.rotation.y, c_Player.transform.rotation.z);

            switch (GetName())
            {
                case "Tree_A":
                    b_InstallTreeA = false;
                    StartCoroutine(DelayTimeTreeA());
                    break;

                case "Tree_B":
                    b_InstallTreeB = false;
                    StartCoroutine(DelayTimeTreeB());
                    break;

                case "Tree_C":
                    b_InstallTreeC = false;
                    StartCoroutine(DelayTimeTreeC());
                    break;
            }
        }

        if ((GetName() == "Flower_B" && b_InstallFlowerB) || (GetName() == "Flower_Y" && b_InstallFlowerY) || (GetName() == "Flower_P" && b_InstallFlowerP))
        {
            go_Plants = Instantiate(go_Tree[i_SelectIndex], new Vector3(t_CreateSpot.position.x, t_CreateSpot.position.y + 0.1f, t_CreateSpot.position.z), Quaternion.identity) as GameObject;
            go_Plants.transform.rotation = Quaternion.Euler(c_Player.transform.rotation.x, c_Player.transform.rotation.y, c_Player.transform.rotation.z);

            switch (GetName())
            {
                case "Flower_B":
                    b_InstallFlowerB = false;
                    StartCoroutine(DelayTimeFlowerB());
                    break;

                case "Flower_Y":
                    b_InstallFlowerY = false;
                    StartCoroutine(DelayTimeFlowerY());
                    break;

                case "Flower_P":
                    b_InstallFlowerP = false;
                    StartCoroutine(DelayTimeFlowerP());
                    break;
            }
        }

        if (GetName() == "Alter" && b_InstallAlter)
        {
            go_Plants = Instantiate(go_Tree[i_SelectIndex], new Vector3(t_CreateSpot.position.x, t_CreateSpot.position.y + 0.1f, t_CreateSpot.position.z + 5), Quaternion.identity) as GameObject;
            go_Plants.transform.rotation = Quaternion.Euler(c_Player.transform.rotation.x, c_Player.transform.rotation.y, c_Player.transform.rotation.z);

            c_Player.b_Alter1 = false;
            c_Player.b_Alter2 = false;
            c_Player.b_Alter3 = false;
            c_Player.b_Alter4 = false;
            c_Player.b_Alter5 = false;
            b_InstallAlter = false;
        }

        InitName();
    }

    public void CanInstall()
    {
        if (!b_delayTreeA)
        {
            if (c_Player.b_CanInstallTreeA)
                b_InstallTreeA = true;
        }

        if (!b_delayTreeB)
        {
            if (c_Player.b_CanInstallTreeB)
                b_InstallTreeB = true;
        }

        if (!b_delayTreeC)
        {
            if (c_Player.b_CanInstallTreeC)
                b_InstallTreeC = true;
        }

        if (!b_delayFlowerB)
        {
            if (c_Player.b_CanInstallFlowerB)
                b_InstallFlowerB = true;
        }

        if (!b_delayFlowerP)
        {
            if (c_Player.b_CanInstallFlowerP)
                b_InstallFlowerP = true;
        }

        if (!b_delayFlowerY)
        {
            if (c_Player.b_CanInstallFlowerY)
                b_InstallFlowerY = true;
        }

        if (c_Player.b_CanInstallAlter)
            b_InstallAlter = true;
    }

    // 시간 지연.
    IEnumerator DelayTimeTreeA()
    {
        b_delayTreeA = true;
        yield return new WaitForSeconds(15 - i_TreeATime);
        i_TreeATime = 0;
        b_InstallTreeA = true;
        b_delayTreeA = false;
    }

    IEnumerator DelayTimeTreeB()
    {
        b_delayTreeB = true;
        yield return new WaitForSeconds(15 - i_TreeBTime);
        i_TreeBTime = 0;
        b_InstallTreeB = true;
        b_delayTreeB = false;
    }

    IEnumerator DelayTimeTreeC()
    {
        b_delayTreeC = true;
        yield return new WaitForSeconds(15 - i_TreeCTime);
        i_TreeCTime = 0;
        b_InstallTreeC = true;
        b_delayTreeC = false;
    }

    IEnumerator DelayTimeFlowerB()
    {
        b_delayFlowerB = true;
        yield return new WaitForSeconds(15 - i_FlowerBTime);
        i_FlowerBTime = 0;
        b_InstallFlowerB = true;
        b_delayFlowerB = false;
    }

    IEnumerator DelayTimeFlowerY()
    {
        b_delayFlowerY = true;
        yield return new WaitForSeconds(15 - i_FlowerYTime);
        i_FlowerYTime = 0;
        b_InstallFlowerY = true;
        b_delayFlowerY = false;
    }

    IEnumerator DelayTimeFlowerP()
    {
        b_delayFlowerP = true;
        yield return new WaitForSeconds(15 - i_FlowerPTime);
        i_FlowerPTime = 0;
        b_InstallFlowerP = true;
        b_delayFlowerP = false;
    }
}
