using UnityEngine;

namespace Platformer
{
    public class RestartScene : MonoBehaviour
    {
        public int _sceneIndex;

        public void RestartGame()
        {
            SceneService.LoadScene(_sceneIndex);
        }
    }
}
