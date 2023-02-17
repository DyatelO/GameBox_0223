using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int _maxHp = 100;
    [SerializeField] private int _currentHp;
    [SerializeField] private HPBar hPBar;
    [SerializeField] private int _armor = 10;

    public float healthRegenerationRate = 1f;
    public float healthRegenerationTimer;

    public int Armor { get => _armor; set => _armor = value; }

    private void Awake()
    {
        _currentHp = _maxHp;        
    }

    private void Update()
    {
        healthRegenerationTimer += Time.deltaTime * healthRegenerationRate;

        if(healthRegenerationTimer > 0)
        {
            Heal(1);
            healthRegenerationTimer += 1f;
        }
    }

    public void TakeDamage(int damage)
    {
        if(damage / _armor < 0.5f )
        {
            damage = 1;
            _currentHp -= (damage); 
        }
        else
        {
            _currentHp -= (damage + Armor);
        }

        if(_currentHp <= 0)
        {
            gameObject.SetActive(false);
            GetComponent<CharacterGameOver>().GameOver();
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
