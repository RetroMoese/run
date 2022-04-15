using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "Configuration")]
    public class ConfigurationScriptableObjects : ScriptableObject
    {
        public float PlayerSpeed;
        public float CheckRadius;
        public float cameraFollowSmoothness;
    }
}


