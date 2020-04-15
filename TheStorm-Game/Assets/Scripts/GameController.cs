using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Canvas EndLevelCanvas;
    public Canvas WinCanvas;
    public Canvas PauseCanvas;
    public GameObject HelpPanel;
    public GameObject deathScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //Quit();
            Pause();
        }
    }

    public void EndLevel()
    {
        EndLevelCanvas.gameObject.SetActive(true);

    }

    public void Win() {
        WinCanvas.gameObject.SetActive(true);
    }

    void Pause()
    {
        if (Time.timeScale != 0)
        {
            PauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        deathScreen.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        Destroy(GameObject.Find("Shared Prefab").gameObject);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ToggleActiveHelp()
    {
        HelpPanel.SetActive(!HelpPanel.activeSelf);
    }


}
