using UnityEngine;

namespace _1bit.Scripts.Core
{
    public class LevelManager : MonoBehaviour, IInitializable
    {
        public void Initialize()
        {
            Debug.Log("LevelManager initialized");
        }
    }
}