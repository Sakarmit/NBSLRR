using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    [SerializeField] public Camera MainCamera;
    [SerializeField] public SpriteRenderer EndScreen;

    [SerializeField] private float timeToMoveEndScreen;
    private bool moveEndScreen = false;
    private float EndScreenXMovementProgress;
    private float EndScreenMoveProgress;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveEndScreen)
        {
            EndScreenMoveProgress += Time.deltaTime;
            EndScreenXMovementProgress = EndScreenMoveProgress * -600 / timeToMoveEndScreen;
            transform.position = new Vector3(-600 - EndScreenXMovementProgress, 0, 0);
            if (EndScreenMoveProgress >= timeToMoveEndScreen)
            {
                moveEndScreen = false;
                transform.position = new Vector3(0, 0, 0);
            }
        }
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

    public void SlideInEndScreen()
    {
        moveEndScreen = true;
        EndScreenXMovementProgress = 0;
        EndScreenMoveProgress = 0;
    }
}
