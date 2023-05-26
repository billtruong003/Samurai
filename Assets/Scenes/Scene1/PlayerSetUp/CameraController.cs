using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scene1
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] float CameraSpeed;
        [SerializeField] float yCharPose;
        [SerializeField] float CameraDepth;
        [SerializeField] Transform Character;

        // Update is called once per frame
        void Update()
        {
            Vector3 CharPos = new(Character.position.x, Character.position.y + yCharPose, CameraDepth);
            transform.position = Vector3.Slerp(transform.position, CharPos, CameraSpeed);
        }
    }
}