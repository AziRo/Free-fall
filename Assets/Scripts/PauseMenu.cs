using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private GameObject controller;
    private Joystick joy;
    private float timeScale;
    private GameObject scoreText;
    private Image scorePanel;


    public Image progressImage;
    public Text progressText;


    private void Start()
    {
        scoreText = GameObject.Find("_Score_Text");
        scoreText.SetActive(false);
        scorePanel = GameObject.Find("Score Panel").GetComponent<Image>();
        scorePanel.enabled = false;
        controller = GameObject.FindGameObjectWithTag("joystick");
        joy = controller.GetComponent<Joystick>();
        timeScale = Time.timeScale;
        joy.active = false;
        controller.GetComponent<Image>().enabled = false;
        GameObject.Find("backImage").GetComponent<Image>().enabled = false;
        GameObject.Find("Pause Menu Button").GetComponent<Image>().enabled = false;
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        scoreText.SetActive(true);
        scorePanel.enabled = true;
        joy.active = true;
        controller.GetComponent<Image>().enabled = true;
        GameObject.Find("backImage").GetComponent<Image>().enabled = true;
        GameObject.Find("Pause Menu Button").GetComponent<Image>().enabled = true;
        Time.timeScale = timeScale;
        SceneManager.UnloadSceneAsync("pauseMenu");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        StartCoroutine(LoadAsync("mainScene"));
    }

    IEnumerator LoadAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("mainScene");

        while (!operation.isDone)
        {
            progressImage.fillAmount = operation.progress / 0.9f;
            progressText.text = string.Format("{0:0}%", progressImage.fillAmount * 100);
            Debug.Log(operation.progress);
            yield return null;
        }

    }

}
