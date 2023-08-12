using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    private void Update()
    {
        transform.position = target.position;
    }
}