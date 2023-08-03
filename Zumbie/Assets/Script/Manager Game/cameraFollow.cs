using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private Vector3 _zeroMove = Vector3.zero;
        
    void FixedUpdate()
    {       
        Vector3 posSmooth = Vector3.SmoothDamp(transform.position, _player.position, ref _zeroMove, 0.1f);
        transform.position = posSmooth + new Vector3(0,0,-11);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-32,35.5f),transform.position.y,transform.position.z);
    }
}
