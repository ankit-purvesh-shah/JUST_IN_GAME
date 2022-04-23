using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject controlsBackButton;
    [SerializeField]
    private GameObject levelsBackButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("LEVEL 0");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetActiveButtonMainMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton);
    }
    public void SetActiveButtonControls()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsBackButton);
    }

    public void SetActiveButtonLevels()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(levelsBackButton);
    }
}
