using UnityEngine.SceneManagement;
using UnityEngine;

public class collision : MonoBehaviour {

    private int score, bestScore;

    void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0;

        score = GetComponent<ParametersHandler>().score;
        bestScore = GetComponent<ParametersHandler>().bestScore;

        if (score > bestScore) PlayerPrefs.SetInt("bestScore", score);

        SceneManager.LoadSceneAsync("gameOver", LoadSceneMode.Additive);
    }

}
