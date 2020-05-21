using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void Dance()
    {
        anim.SetTrigger("dance");
        AudioManager.Instance.PlayBGM("抬棺");

        Timer.Register(15, () => {
            AudioManager.Instance.StopBGM();
            anim.SetTrigger("idle");
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
