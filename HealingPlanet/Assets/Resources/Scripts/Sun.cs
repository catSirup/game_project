using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
    public void SunLight()
    {
        float inputRot = (Time.fixedTime) + 30;
        gameObject.light.intensity = (2f * Mathf.Sin(inputRot * Mathf.PI / 180)) + 2f;
    }
}
