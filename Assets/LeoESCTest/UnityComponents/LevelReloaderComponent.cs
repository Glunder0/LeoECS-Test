using UnityEngine;
using UnityEngine.SceneManagement;

namespace LeoESCTest.UnityComponents
{
    public class LevelReloaderComponent : MonoBehaviour
    {
        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}