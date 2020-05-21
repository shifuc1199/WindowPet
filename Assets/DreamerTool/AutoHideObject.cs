using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideObject : MonoBehaviour
{
    public float hideTime;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("Hide", hideTime);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
