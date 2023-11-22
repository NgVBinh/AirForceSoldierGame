using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePlayer : MonoBehaviour
{
    [SerializeField] private PlayerSO playerInfor;

    [SerializeField] private Text playerCoin;
    [Header("Text Infor Player")]
    [SerializeField] private Text txtHealth;
    [SerializeField] private Text txtMaxSpeed;
    [SerializeField] private Text txtDamageBullet;
    [SerializeField] private Text txtTimeBullet;
    [SerializeField] private Text txtDamageRocket;
    [SerializeField] private Text txtTimeRocket;

    [Header("Text Button")]
    [SerializeField] private Text btnHealth;
    [SerializeField] private Text btnSpeed;
    [SerializeField] private Text btnDamageBullet;
    [SerializeField] private Text btnTimeBullet;
    [SerializeField] private Text btnDamageRocket;
    [SerializeField] private Text btnTimeRocket;

    private int coinHp;
    private int coinSpeed;
    private int coinDamageBullet;
    private int coinTimeBullet;
    private int coinDamageRocket;
    private int coinTimeRocket;
    private void Start()
    {
        CoinToUpgrade();
        Display();
    }

    private void Display()
    {
        playerCoin.text = PlayerPrefs.GetInt("Coin")+" $ ";

        txtHealth.text = "Heath: " + ConvertFloat(playerInfor.GetHp());
        txtMaxSpeed.text = "Max Speed: " + ConvertFloat(playerInfor.GetMaxSpeed());
        txtDamageBullet.text = "Damage Bullet: " + ConvertFloat(playerInfor.GetDamageBullet());
        txtTimeBullet.text = "Time Bullet: " + ConvertFloat(playerInfor.GetTimeBullet());
        txtDamageRocket.text = "Damage Rocket: " + ConvertFloat(playerInfor.GetDamageRocket());
        txtTimeRocket.text = "Time Rocket: " + ConvertFloat(playerInfor.GetTimeRocket());

        btnHealth.text = coinHp + "$";
        btnSpeed.text = coinSpeed + "$";
        btnDamageBullet.text = coinDamageBullet + "$";
        btnTimeBullet.text = coinTimeBullet + "$";
        btnDamageRocket.text = coinDamageRocket + "$";
        btnTimeRocket.text = coinTimeRocket + "$";

    }
    private void CoinToUpgrade()
    {
        coinHp = Convert.ToInt32(playerInfor.GetHp() / 10);
        coinSpeed = Convert.ToInt32(playerInfor.GetMaxSpeed());
        coinDamageBullet = Convert.ToInt32(playerInfor.GetDamageBullet() * 4);
        coinTimeBullet = Convert.ToInt32(playerInfor.GetTimeBullet() *100);
        coinDamageRocket = Convert.ToInt32(playerInfor.GetDamageRocket());
        coinTimeRocket = Convert.ToInt32(playerInfor.GetTimeRocket() * 10);

    }

    public void UpgradeHp()
    {

        if (PlayerPrefs.GetInt("Coin") >= coinHp)
        {
            playerInfor.SetHp(playerInfor.GetHp() + playerInfor.GetHp() / 10);
            PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") - coinHp));
            CoinToUpgrade();
            Display();

        }
    }

    public void UpgradeSpeed() {
        if (PlayerPrefs.GetInt("Coin") >= coinSpeed)
        {
            playerInfor.SetMaxSpeed(playerInfor.GetMaxSpeed() + playerInfor.GetMaxSpeed() / 10);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - coinSpeed);
            CoinToUpgrade();
            Display();
        }
    }
    public void UpgradeDamageBullet() {
        if (PlayerPrefs.GetInt("Coin") >= coinDamageBullet)
        {
            playerInfor.SetDamageBullet(playerInfor.GetDamageBullet() + playerInfor.GetDamageBullet() / 10);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - coinDamageBullet);
            CoinToUpgrade();
            Display();
        }
    }
    public void UpgradeDamageRocket() {
        if (PlayerPrefs.GetInt("Coin") >= coinDamageRocket)
        {
            playerInfor.SetDamageRocket(playerInfor.GetDamageRocket() + playerInfor.GetDamageRocket() / 10);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - coinDamageRocket);
            CoinToUpgrade();
            Display();
        }
    }
    public void UpgradeTimeBullet() {
        if (PlayerPrefs.GetInt("Coin") >= coinTimeBullet)
        {
            playerInfor.SetTimeBullet(playerInfor.GetTimeBullet() - playerInfor.GetTimeBullet() / 10);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - coinTimeBullet);
            CoinToUpgrade();
            Display();
        }
    }
    public void UpgradeTimeRocket() {
        if (PlayerPrefs.GetInt("Coin") >= coinTimeRocket)
        {
            playerInfor.SetTimeRocket(playerInfor.GetTimeRocket() - playerInfor.GetTimeRocket() / 10);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - coinTimeRocket);
            CoinToUpgrade();
            Display();
        }
    }

    public float ConvertFloat(float number)
    {
        float result =Convert.ToInt32(number * 10);
        result = Convert.ToSingle(result) / 10;
        return result;
    }

    public void AddCoin()
    {
        PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") + 1000));
        Display();
    }
}
