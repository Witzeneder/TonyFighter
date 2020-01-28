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

    private void OnCollisionEnter(Collision other)
    {
        
        Debug.Log("hit something");
        
        if (!NetworkServer.active)
        {
            return;
        }

        if (destroyed)
        {
            return;
        }

        Ground ground = other.gameObject.GetComponent<Ground>();
        if (ground != null)
        {
            Destroy(gameObject);
        }
        
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            
            Debug.Log("Player hit!");
            if (player != _owner)
            {
                player.takeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Bullet Destroyed!");
    }
}
