using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour
{
    private VideoPlayer m_videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (m_videoPlayer.isPrepared)
        {
            if (m_videoPlayer.isPlaying)
            {
                print("Playing");
            }
            else
            {
                print("Done");
            }
        }
    }
}
