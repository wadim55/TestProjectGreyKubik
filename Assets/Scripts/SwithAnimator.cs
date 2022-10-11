using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithAnimator : MonoBehaviour
{
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        GameEvent.Kub+= SwithAnimatorOn;
    }
    private void OnDisable()
    {
        GameEvent.Kub -= SwithAnimatorOn;
    }

    private void SwithAnimatorOn(string signal)
    {
        if (signal == "animOn")
        {
            _anim.enabled = true;
        }
    }
   
}
