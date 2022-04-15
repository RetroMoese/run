using Leopotam.EcsLite;
using UnityEngine;


namespace Platformer
{
  public class PlayerMoveSystem : IEcsRunSystem
  {
        public void Run(EcsSystems ecs)
        {
            var filter = ecs.GetWorld().Filter<PlayerComponents>().Inc<PlayerInputSystemComponents>().End();
            var playerPool = ecs.GetWorld().GetPool<PlayerComponents>();
            var playerInputPool = ecs.GetWorld().GetPool<PlayerInputSystemComponents>();
            foreach (var entity in filter)
            {
                ref var playerComponents = ref playerPool.Get(entity);
                ref var playerInputSystemComponents = ref playerInputPool.Get(entity);


                playerComponents.rigidbody.AddForce(playerInputSystemComponents.moveDirection * playerComponents.playerSpeed, ForceMode.Acceleration);
            }
        }
  }
}
