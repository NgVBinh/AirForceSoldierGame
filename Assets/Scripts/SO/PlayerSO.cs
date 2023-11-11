using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfor", menuName = "new player infor")]
public class PlayerSO : ScriptableObject
{
    public float hp;
    public float damageBullet;
    public float rangeBullet;
    public float damageRocket;
    public float rangeRocket;

    public float GetHp()
    {
        return hp;
    }
    public float GetDamageBullet()
    {
        return damageBullet;
    }

    public float GetRangeBullet()
    {
        return rangeBullet;
    }
    public float GetDamageRocket()
    {
        return damageRocket;
    }
    public float GetRangeRocket()
    {
        return rangeRocket;
    }

    public void SetHp(float value)
    {
        hp = value;
    }

    public void SetDamageBullet(float value)
    {
        damageBullet = value;
    }
    public void SetRangeBullet(float value)
    {
        rangeBullet = value;
    }
    public void SetDamageRocket(float value)
    {
        damageRocket = value;
    }
    public void SetRangeRocket(float value)
    {
        rangeRocket = value;
    }
}
