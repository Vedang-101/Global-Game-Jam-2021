using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Elevator : MonoBehaviour
{
    public Animator Elevator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Elevator.SetBool("open", true);
        }
    }
}
