using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int _maxHp = 100;
    [SerializeField] private int _currentHp;
    [SerializeField] private HPBar hPBar;

    private void Awake()
    {
        _currentHp = _maxHp;        
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;

        if(_currentHp <= 0)
        {
            gameObject.SetActive(false);
        }

        if(hPBar == null)
        {
            hPBar = GetComponentInChildren<HPBar>();
        }
        hPBar.SetHpCount(_currentHp, _maxHp);
    }

    public void Heal(int amount)
    {
        if(_currentHp <= 0)
        {
            return;
        }
        
        _currentHp += amount;
        
        if(_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
    }
}
