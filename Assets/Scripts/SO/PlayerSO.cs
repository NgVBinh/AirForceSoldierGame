using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfor", menuName = "new player infor")]
public class PlayerSO : ScriptableObject
{
    public float hp;
    public float maxSpeed;
    public float damageBullet;
    public float timeBullet;
    public float damageRocket;
    public float timeRocket;

    public float GetHp()
    {
        return hp;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public float GetDamageBullet()
    {
        return damageBullet;
    }

    public float GetTimeBullet()
    {
        return timeBullet;
    }
    public float GetDamageRocket()
    {
        return damageRocket;
    }
    public float GetTimeRocket()
    {
        return timeRocket;
    }

    // set infor
    public void SetHp(float value)
    {
        hp = value;
    }

    public void SetMaxSpeed(float value)
    {
        maxSpeed = value;
    }
    public void SetDamageBullet(float value)
    {
        damageBullet = value;
    }
    public void SetTimeBullet(float value)
    {
        timeBullet = value;
    }
    public void SetDamageRocket(float value)
    {
        damageRocket = value;
    }
    public void SetTimeRocket(float value)
    {
        timeRocket = value;
    }
}
