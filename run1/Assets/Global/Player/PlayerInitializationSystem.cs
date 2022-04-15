using Leopotam.EcsLite;
using UnityEngine;

namespace Platformer
{
    public class PlayerInitializationSystem : IEcsInitSystem
    {
        public void Init(EcsSystems ecs)
        {
            var ecsWorld = ecs.GetWorld();
            var Data = ecs.GetShared<Data>();

            var playerEntity = ecsWorld.NewEntity();

            var playerComponentsPool = ecsWorld.GetPool<PlayerComponents>();
            playerComponentsPool.Add(playerEntity);
            ref var playerCmponents = ref playerComponentsPool.Get(playerEntity);
            var playerInputSystem = ecsWorld.GetPool<PlayerInputSystemComponents>();
            playerInputSystem.Add(playerEntity);
            ref var playerInputPool = ref playerInputSystem.Get(playerEntity);


            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponentInChildren<CheckCollision>().ecsWorld = ecsWorld;
            playerCmponents.playerSpeed = Data.configurationScriptableObjects.PlayerSpeed;
            playerCmponents.playerTransform = player.transform;
            playerCmponents.capsuleCollider = player.GetComponent<CapsuleCollider>();
            playerCmponents.rigidbody = player.GetComponent<Rigidbody>();
        }
    }
}

