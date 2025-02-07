using UnityEngine;
using UnityEngine.SceneManagement;

namespace _1bit.Scripts
{
    public class SceneController : MonoBehaviour
    {
        private readonly string _menuScene = "Menu";
        private readonly string _gameScene = "Game";

        public void ToGameScene()
        {
            SceneManager.LoadScene(_gameScene);
        }
    }
}