using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importa el espacio de nombres para gestionar escenas
using System.Collections;

public class ShowPopupOnGrab : MonoBehaviour
{
    public GameObject popupImage;
    public float displayDuration = 6f; // Establece la duración a 6 segundos

    void Start()
    {
        if (popupImage != null)
        {
            popupImage.SetActive(false); // Asegura que el popup esté oculto al iniciar
        }
    }

    public void OnGrabObject()
    {
        if (popupImage != null)
        {
            popupImage.SetActive(true); // Muestra el popup
            StartCoroutine(LoadSceneAfterDelay()); // Inicia el coroutine para cambiar de escena
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration); // Espera 6 segundos
        SceneManager.LoadScene("Cinematica 2"); // Carga la escena "Cinematica 2"
    }
}
 