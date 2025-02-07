using Unity.VisualScripting;
using UnityEngine;

namespace _1bit.Scripts.Heart
{
    public class Heart : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}