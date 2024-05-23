using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video_ : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public int scene_index;

    private void Start() { VideoPlayer.loopPointReached += LoadScene; }
    private void LoadScene(VideoPlayer vp) { SceneManager.LoadScene(scene_index); }






    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene(scene_index);
        }
    }
}