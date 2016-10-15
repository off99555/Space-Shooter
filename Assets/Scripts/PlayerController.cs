﻿using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 1.0f;
        public Boundary boundary;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            var velocity = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = speed*velocity;
            rb.position = boundary.Clamp(rb.position);
        }
    }

    [Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;

        public Vector3 Clamp(Vector3 vector)
        {
            var vector3 = new Vector3(
                Mathf.Clamp(vector.x, xMin, xMax),
                vector.y,
                Mathf.Clamp(vector.z, zMin, zMax)
                );
            Debug.Log(vector3);
            return vector3;
        }
    }
}