using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject optionsMenu;
    public GameObject quitMenu;
    
    
    public void loadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    
    public void showQuitMenu()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(true);
    }
    
    public void showOptionsMenu()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(true);
        quitMenu.SetActive(false);
    }
    
    public void showGameMenu()
    {
        gameMenu.SetActive(true);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
    
}
