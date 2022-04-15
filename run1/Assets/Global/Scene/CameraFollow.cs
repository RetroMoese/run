using Leopotam.EcsLite;
using UnityEngine;

namespace Platformer
{
    public class CameraFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        private int cameraEntity;

        public void Init(EcsSystems ecsSystems)
        {
            var data = ecsSystems.GetShared<Data>();

            var cameraEntity = ecsSystems.GetWorld().NewEntity();

            var cameraPool = ecsSystems.GetWorld().GetPool<CameraComponent>();
            cameraPool.Add(cameraEntity);
            ref var cameraComponent = ref cameraPool.Get(cameraEntity);

            cameraComponent.cameraTransform = Camera.main.transform;
            cameraComponent.cameraSmoothness = data.configurationScriptableObjects.cameraFollowSmoothness;
            cameraComponent.curVelocity = Vector3.zero;
            cameraComponent.offset = new Vector3(20f, 10f, 0);

            this.cameraEntity = cameraEntity;
        }

        public void Run(EcsSystems ecsSystems)
        {
            var filter = ecsSystems.GetWorld().Filter<PlayerComponents>().End();
            var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponents>();
            var cameraPool = ecsSystems.GetWorld().GetPool<CameraComponent>();

            ref var cameraComponent = ref cameraPool.Get(cameraEntity);

            foreach (var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);

                Vector3 currentPosition = cameraComponent.cameraTransform.position;
                Vector3 targetPoint = playerComponent.playerTransform.position + cameraComponent.offset;

                cameraComponent.cameraTransform.position =
                    Vector3.SmoothDamp(currentPosition, targetPoint,
                    ref cameraComponent.curVelocity, cameraComponent.cameraSmoothness);
            }
        }
    }
}
