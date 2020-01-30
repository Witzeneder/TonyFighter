using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{

    public bool destroyed = false;

    private bool _bounce = false;
    private int _damage = 5;

    private GameObject _owner;

    public void Config(GameObject owner, int damage, bool bounce, float lifetime)
    {
        _owner = owner;
        _damage = damage;
        _bounce = bounce;

        if (GetComponent<NetworkIdentity>().isServer)
        {
            Destroy(gameObject, lifetime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("hit");
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            
            if (player != _owner)
            {
                player.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
        
        
    }

    private void OnDestroy()
    {
        Debug.Log("Bullet Destroyed!");
    }
}
