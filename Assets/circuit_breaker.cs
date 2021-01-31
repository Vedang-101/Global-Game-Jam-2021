using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circuit_breaker : MonoBehaviour
{
    public Laser[] lasers;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(anim.GetBool("trigger"))
            {
                AudioManager.instance.PlaySoundEffects(0);
            } else
                AudioManager.instance.PlaySoundEffects(1);
            foreach (Laser l in lasers)
                l.trunOff();
            anim.SetBool("trigger", !anim.GetBool("trigger"));
        }
    }
}
