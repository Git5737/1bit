using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;

namespace _1bit.Scripts.Spring
{
    public class Spring : MonoBehaviour
    {
        private Animator _animator;
        private bool _isActivation = true;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            StartCoroutine(SpringActivation());
            if (_isActivation)
            {
                _animator.SetBool("IsUsed", true);
                other.gameObject.GetComponent<Rigidbody2D>()?.AddForce(Vector2.up * 350f);   
            }
        }

        private IEnumerator SpringActivation()
        {
            yield return new WaitForSeconds(0.1f);
            _isActivation = false;
        }
    }
}