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
        {
            src.clip = musicClips[0];
            src.volume = 0.25f;
        }
        else
        {
            src.clip = musicClips[GetRandomSong()];
        }
        src.Play();
    }

    private void Update()
    {
        if(!src.isPlaying)
        {
            src.clip = musicClips[GetRandomSong()];
            src.Play();
        }
    }

    int GetRandomSong()
    {
        return Random.Range(1, musicClips.Length);
    }
   
    public void ToggleMusic(bool val)
    {
        if (val)
            StartCoroutine(FadeIn());
        else
            StartCoroutine(FadeOut());
    }
    public void LoadMenuMusic()
    {
        src.clip = musicClips[0];
        src.Play();
    }

    public IEnumerator FadeOut()
    {
        while (src.volume > 0)
        {
            src.volume -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        src.clip = musicClips[GetRandomSong()];
        src.Play();
    }
    public IEnumerator FadeIn()
    {        
        while (src.volume < maxVolume)
        {
            src.volume += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}
