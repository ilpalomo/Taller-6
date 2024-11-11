using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip firstVideoClip;
    public VideoClip secondVideoClip;
    public VideoClip finalVideoClip;

    // Variable estática para determinar qué video reproducir
    public static string videoToPlay;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;

        if (videoToPlay == "FirstSequence")
        {
            // Reproducir la secuencia inicial (primer y segundo video)
            videoPlayer.clip = firstVideoClip;
            videoPlayer.Play();
        }
        else if (videoToPlay == "FinalClip")
        {
            // Reproducir el video final
            videoPlayer.clip = finalVideoClip;
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("videoToPlay no está definido o tiene un valor incorrecto.");
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        if (videoToPlay == "FirstSequence")
        {
            if (videoPlayer.clip == firstVideoClip)
            {
                // Reproducir el segundo video
                videoPlayer.clip = secondVideoClip;
                Debug.Log("reproducciendoSegundoVideo");
                videoPlayer.Play();
            }
            else if (videoPlayer.clip == secondVideoClip)
            {
                // Ambos videos han terminado, cambiar a "SampleScene"
                SceneManager.LoadScene("SampleScene");
            }
        }
        else if (videoToPlay == "FinalClip")
        {
            // El video final ha terminado, volver a "SampleScene"
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }
}