using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="EnemyInfor",menuName ="Create Enemy Infor")]
public class EnemySO : ScriptableObject
{
    public string enemyID;
    
    public float hp;   
    public float damageBullet;
    public float rangeAttack;
    public float damageRocket;

    public string GetEnemyID()
    {
        return enemyID;
    }
    public float GetHp()
    {
        return hp;
    }
    public float GetDamageBullet()
    {
        return damageBullet;
    }

    public float GetRangeAttack()
    {
        return rangeAttack;
    }
    public float GetDamageRocket()
    {
        return damageRocket;
    }

    public void SetHp(float value)
    {
        hp = value;
    }

    public void SetDamageBullet(float value)
    {
        damageBullet = value;
    }
    public void SetRangeAttack(float value)
    {
        rangeAttack = value;
    }
    public void SetDamageRocket(float value)
    {
        damageRocket = value;
    }

}
