using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        Vector3 moveUp = transform.position;
        moveUp.y += 0.01f;
        transform.position = moveUp;
    }
}
