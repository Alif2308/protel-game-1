using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
public class movieTracker : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public VideoPlayer video_nya;
    //private VideoPlayer video_baru;
    Slider tracker;
    bool slide= false;
    // Start is called before the first frame update
    void Start()
    {
        tracker = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!slide && video_nya.isPlaying)
        {
            tracker.value = (float)video_nya.frame/(float)video_nya.frameCount;
        }
    }        

    public void OnPointerDown(PointerEventData a)
    {
        slide =true;
    }
    public void OnPointerUp(PointerEventData a)
    {
        float frame = (float)tracker.value * (float)video_nya.frameCount;
        video_nya.frame = (long)frame;
        slide = false;
    }

 //   public void obtainVideo(VideoClip video_baru)
  //  {
  //      video_nya.clip = video_baru;

  //  }
}
