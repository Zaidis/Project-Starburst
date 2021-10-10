using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Stop the music
        MusicManager.instance.ToggleMusic(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_audioSource.isPlaying)
        {
            LoadLevel.instance.LoadNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            m_audioSource.Stop();
            LoadLevel.instance.LoadNextLevel();
        }
    }
}
