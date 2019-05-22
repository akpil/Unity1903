using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackField : MonoBehaviour
{
    [SerializeField]
    private Player owner;
    private void Awake()
    {
        owner = transform.parent.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("Hit", owner.GetDamage());
        }
    }
}
