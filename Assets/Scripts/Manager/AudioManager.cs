using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    private AudioSource globalSource;
    
    [SerializeField] private List<AudioClip> totalClips;
    private int totalNums;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        globalSource = GetComponent<AudioSource>();
        totalNums = totalClips.Count;
    }

    public void Play(int index)
    {
        if (index < totalNums)
        {

        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Clip index out of range");
#endif
        }
    }

    public void Play(string name)
    {
        foreach(var clip in totalClips)
        {
            if (clip.name == name)
            {
                globalSource.clip = clip;
                globalSource.Play();
                return;
            }
        }
#if UNITY_EDITOR
            Debug.Log("Audioclip not found");
#endif

    }

    public void Stop()
    {
        globalSource.Stop();
    }

    public void Switch(int newIndex, float transitionTime = 5)
    {
        StartCoroutine(FadeMusic(newIndex, transitionTime));
    }

    public void Switch(string name, float transitionTime = 5)
    {
        for(int i = 0; i < totalNums; i++)
        {
            if(totalClips[i].name == name)
            {
                //Debug.Log("play:" + name);
                StartCoroutine(FadeMusic(i, transitionTime));
                return;
            }
        }
#if UNITY_EDITOR
        Debug.Log("Audioclip " + name + " not found");
#endif
    }

    IEnumerator FadeMusic(int newIndex, float transitionTime)
    {
        while (globalSource.volume > 0)
        {
            globalSource.volume -= Time.deltaTime / transitionTime;
            yield return null;
        }
        globalSource.Stop();

        if (newIndex < totalNums)
        {
            globalSource.clip = totalClips[newIndex];
            globalSource.Play();
            globalSource.clip = totalClips[newIndex];

            globalSource.Play();
            while (globalSource.volume < 1)
            {
                globalSource.volume += Time.deltaTime / transitionTime;
                yield return null;
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Clip index out of range");
#endif
        }

    }
}
