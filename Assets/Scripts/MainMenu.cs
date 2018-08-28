using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public Image progressImage;
    public Text progressText;

    public Slider volumeSlider;
    public AudioMixer audioMixer;

    public Slider sensitivitySlider;
    public GameSettings gameSettings;
    public TMP_Dropdown graphicsDropdown;


    private void Start()
    {

        gameSettings.volume = PlayerPrefs.GetFloat("volume", 0);
        gameSettings.qualityLevel = PlayerPrefs.GetInt("qualityLevel", 3);
        gameSettings.controlSensitivity = PlayerPrefs.GetFloat("controlSensitivity", 1.1f);

        audioMixer.SetFloat("volume", gameSettings.volume);
        QualitySettings.SetQualityLevel(gameSettings.qualityLevel, true);

        volumeSlider.value = gameSettings.volume;
        sensitivitySlider.value = gameSettings.controlSensitivity;
        graphicsDropdown.value = gameSettings.qualityLevel;

    }


    public void Play()
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

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        gameSettings.volume = volume;
        PlayerPrefs.SetFloat("volume", gameSettings.volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
        gameSettings.qualityLevel = qualityIndex;
        PlayerPrefs.SetInt("qualityLevel", gameSettings.qualityLevel);
    }

    public void SetSensitivity(float sensitivity)
    {
        gameSettings.controlSensitivity = sensitivity;
        PlayerPrefs.SetFloat("controlSensitivity", gameSettings.controlSensitivity);
    }


}
