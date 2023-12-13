using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_MainMenuScreen;
    [SerializeField] private GameObject m_OptionsScreen;
    [SerializeField] private Canvas m_PauseScreen;
    [SerializeField] private GameObject m_LevelSelectScreen;

    private void Start()
    {

    }

    /// <summary>
    /// restarts the current level
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    /// <summary>
    /// pause screen
    /// </summary>
    public void Pause()
    {
        m_PauseScreen.gameObject.SetActive(true);
    }

    /// <summary>
    /// return to the main menu if in the option menu
    /// </summary>
    public void GoBackFromOption()
    {
        ToggleUIScreen(m_MainMenuScreen, m_OptionsScreen);
    }

	/// <summary>
	/// go to option menu from main menu
	/// </summary>
	public void GoToOption()
	{
		ToggleUIScreen(m_OptionsScreen, m_MainMenuScreen);
	}

	public void GoBackFromLevelSelect()
    {
        ToggleUIScreen(m_MainMenuScreen, m_LevelSelectScreen);
    }

    public void GoToLevelSelect()
    {
        ToggleUIScreen(m_LevelSelectScreen, m_MainMenuScreen);
    }

    /// <summary>
    /// start game
    /// </summary>
    /// <param name="sceneName"></param>
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    /// <summary>
    /// resume the ame if in pause menu
    /// </summary>
    public void Resume()
    {
        m_PauseScreen.gameObject.SetActive(false);
    }

    /// <summary>
    /// return to main menu
    /// </summary>
    /// <param name="sceneName"></param>
    public void GoToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    /// <summary>
    /// Used to ative or disactive a screen
    /// </summary>
    /// <param name="selectedScreen">the screen you want to active or disactive</param>
    /// <param name="previousScreen">the previous screen</param>
    public void ToggleUIScreen(GameObject selectedScreen, GameObject previousScreen)
    {
        if (!selectedScreen.gameObject.activeInHierarchy)
        {
            selectedScreen.SetActive(true);
            previousScreen.SetActive(false);
            //m_menuSound.PlayMenuClick();
            return;
        }
        else
        {
            previousScreen.SetActive(true);
            selectedScreen.SetActive(false);
            //m_menuSound.PlayBackButton();
            return;
        }
    }
    /// <summary>
    /// loads the scene with that name
    /// </summary>
    public void LoadSceneNumber(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
