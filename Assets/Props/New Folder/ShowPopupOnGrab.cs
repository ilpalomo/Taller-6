using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowPopupOnGrab : MonoBehaviour
{
    public GameObject popupImage; 
    public float displayDuration = 3f; 

    void Start()
    {
        if (popupImage != null)
        {
            popupImage.SetActive(false);
        }
    }

    public void OnGrabObject()
    {
        if (popupImage != null)
        {
            popupImage.SetActive(true);
            StartCoroutine(HidePopupAfterDelay());
        }
    }

    private IEnumerator HidePopupAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        popupImage.SetActive(false);
    }
}
