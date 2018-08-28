using UnityEngine;

public class TriggerHandler : MonoBehaviour {

    public string objectName;
    public bool isBonus = false;
    public int bonusScore = 1;



    private mapGenerator MG;

    private void Start()
    {
        MG = GameObject.Find("Pipe").GetComponent<mapGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == objectName)
        {

            if (isBonus)
            {
                other.GetComponent<ParametersHandler>().score += bonusScore * 2;
                gameObject.SetActive(false);
            }
            else other.GetComponent<ParametersHandler>().score++;

            if (other.GetComponent<ParametersHandler>().score % bonusScore == 0  && !MG.bonusPoint.activeInHierarchy)
            {
                MG.isBonusPoint = true;
            }
            
            //Time.timeScale += 0.05f;
            //MG.speed += 0.5f;
        }

    }


}
