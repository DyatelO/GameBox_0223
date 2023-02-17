using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAxeWeapon : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 2;
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

    private void SpawnAxe()
    {
        GameObject thrownAxe = Instantiate(axePrefab);
        thrownAxe.transform.position = transform.position;
    }
}
