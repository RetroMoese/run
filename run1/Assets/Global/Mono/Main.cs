using Leopotam.EcsLite;
using UnityEngine.UI;
using UnityEngine;
using Leopotam.EcsLite.ExtendedSystems;
using Unity.VisualScripting;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        private EcsWorld ecsWorld;
        private EcsSystems initSystems;
        private EcsSystems updateSystems;
        private EcsSystems fixedUpdateSystems;
        [SerializeField] private ConfigurationScriptableObjects _configuration;
        [SerializeField] private SceneService _service;
        [SerializeField] private Text _coinCounter;
        [SerializeField] private GameObject _playerWinPanel;



        private void Start()
        {

            ecsWorld = new EcsWorld();
            var data = new Data
            {
                configurationScriptableObjects = _configuration,
                sceneService = _service,
                coinCounter = _coinCounter,
                playerWinPanel = _playerWinPanel
            };

            initSystems = new EcsSystems(ecsWorld, data)
                .Add(new PlayerInitializationSystem());

            initSystems.Init();

            updateSystems = new EcsSystems(ecsWorld, data)
                .Add(new PlayerInputSystem())
                .Add(new CoinHitSystem())
                .DelHere<HitComponent>();

            updateSystems.Init();

            fixedUpdateSystems = new EcsSystems(ecsWorld, data)
                .Add(new PlayerMoveSystem())
                .Add(new CameraFollowSystem());

            fixedUpdateSystems.Init();
        }

       private void Update()
       {
           updateSystems.Run();
       }
       
       private void FixedUpdate()
       {
           fixedUpdateSystems.Run();
       }
       
       private void OnDestroy()
       {
           initSystems.Destroy();
           updateSystems.Destroy();
           fixedUpdateSystems.Destroy();
           ecsWorld.Destroy();
       }
    }
}

