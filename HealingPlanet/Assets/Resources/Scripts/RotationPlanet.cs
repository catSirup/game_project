using UnityEngine;
using System.Collections;

public class RotationPlanet : MonoBehaviour {
    public void RotatePlanet()
    {
        gameObject.transform.rotation = Quaternion.Euler(
            -(Time.fixedTime) - 30 ,
            0, 0);
    }
}
