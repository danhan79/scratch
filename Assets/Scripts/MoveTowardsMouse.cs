using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsMouse : MonoBehaviour
{
    public float moveSpeed = 10f;    
    public float maxMoveSPeed = 10f;
    Vector2 velocity;
    void Start()
    {
        
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    //transform.position = Vector2.MoveTowards(transform.position,mousePosition,moveSpeed * Time.deltaTime);
    //    transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref velocity,smoothTime, maxMoveSPeed * Time.deltaTime);
    //}

    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    Vector2 currentVelocity;
    public Vector2 direction;
    public Vector2 totalDistance;
    public float offset = 1f;
    public float turnSpeed = 45;
    float currentAngle;
    public float maxTurnSpeed = 90;
    public float smoothVelocity;
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);

        // direction between 2d objects, param1: player, param2 mouse. players direction towards mouse (startposition - targetposition)
        direction = (new Vector3(mousePosition.x, mousePosition.y) - transform.position).normalized;
        
        // total distance to mouse
        totalDistance =  Vector2.Distance(mousePosition, transform.position) * direction;

        // angle between 2d objects. image with rightpointing arrow and the direction between player and mouse
        var angle = Vector2.SignedAngle(Vector2.right, direction);

        transform.position = Vector2.SmoothDamp(transform.position, mousePosition - (direction * offset), ref currentVelocity, smoothTime, maxMoveSpeed);
        //transform.eulerAngles = new Vector3(0, 0, angle);
        var rotate = new Vector3(0, 0, angle);
        //RotateSmooth1(rotate);
        RotateSmooth2(angle);
    }

    private void RotateSmooth1(Vector3 targetRotation)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);
    }

    private void RotateSmooth2(float targetAngle)
    {
        currentAngle =  Mathf.SmoothDampAngle(currentAngle, targetAngle, ref smoothVelocity, smoothTime, maxTurnSpeed);
        transform.eulerAngles = new Vector3(0,0,currentAngle);
    }
}
