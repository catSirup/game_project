using UnityEngine;
using System.Collections;

public class ActiveObject : MonoBehaviour {
    
    public IEnumerator ActiveObj(Collision coll)
    {
        if (!coll.gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(5.0f);
            coll.gameObject.SetActive(true);
        }
    }
}
