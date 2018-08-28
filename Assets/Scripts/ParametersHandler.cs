using UnityEngine;
using TMPro;

public class ParametersHandler : MonoBehaviour {


    public int helth = 0;
    public int score = 0;
    public int bestScore = 0;
    public float timeScale = 1;


    public TMP_Text scoreText;

    void Start ()
    {
        Time.timeScale = timeScale;
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
    }
	

	void FixedUpdate ()
    {
        scoreText.SetText(score.ToString());
    }
}
