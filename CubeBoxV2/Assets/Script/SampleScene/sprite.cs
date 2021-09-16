﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class sprite : MonoBehaviour
{
    public float speed;
    public float left;
    public float offset;

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if (position.x < left)
            transform.Translate(offset, 0, 0);
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
