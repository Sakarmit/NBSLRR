using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] public Camera MainCamera;
    public void PlayButtonSound()
    {
        GetComponent<AudioSource>().Play();
    }
    public void MoveCameraToTop()
    {
        MainCamera.GetComponent<MainCamera>().CameraSmoothMove2D(new Vector2(0, 0), new Vector2(0, 6.72f),5);
    }
}
