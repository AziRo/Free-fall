using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Move : MonoBehaviour {

    /*
        public Transform player;

        private void OnMouseDrag()
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log("YEY!!!" + mousePos.x);
            player.position = new Vector3(mousePos.x, mousePos.y, player.position.z);

        }

    float offsetY;
    float offsetX;
    bool mouseDown;
    Vector3 mousePos;

    public float areaX;
    public float areaY;

    void Update()
    {
        mousePos = Input.mousePosition;

        
        if (Input.GetMouseButtonDown(0)) mouseDown = true;
        if (Input.GetMouseButtonUp(0)) mouseDown = false;

        Debug.Log("mouse position x = " + mousePos.x);

        if (mouseDown && mousePos.x <= -5)
        {
            offsetY = Input.GetAxis("Mouse Y");
            offsetX = Input.GetAxis("Mouse X");

            Debug.Log("dX = " + offsetX + "dY = " + offsetY);

            transform.position = new Vector3(transform.position.x + offsetX, transform.position.y, transform.position.z + offsetY);

        }

    }
    */

    public GameSettings gameSettings;

    public float areaX = 10, areaZ = 10;

    private float speed;

    float offsetZ;
    float offsetX;
    float maxDistance;

   // Rigidbody myBody;
    Vector3 offsetVec;
   // private GameObject joystick;
   // private Joystick scriptJoystick;

    //bool isDown = false;
   // int isUp = 1;

    void Start()
    {
        speed = gameSettings.controlSensitivity;

       // joystick = GameObject.FindGameObjectWithTag("joystick");
       // scriptJoystick = joystick.GetComponent <Joystick> ();

        //myBody = GetComponent < Rigidbody > ();

        maxDistance = Mathf.Sqrt(Mathf.Pow(areaX, 2) + Mathf.Pow(areaZ, 2));
    }


    void FixedUpdate()
    {
        /*
        if (Input.GetMouseButtonDown(0)) isDown = true;
        if (Input.GetMouseButtonUp(0))
        {
            isUp = 1;
            isDown = false;
        }
        */

        Vector3 mousePos = Input.mousePosition;

       /* if (Input.GetMouseButtonDown(0))
        {
            //joystick.transform.position = mousePos;
           // scriptJoystick.m_StartPos = mousePos;

          //  isUp = 0;
        }*/


        offsetZ = CrossPlatformInputManager.GetAxis("Vertical");
        offsetX = CrossPlatformInputManager.GetAxis("Horizontal");

        // Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), transform.position.z / speed) * speed;
        //Debug.Log("X = " + offsetX + " Z = " + offsetZ);
        // bool isUp = CrossPlatformInputManager.GetButton("Up");

        offsetVec = new Vector3(offsetX * speed, offsetZ * speed, 0);

        float x = offsetVec.x + transform.position.x, z = offsetVec.y + transform.position.z;
        float distanceToPoint = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2));

        if (distanceToPoint < maxDistance)
            transform.Translate(offsetVec);


    }

}
