using System;
using UnityEngine;

namespace _1bit.Scripts.Coin
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}