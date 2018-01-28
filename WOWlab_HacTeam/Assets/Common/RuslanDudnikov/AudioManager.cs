using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance;

    private AudioSource audioSource;


    // -------------Soudns---------------

    public AudioClip MusicBackground;
    public AudioClip CatchBanan;
    public AudioClip EatingBanan;
    public AudioClip Fail;
    public AudioClip HandTwist;


    // ----------------------------------




    public List<AudioSource> Sources { get; private set; }


    // ----------Play-Background-Music--------------


    public void PlayBackgroundMusic(AudioClip clip = null, float volume = 1f)
    {
        if (!audioSource.isPlaying)
        {
            if (clip == null) { Debug.Log("clip is null"); }
            else if
(volume < 0f || volume > 1f) { Debug.Log("Invalid volume"); }
            else
            {
                audioSource.clip = clip;
                audioSource.volume = volume;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else { Debug.Log("Already playing"); }
    }



    // ----------------PlayOnShot------------------

    public void PlayOneShot(AudioClip clip = null, float volume = 1, Transform playingObject = null)
    {
        if (clip != null)
        {
            if (volume < 0f && volume > 1f) { Debug.Log("Invalid volume"); }
            else
            {
                if (FindSource(clip) == null)
                {
                    if (playingObject == null)
                    {
                        GameObject audioObject = new GameObject("Clip");
                        audioObject.transform.parent = gameObject.transform;
                        AudioSource source = audioObject.AddComponent<AudioSource>();
                        source.clip = clip;
                        source.volume = volume;
                        source.Play();
                        Sources.Add(source);
                        StartCoroutine(DeleteAfterEnd(audioObject, source));
                    }
                    else
                    {
                        GameObject audioObject = new GameObject("Clip");
                        audioObject.transform.parent = playingObject.transform;
                        AudioSource source = audioObject.AddComponent<AudioSource>();
                        source.clip = clip;
                        source.volume = volume;
                        source.Play();
                        Sources.Add(source);
                        StartCoroutine(DeleteAfterEnd(audioObject, source));
                    }
                }
            }
        }
        else { Debug.Log("Clip is null"); }

    }

    // ---------------AddSource-------------------


    private void AddSourceInSources(AudioSource source)
    {
        Sources.Add(source);
    }

    // ----------------RemoveSorce----------------

    private void RemoveSourceFromSources(AudioSource source)
    {
        if (Sources.Contains(source))
        {
            Sources.Remove(source);
        }
        else { Debug.Log("SourcesList diesn't have source"); }
    }


    // --------AutoDelete------------

    private IEnumerator DeleteAfterEnd(GameObject objectToDel, AudioSource source)
    {
        while (source.isPlaying)
        {
            yield return new WaitForFixedUpdate();
        }
        Destroy(objectToDel);
    }

    // --------FindClipInSources------------

    private AudioSource FindSource(AudioClip clip)
    {
        if (Sources != null)
        {
            foreach (AudioSource auS in Sources)
            {
                if (auS != null)
                {
                    if (auS.clip == clip)
                    {
                        return auS;
                    }
                }
            }
        }
        return null;
    }


    // ===========================================



    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
            }

            return _instance;
        }
    }


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.AddComponent<AudioSource>();
        Sources = new List<AudioSource>();
    }
}
