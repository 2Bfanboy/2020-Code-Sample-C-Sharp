using System;
using System.Collections;
using UnityEngine;

public class CheckAnimationStatus : StateMachineBehaviour
{
    override public void OnStateExit(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Shiba.Core.Engine.NovelMaster>();
        OnIsExpanded += manager.ResetScene;
        OnIsExpanded(); // fire off event
        OnIsExpanded -= manager.ResetScene;
    }

    public delegate void IsExpanded();
    public event IsExpanded OnIsExpanded;
}
