using UnityEngine;
using System.Collections;

public class CollisionCheck : MonoBehaviour {
    // 충돌 체크 변수
    #region bool_Value
    [System.NonSerialized]
    public bool b_CanInstallTreeA = false;
    [System.NonSerialized]
    public bool b_CanInstallTreeB = false;
    [System.NonSerialized]
    public bool b_CanInstallTreeC = false;
    [System.NonSerialized]
    public bool b_CanInstallFlowerB = false;
    [System.NonSerialized]
    public bool b_CanInstallFlowerP = false;
    [System.NonSerialized]
    public bool b_CanInstallFlowerY = false;
    [System.NonSerialized]
    public bool b_CanInstallAlter = false;
    [System.NonSerialized]
    public bool b_Alter1 = false;
    [System.NonSerialized]
    public bool b_Alter2 = false;
    [System.NonSerialized]
    public bool b_Alter3 = false;
    [System.NonSerialized]
    public bool b_Alter4 = false;
    [System.NonSerialized]
    public bool b_Alter5 = false;
    #endregion

    public CreatePlants tree1;
    public CreatePlants tree2;
    public CreatePlants tree3;
    public CreatePlants flowerB;
    public CreatePlants flowerP;
    public CreatePlants flowerY;
    public CreatePlants alter;

    public ActiveObject activeObject;

    public void Init()
    {
        b_CanInstallTreeA = false;
        b_CanInstallTreeB = false;
        b_CanInstallTreeC = false;

        b_CanInstallFlowerB = false;
        b_CanInstallFlowerY = false;
        b_CanInstallFlowerP = false;

        b_Alter1 = false;
        b_Alter2 = false;
        b_Alter3 = false;
        b_Alter4 = false;
        b_Alter5 = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Cube_TreeA"))
        {
            if (!tree1.b_delayTreeA)
            {
                b_CanInstallTreeA = true;
                coll.gameObject.SetActive(false);
            }
            else
            {
                tree1.i_TreeATime += 5;
                coll.gameObject.SetActive(false);
            }
        }

        if (coll.gameObject.CompareTag("Cube_TreeB"))
        {
            if (!tree2.b_delayTreeB)
            {
                b_CanInstallTreeB = true;
                coll.gameObject.SetActive(false);
            }
            else
            {
                tree2.i_TreeBTime += 5;
                coll.gameObject.SetActive(false);
            }
        }

        if (coll.gameObject.CompareTag("Cube_TreeC"))
        {
            if (!tree3.b_delayTreeC)
            {
                b_CanInstallTreeC = true;
                coll.gameObject.SetActive(false);
            }
            else
            {
                tree3.i_TreeCTime += 5;
                coll.gameObject.SetActive(false);
            }
        }

        if (coll.gameObject.CompareTag("Cube_FlowerB"))
        {
            if (!flowerB.b_delayFlowerB)
            {
                b_CanInstallFlowerB = true;
                coll.gameObject.SetActive(false);
            }
            else
            {
                flowerB.i_FlowerBTime += 5;
                coll.gameObject.SetActive(false);
            }
        }

        if (coll.gameObject.CompareTag("Cube_FlowerP"))
        {
          if (!flowerP.b_delayFlowerP)
            {
                b_CanInstallFlowerP = true;
                coll.gameObject.SetActive(false);
            }
            else
            {
                flowerP.i_FlowerPTime += 5;
                coll.gameObject.SetActive(false);
            }
        }

        if (coll.gameObject.tag == "Cube_FlowerY")
        {
           if (!flowerY.b_delayFlowerY)
            {
                b_CanInstallFlowerY = true;
                coll.gameObject.SetActive(false);
            }
            else
            {
                flowerY.i_FlowerYTime += 5;
                coll.gameObject.SetActive(false);
           }
        }

        if (coll.gameObject.tag == "alter1")
        {
            b_Alter1 = true;
            coll.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "alter2")
        {
            b_Alter2 = true;
            coll.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "alter3")
        {
            b_Alter3 = true;
            coll.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "alter4")
        {
            b_Alter4 = true;
            coll.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "alter5")
        {
            b_Alter5 = true;
            coll.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "Alter")
        {
            if (b_Alter1 && b_Alter2 && b_Alter3 && b_Alter4 && b_Alter5)
            {
                b_CanInstallAlter = true;
            }
            tree1.CanInstall();
            tree2.CanInstall();
            tree3.CanInstall();

            flowerB.CanInstall();
            flowerP.CanInstall();
            flowerY.CanInstall();

            alter.CanInstall();
        }
        StartCoroutine(activeObject.ActiveObj(coll));
    }
}