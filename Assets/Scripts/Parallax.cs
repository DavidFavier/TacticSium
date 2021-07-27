using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;


    public void Start()
    {
        //Taking off Z axis
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    //Every frame the camera will move at the same travel speed as the player along the parallax background
    public void Update()
    {
        Vector2 newPos = startPosition + travel;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }

}
