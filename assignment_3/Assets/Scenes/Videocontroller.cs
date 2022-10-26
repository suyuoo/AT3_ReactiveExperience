using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class Videocontroller : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject Panel;
    private RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {

        videoPlayer = this.GetComponent<VideoPlayer>();
        rawImage = this.GetComponent<RawImage>();
        videoPlayer.loopPointReached += VideoPlayer_seekCompleted;
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.texture == null)
        {
            return;
        }
        rawImage.texture = videoPlayer.texture;
    }
     private void VideoPlayer_seekCompleted(VideoPlayer videoPlayer)
    {
        Panel.SetActive(true);
    }
}
