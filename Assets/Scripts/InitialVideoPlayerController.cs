using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class InitialVideoPlayerController : MonoBehaviour
{
    public VideoPlayer initialVideoPlayer;
    public VideoClip initialVideoClip;
    public string videoSceneName = "VideoScene";

    private void Start()
    {
        if (initialVideoPlayer != null && initialVideoClip != null)
        {
            initialVideoPlayer.clip = initialVideoClip;
            initialVideoPlayer.Play();

            // Suscribirse al evento cuando el video termine
            initialVideoPlayer.loopPointReached += OnInitialVideoFinished;
        }
        else
        {
            Debug.LogError("InitialVideoPlayer o InitialVideoClip no están asignados.");
        }
    }

    private void OnInitialVideoFinished(VideoPlayer vp)
    {
        // Establecer la variable estática para indicar que se debe reproducir la primera secuencia
        VideoPlayerController.videoToPlay = "FirstSequence";

        // Cargar la escena que contiene el VideoPlayerController
        SceneManager.LoadScene(videoSceneName);
    }

    private void OnDestroy()
    {
        if (initialVideoPlayer != null)
        {
            initialVideoPlayer.loopPointReached -= OnInitialVideoFinished;
        }
    }
}