using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Collider coll;
    public float hidden_interval = 2f;
    public float active_interval = 1f;
    public GameObject[] lasers;
    public bool TurnOff = false;
    public bool constant = false;

    float timer = 0;
    bool stop = false;

    private void Start()
    {
        coll = GetComponent<Collider>();
        if(TurnOff)
        {
            timer = 0;
            coll.enabled = !coll.enabled;
            foreach (GameObject laser in lasers)
                laser.SetActive(!laser.activeSelf);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > (coll.enabled? active_interval: hidden_interval) && !stop && !constant)
        {
            timer = 0;
            coll.enabled = !coll.enabled;
            foreach (GameObject laser in lasers)
                laser.SetActive(!laser.activeSelf);
        }
    }

    public void trunOff()
    {
        coll.enabled = !coll.enabled;
        foreach (GameObject laser in lasers)
            laser.SetActive(!laser.activeSelf);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().canMove = false;
            GameManager.instance.Ended = true;
            GameManager.instance.timerText.color = new Color(1f, .5f, .5f);
            GameManager.instance.timerText.text = "911 called, you were caught...";
            GameManager.instance.retrybutton.SetActive(true);
            AudioManager.instance.PlayFailure();
            stop = true;
            Debug.Log("Caught");
        }
    }
}
