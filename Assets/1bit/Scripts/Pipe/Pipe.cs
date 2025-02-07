using Unity.VisualScripting;
using UnityEngine;

namespace _1bit.Scripts
{
    public class Pipe : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.transform.position = new Vector2(0f, 0f);
        }
    }
}