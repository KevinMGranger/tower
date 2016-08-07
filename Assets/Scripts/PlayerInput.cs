using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

    public float maxSpeed;

    public float currSpeed;

    Rigidbody2D bod;

    Vector3 linePos;
    bool drawLine = false;

    void OnValidate()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    // TODO: FixedUpdate?
    void Update()
    {
        //TODO: probably not this
        var force = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bod.AddForce(force);

        //get current speed and display
        var vel = bod.velocity;
        currSpeed = vel.magnitude;

        if (Input.GetMouseButtonDown(0))
        {
            var pos3 = Input.mousePosition;
            linePos = Camera.main.ScreenToWorldPoint(pos3);
            drawLine = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            drawLine = false;
        }

        if (drawLine) Debug.DrawLine(transform.position, linePos);
    }
}
