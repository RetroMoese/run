using UnityEngine.SceneManagement;


namespace Platformer
{
    public class SceneService
    {
        public static void LoadScene(int SceneIndex)
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }
}