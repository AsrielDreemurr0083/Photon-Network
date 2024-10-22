using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Move))]
[RequireComponent (typeof(Rotation))]
[RequireComponent(typeof (Rigidbody))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Camera remoteCamera;
    [SerializeField] Rotation rotation;
    [SerializeField] Rigidbody rigidBody;
    private void Awake()
    {
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
        rigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        rotation.InputRotateY();
    }

    public void FixedUpdate()
    {
        move.Movement(rigidBody);

        rotation.RotateY(rigidBody);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    move.Movement();
    //    rotation.RotateY();
    //    rotation.RotateX();
    //}

    public void DisableCamera()
    {
        // 현재 플레이어가 나 자신이라면
        if(photonView.IsMine) 
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
