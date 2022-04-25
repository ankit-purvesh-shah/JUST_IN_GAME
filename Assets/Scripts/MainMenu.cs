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

    [SerializeField]
    private GameObject instructions1NextButton;

    [SerializeField]
    private GameObject instructions2NextButton;

    [SerializeField]
    private GameObject instructions3NextButton;

    [SerializeField]
    private GameObject instructions4NextButton;

    [SerializeField]
    private GameObject instructions5NextButton;

    [SerializeField]
    private GameObject instructions6NextButton;


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

    public void SetActiveButtonInstructions1()
    {
        Debug.Log("Set Active");
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructions1NextButton);
    }
    public void SetActiveButtonInstructions2()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructions2NextButton);
    }
    public void SetActiveButtonInstructions3()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructions3NextButton);
    }
    public void SetActiveButtonInstructions4()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructions4NextButton);
    }

    public void SetActiveButtonInstructions5()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructions5NextButton);
    }
    public void SetActiveButtonInstructions6()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructions6NextButton);
    }

}
