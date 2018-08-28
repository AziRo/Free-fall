using UnityEngine;

public class mapGenerator : MonoBehaviour {

    public GameObject[] units_of_pipe;
    public Camera mainCam;
    public GameObject bonus;
    public float exponent_move;
    public float _speed;

    private string GO_name = "";
    private static int number_of_pipe = 8;
    private Vector3 startPosition;
    private float length_of_unit;
    private GameObject[] pipe = new GameObject[number_of_pipe];
    [HideInInspector] public GameObject bonusPoint;
    [HideInInspector] public bool isBonusPoint = false;
    private float areaX, areaZ;
    private float speed, time;

    void Start()
    {
        time = 0f;

        areaX = GameObject.Find("Main Camera").GetComponent<Move>().areaX;
        areaZ = GameObject.Find("Main Camera").GetComponent<Move>().areaZ;

        length_of_unit = units_of_pipe[0].transform.localScale.y / 3 + 10.85f;
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        bonusPoint = Instantiate(bonus, startPosition, Quaternion.identity);
        bonusPoint.SetActive(false);

        int j = -1;

        for (int i = 0; i < number_of_pipe; ++i)
        {
            if (j == units_of_pipe.Length - 1 || i == number_of_pipe - 2)
            {
                j = Random.Range(0, units_of_pipe.Length - 1);
            }
            else if (i == number_of_pipe - 1)
            {
                j = units_of_pipe.Length - 1;
            }
            else
            {
                j = Random.Range(0, units_of_pipe.Length);
            }
            
            pipe[i] = Instantiate(units_of_pipe[j], startPosition, Quaternion.identity);
            startPosition = new Vector3(startPosition.x, startPosition.y + length_of_unit, startPosition.z);
        }

        mainCam.transform.position = new Vector3(mainCam.transform.position.x, startPosition.y - length_of_unit + 100, mainCam.transform.position.z);
    }


    void FixedUpdate ()
    {
        time += Time.fixedDeltaTime;
        speed = Mathf.Pow(time, exponent_move) * Time.fixedDeltaTime * _speed;
        Debug.Log(speed);

        bool check = false;
        for (int i = 0; i < number_of_pipe; ++i)
        {
            int j;
            if (pipe[i].transform.position.y >= mainCam.transform.position.y + 150)
            {
                Vector3 pos = new Vector3(pipe[i].transform.position.x, pipe[i].transform.position.y - length_of_unit * number_of_pipe, pipe[i].transform.position.z);
                //Debug.Log(GO_name);
                if (GO_name == "pipe_empty(Clone)" || GO_name == "")
                    j = Random.Range(0, units_of_pipe.Length - 1);
                else
                    j = Random.Range(0, units_of_pipe.Length);

                Destroy(pipe[i]);
                pipe[i] = Instantiate(units_of_pipe[j], pos, Quaternion.identity);
                GO_name = pipe[i].name;

                if (isBonusPoint)
                {
                    bonusPoint.transform.position = new Vector3(Random.Range(0, areaX - 4), transform.position.y + Random.Range(0, length_of_unit / 2f), Random.Range(0, areaZ - 4));
                    bonusPoint.SetActive(true);
                    isBonusPoint = false;
                }
                //continue;
            }

            if (!check && bonusPoint.activeInHierarchy)
            {
                check = true;
                bonusPoint.transform.position = new Vector3(bonusPoint.transform.position.x, bonusPoint.transform.position.y + speed, bonusPoint.transform.position.z);
                if (bonusPoint.transform.position.y >= mainCam.transform.position.y + 150)
                {
                    bonusPoint.SetActive(false);
                }
            }
            //pipe[i].transform.position = new Vector3(pipe[i].transform.position.x, pipe[i].transform.position.y + speed, pipe[i].transform.position.z);
            pipe[i].transform.Translate(Vector3.up * speed);
        }
    }


}
