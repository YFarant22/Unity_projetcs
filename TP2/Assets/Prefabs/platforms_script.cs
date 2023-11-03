using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platforms_script : MonoBehaviour
{
    public float speed = 5f;
    
    void Update()
    {
        float deltaTime = Time.deltaTime;
        transform.Translate(-speed * deltaTime, 0, 0);
    }
}