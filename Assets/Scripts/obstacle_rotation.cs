using UnityEngine;

public class obstacle_rotation : MonoBehaviour {

    public enum Direction
    {
        clockwise = 0,
        counterclockwise = 1
    }


    [Header("Rotate Around:")]
    [Space]
    public bool x_asix = false;
    public bool y_asix = true;
    public bool z_asix = false;
    [Space]
    public float min_speed = 0;
    public float max_speed = 1.5f;
    [Space]
    [Range(0,10)] public float angle = 1;
    [Space]
    public Direction direction = 0;



    private Quaternion objRot;
    private float speed;
    private float add_angle;


    private void Start()
    {
        direction = (Direction)Random.Range(0, 2);
        if (direction == Direction.counterclockwise)
            angle *= -1;
        objRot = transform.rotation;
        speed = Random.Range(min_speed, max_speed);
        add_angle = angle;
    }

    void FixedUpdate ()
    {
        Quaternion rotationX, rotationY, rotationZ;
        transform.rotation = objRot;
        if (x_asix)
        {
            rotationX = Quaternion.AngleAxis(angle * speed, Vector3.right);
            transform.rotation *= rotationX;
        }
        if (y_asix)
        {
            rotationY = Quaternion.AngleAxis(angle * speed, Vector3.up);
            transform.rotation *= rotationY;
        }
        if (z_asix)
        {
            rotationZ = Quaternion.AngleAxis(angle * speed, Vector3.forward);
            transform.rotation *= rotationZ;
        }

        angle += add_angle;
    }
}
