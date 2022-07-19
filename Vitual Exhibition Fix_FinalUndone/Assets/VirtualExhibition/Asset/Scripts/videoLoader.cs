using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
 
public class videoLoader : MonoBehaviour
{
     
    public VideoPlayer videoPlayer;
    public string videoUrl = "yourvideourl";
     
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.url = videoUrl;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack (0, true);
        videoPlayer.Prepare ();
    }
 
    // Update is called once per frame
    void Update()
    {
         
    }

    public void video_link(string onlineVid)
    {
        videoUrl = onlineVid;
    }
}