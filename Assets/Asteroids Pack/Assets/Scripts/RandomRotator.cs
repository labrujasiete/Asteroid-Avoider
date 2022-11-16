using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField] private float speed;
    private float astRot = 1f;
    


    private void FixedUpdate()
    {
        transform.Rotate(astRot * speed,astRot * speed,0, Space.Self);   
    }

}