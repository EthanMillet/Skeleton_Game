using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class bossCamera : MonoBehaviour
{
    public GameObject cameraPositioner;
    public float move;
    private GameObject player;
    private CameraFollow camerafollow;
    private Camera mainCam;

    private void Start()
    {
        player = GameObject.Find("Player");
        cameraPositioner = GameObject.Find("CameraPositioner");
        mainCam = Camera.main;
    }

    public void BossCameraMovetoPoint()
    {
        GetComponent<CameraFollow>().enabled = false;
        transform.position = cameraPositioner.transform.position;
        Vector2.MoveTowards(transform.position, cameraPositioner.transform.position, move * Time.deltaTime);
        mainCam.orthographicSize = 9f;
    }

    public void bossCameraReturnToPlayer()
    {
        GetComponent<CameraFollow>().enabled = true;
        transform.position = cameraPositioner.transform.position;
    }
}
