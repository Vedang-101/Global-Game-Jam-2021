using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && anim.GetBool("open"))
        {
            FindObjectOfType<PlayerController>().canMove = false;
            Debug.Log("Finished");
            GameManager.instance.timerText.text = "Going Down...";
            GameManager.instance.timerText.color = new Color(0.8f, 1f, 0.66f);
            GameManager.instance.Ended = true;
            other.gameObject.SetActive(false);
            GameManager.instance.nextbutton.SetActive(true);
            GameManager.instance.timerText.gameObject.SetActive(true);
        }
    }
}
