using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionVisualBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("DisableSelf", 1.5f);
    }

    private void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
