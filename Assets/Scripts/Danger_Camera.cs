using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger_Camera : MonoBehaviour
{
    Camera c;
    public GameObject target;

    void Start()
    {
        c = GetComponent<Camera>();        
    }

    void Update()
    {
        if(IsTargetVisible() && !GameManager.instance.tracking)
        {
            GameManager.instance.tracking = true;
        } else if (!IsTargetVisible()) {
            GameManager.instance.tracking = false;
        }
    }

    bool IsTargetVisible()
    {
        var dir = target.transform.position - c.transform.position;
        RaycastHit hitinfo;
        if(Physics.Raycast(c.transform.position, dir, out hitinfo, 1000))
        {
            if (hitinfo.collider.gameObject == target)
            {
                return true;
            }
            else return false;
        }
        return false;
    }
}
