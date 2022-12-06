using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource walkSource;
    [SerializeField] AudioClip walkClip;

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void WalkSFX()
    {
        walkSource.clip = walkClip;
        walkSource.loop = true;

        if(!walkSource.isPlaying)
        {
            walkSource.Play();
        } else
        {
            walkSource.Stop();
        }
    }

    public void WalkStop()
    {
        walkSource.Stop();
    }
}
