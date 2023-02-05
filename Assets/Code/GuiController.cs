using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    [SerializeField] public Camera MainCamera;
    [SerializeField] public GameObject EndScreen;

    [SerializeField] private float timeToMoveEndScreen;
    private bool moveEndScreen = false;
    private float EndScreenXMovementProgress;
    private float EndScreenMoveProgress;

    [SerializeField] GameObject playerBase;
    [SerializeField] GameObject enemyBase;
    [SerializeField] GameObject spawners;

    [SerializeField] private GameObject ExitButton;

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
            EndScreenXMovementProgress = EndScreenMoveProgress * -1 / timeToMoveEndScreen;
            EndScreen.transform.position = new Vector3(-1 - EndScreenXMovementProgress, 0, 0);
            if (EndScreenMoveProgress >= timeToMoveEndScreen)
            {
                moveEndScreen = false;
                EndScreen.transform.position = new Vector3(0, 0, 0);
            }
        }

        if (!playerBase.activeSelf && MainCamera.transform.position.y == 0)
        {
            enableGame();
        }
    }

    public void PanCameraDown()
    {
        MainCamera.GetComponent<MainCamera>().CameraSmoothMove2D(new Vector2(0, 6.72f), new Vector2(0, 0),1);
    }

    public void PlayButtonSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void enableGame()
    {
        playerBase.SetActive(true);
        enemyBase.SetActive(true);
        spawners.SetActive(true);

        playerBase.SendMessage("SetDefaults");
        enemyBase.SendMessage("SetDefaults");
        resetEndScreen();
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void SlideInEndScreen(string text)
    {
        if (this.name.Equals("GameUI"))
        {
            transform.Find("EndScreen").transform.Find("EndText").GetComponent<TextMeshProUGUI>().text = text;
        }
        playerBase.SetActive(false);
        enemyBase.SetActive(false);
        spawners.SetActive(false);
        ExitButton.SetActive(true);
        EndScreenXMovementProgress = 0;
        EndScreenMoveProgress = 0;
        EndScreen.transform.position = new Vector3(-1, 0, 0);
        moveEndScreen = true;
    }

    public void resetEndScreen()
    {
        EndScreenXMovementProgress = 0;
        EndScreenMoveProgress = 0;
        EndScreen.transform.position = new Vector3(-1.5f, 0, 0);
    }
}
