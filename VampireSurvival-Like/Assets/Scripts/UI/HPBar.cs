using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Transform hpBarTransform;

    private void Awake()
    {
        
    }

    public void SetHpCount(int currentHp, int maxHp)
    {
        float state = currentHp;
        state /= maxHp;
        if(state <=0)
        {
            state = 0;
        }
        hpBarTransform.localScale = new Vector2(state, 1f);
    }
}
