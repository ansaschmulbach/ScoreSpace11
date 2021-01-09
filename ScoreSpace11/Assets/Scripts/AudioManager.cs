﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static int Count => idleAudios.Count;
    public static AudioManager manager;
    private static readonly Queue<AudioSource> idleAudios = new Queue<AudioSource>(5);
    private static int busyCount;
    private AudioSource BgSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        manager = this;
    }
    public void StartBgSound(AudioClip clip, Vector3 position, float volume = 1f)
    {
        if(BgSource != null)
        {
            return;
        }
        GameObject gameObject = new GameObject("BackgroundMusic");
        gameObject.transform.parent = manager.transform;
        BgSource = gameObject.AddComponent<AudioSource>();
        BgSource.spatialBlend = 1f;
        BgSource.loop = true;
        BgSource.transform.position = position;
        BgSource.clip = clip;
        BgSource.volume = volume;
        BgSource.Play();
    }
    public void PauseBgSound()
    {
        BgSource.Pause();
    }
    public void ResumeBgSound()
    {
        BgSource.Play();
    }
    
    public static void PlayAtPoint(AudioClip clip, Vector3 position, float volume = 1f)
    {
        if (clip == null || busyCount > 100) return;
        AudioSource source = GetAudioSource();
        source.transform.position = position;
        source.clip = clip;
        source.volume = volume;
        source.Play();
        manager.StartCoroutine(ExecuteCycleCoroutine(source));
    }
    private static AudioSource GetAudioSource()
    {
        AudioSource source;
        if(idleAudios.Count > 0)
        {
            source = idleAudios.Dequeue();
            source.gameObject.SetActive(true);
        } else
        {
            GameObject gameObject = new GameObject("New Audio Source");
            gameObject.transform.parent = manager.transform;
            source = gameObject.AddComponent<AudioSource>();
            source.spatialBlend = 1f;
            source.loop = false;
        }
        return source;
    }
    private static IEnumerator ExecuteCycleCoroutine(AudioSource source)
    {
        busyCount++;
        float len = source.clip.length;
        yield return new WaitForSeconds(len);
        source.Stop();
        source.gameObject.SetActive(false);
        idleAudios.Enqueue(source);
        busyCount--;
    }
}
