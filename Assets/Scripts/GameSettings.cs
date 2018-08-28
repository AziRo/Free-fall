using UnityEngine;


[CreateAssetMenu(fileName = "NewGameSettings", menuName = "GameSettings")]
public class GameSettings : ScriptableObject {

    public float controlSensitivity;
    public int qualityLevel;
    public float volume;
    public int bestScore;

}
