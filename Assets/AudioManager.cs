using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (AudioManager.instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public AudioSource stinger;
    public GameObject danger;
    public GameObject explorer;

    AudioSource[] Danger;
    AudioSource[] Explorer;

    public AudioClip Failure;
    public AudioClip[] SuccessPiano;

    public AudioClip[] sfx;

    public float voulume_Max = 1f;
    public float Start_speed = 5f;

    public bool inDanger = false;

    private void Start()
    {
        Danger = danger.GetComponents<AudioSource>();
        Explorer = explorer.GetComponents<AudioSource>();
        stinger.volume = voulume_Max;
        stinger.Play();
        StartCoroutine(PlaySounds(4.211f));
    }

    public void startLevel()
    {
        StopAllCoroutines();
        StartCoroutine(StartSounds());
    }

    IEnumerator StartSounds()
    {
        while(Explorer[1].volume <= voulume_Max)
        {
            for(int i = 1; i<Explorer.Length; i++)
            {
                Explorer[i].volume += Time.deltaTime * Start_speed;
            }
            yield return null;
        }
        yield return null;
    }

    IEnumerator PlaySounds(float time)
    {
        yield return new WaitForSeconds(time);
        foreach(AudioSource s in Danger)
        {
            s.volume = 0;
            s.Play();
        }
        foreach (AudioSource s in Explorer)
        {
            s.volume = voulume_Max;
            s.Play();
        }
        Explorer[0].Play();
        yield return null;
    }

    public void Fade(float time)
    {
        StopAllCoroutines();
        StartCoroutine(FadeSounds(time));
        /*if (inDanger)
        {
            foreach (AudioSource s in Danger)
                s.volume = 0;
            foreach (AudioSource s in Explorer)
                s.volume = voulume_Max;
        }
        else
        {
            foreach (AudioSource s in Danger)
                s.volume = voulume_Max;
            foreach (AudioSource s in Explorer)
                s.volume = 0;
        }
        inDanger = !inDanger;*/
    }

    public void PlayFailure()
    {
       /*stinger.PlayOneShot(Failure);
        foreach (AudioSource s in Danger)
            s.volume = 0;
        foreach (AudioSource s in Explorer)
            s.volume = 0;*/
    }

    public void PlaySucess()
    {
        int rand = Random.Range(0, SuccessPiano.Length);
        stinger.PlayOneShot(SuccessPiano[rand]);
    }

    public void PlaySoundEffects(int index)
    {
        stinger.PlayOneShot(sfx[index]);
    }

    IEnumerator FadeSounds(float time)
    {
        float v_d = Danger[0].volume;
        float v_e = Explorer[0].volume;
        float i = inDanger ? v_d : v_e;
        while(i>0)
        {
            if(inDanger)
            {
                v_d -= Time.deltaTime;
                i = v_d;
                v_e += Time.deltaTime;
                foreach (AudioSource s in Danger)
                {
                    s.volume = v_d;
                }
                foreach (AudioSource s in Explorer)
                {
                    s.volume = v_e;
                }
            } else
            {
                v_e -= Time.deltaTime;
                v_d += Time.deltaTime;
                i = v_e;
                foreach (AudioSource s in Danger)
                {
                    s.volume = v_d;
                }
                foreach (AudioSource s in Explorer)
                {
                    s.volume = v_e;
                }
            }
            yield return null;
        }
        v_e = inDanger ? voulume_Max : 0;
        v_d = !inDanger ? voulume_Max : 0;
        inDanger = !inDanger;
        yield return null;
    }
}
