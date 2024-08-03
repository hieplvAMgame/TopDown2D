using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
    [SerializeField] AudioClip shootClip0;
    [SerializeField] AudioClip shootClip1;
    [SerializeField] AudioClip shootClip2;
    [SerializeField] AudioClip shootClip3;
    [SerializeField] AudioClip shootClip4;
    [SerializeField] AudioClip reloadClip;

    AudioClip[] shootClips;

    [SerializeField] AudioSource[] channels;
    int curChannel = 0;
    protected override void Awake()
    {
        base.Awake();
        shootClips = new AudioClip[] { shootClip0, shootClip1, shootClip2, shootClip3, shootClip4 };
    }

    public void PlayShootClip(int index, float volume = 1f)
    {
        channels[curChannel].PlayOneShot(shootClips[index], volume);
        curChannel++;
        if (curChannel >= channels.Length) curChannel = 0;
    }
    public void PlayReloadClip() => channels[curChannel].PlayOneShot(reloadClip);
}
