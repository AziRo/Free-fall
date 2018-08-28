using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreLoader : MonoBehaviour {

    public TMP_Text scoreText;
    public TMP_Text bestScoreText;

	void Start () {
        scoreText.text = GameObject.Find("Main Camera").GetComponent<ParametersHandler>().score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("bestScore", 0).ToString();
	}

}
