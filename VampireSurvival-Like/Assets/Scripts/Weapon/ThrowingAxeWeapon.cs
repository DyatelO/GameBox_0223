using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAxeWeapon : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 1.5f;
    private float timer;

    private PlayerMove _playerMove;

    [SerializeField] private GameObject axePrefab;

    private void Awake()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnAxe();
    }

    private void FixedUpdate()
    {
        //if (timer == 0)
        //{
        //    SpawnAxe();
        //}
    }

    private void SpawnAxe()
    {
        GameObject thrownAxe = Instantiate(axePrefab);
        thrownAxe.transform.position = transform.position;
        //thrownAxe.transform.localEulerAngles = Vector3.forward * -45;
        thrownAxe.GetComponent<ThrownAxeProjectile>().SetDirection(_playerMove.LastHorizontalVectorLength , Vector2.up.y + 10);
            //_playerMove.LastHorizontalVectorLength, 0.125f);
    }
}
