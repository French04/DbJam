using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlood : MonoBehaviour {

    private void OnEnable()
    {
        
        StartCoroutine(DestroyBloods());
    }


    IEnumerator DestroyBloods()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
