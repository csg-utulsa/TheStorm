using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Canvas EndLevelCanvas;
    public GameObject HelpPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Quit();
        }
    }

    public void EndLevel()
    {
        EndLevelCanvas.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
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
