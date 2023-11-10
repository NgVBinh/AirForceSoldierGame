using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public string enemyName;
    public Transform targetTransform;
    public int health;
    public int damage;

    public virtual void Move(bool canMove)
    {
        
    }

    public  void Attack()
    {
        
    }

    protected virtual void Die()
    {
        // Logic xử lý khi enemy bị loại khỏi trò chơi
    }
}
