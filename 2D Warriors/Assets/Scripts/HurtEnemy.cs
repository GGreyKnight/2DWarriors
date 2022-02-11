using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            if(Player.gameObject.GetComponent<PlayerHealthManager>().playerCurrentHealth <= 48)
            {
                Player.gameObject.GetComponent<PlayerHealthManager>().playerCurrentHealth += 2;
            }
            else
            {
                Player.gameObject.GetComponent<PlayerHealthManager>().SetMaxHealth();// = Player.gameObject.GetComponent<PlayerHealthManager>().playerMaxHealth;
            }
            
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
        }
    }
}
