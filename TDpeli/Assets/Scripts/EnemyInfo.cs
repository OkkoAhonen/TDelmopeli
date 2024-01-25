using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite enemySprite;
    public int health;
    public float speed;
    public int damage;
    public float spawnSpeed;
}
