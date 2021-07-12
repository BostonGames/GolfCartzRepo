using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 offset;
    [SerializeField] float smoothrate;
    

    void Start()
    {
        offset = player.position - transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 currentpos = transform.position;
        Vector3 newPos = player.position - offset;

        transform.position = Vector3.Lerp(currentpos, newPos, smoothrate * Time.deltaTime);
    }
}
