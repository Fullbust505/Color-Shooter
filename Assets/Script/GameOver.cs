using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverUI; 

    private bool isGameOver = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) //pour tester le GameOver Screen
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        GameOverUI.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Return to menu
    public void BackMenu()
    {
        Debug.Log("Back Menu");
        Application.Quit();
    }
}
