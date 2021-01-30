using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void playLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void levelSelect()
    {
        anim.SetBool("Levels", true);
        anim.SetBool("Back", false);
        anim.SetBool("Credits", false);
    }

    public void back()
    {
        anim.SetBool("Levels", false);
        anim.SetBool("Back", true);
        anim.SetBool("Credits", false);
    }

    public void credits()
    {
        anim.SetBool("Levels", false);
        anim.SetBool("Back", false);
        anim.SetBool("Credits", true);
    }
}
