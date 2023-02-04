using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    [SerializeField] public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanCameraDown()
    {
        MainCamera.GetComponent<MainCamera>().CameraSmoothMove2D(new Vector2(0, 6.72f), new Vector2(0, 0));
    }

    public void PlayButtonSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
