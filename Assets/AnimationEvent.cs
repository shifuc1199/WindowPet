using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public GameObject Cube;

    public void OnDanceEnter()
    {
        Cube.SetActive(true);
    }
    public void OnDanceExit()
    {
        Cube.SetActive(false);
    }
}
