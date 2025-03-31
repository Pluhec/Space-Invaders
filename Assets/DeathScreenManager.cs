using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    public void restartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void loadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    
}
