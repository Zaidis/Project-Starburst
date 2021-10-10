using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip[] musicClips;
    AudioSource src;
    public static MusicManager instance;
    [SerializeField] float fadeSpeed;
    float maxVolume;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        src = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        maxVolume = src.volume;
        if (SceneManager.GetActiveScene().name == "TitleScreen")
            src.clip = musicClips[0];
        else
            src.clip = musicClips[GetRandomSong()];
        src.Play();
    }

    int GetRandomSong()
    {
        return Random.Range(1, musicClips.Length);
    }
    public void Transition(int index)
    {
        if (!src.enabled)
            src.enabled = true;
        StartCoroutine(TransitionSong(index));
    }

    public void ToggleMusic(bool val)
    {
        src.enabled = val;
        if (val)
        {
            src.volume = 0;
            StartCoroutine(TransitionSong(SceneManager.GetActiveScene().buildIndex));
        }
    }
    public void LoadMenuMusic()
    {
        src.clip = musicClips[0];
        src.Play();
    }
    IEnumerator TransitionSong(int index)
    {
        while(src.volume > 0)
        {
            src.volume -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        if (index == 0)
            src.clip = musicClips[0];
        else
            src.clip = musicClips[GetRandomSong()];
        src.Play();
        while (src.volume < maxVolume)
        {
            src.volume += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        yield return null;
    }
}
