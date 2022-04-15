using Leopotam.EcsLite;
using UnityEngine;

namespace Platformer
{
    public class CoinHitSystem : IEcsRunSystem
    {
        public void Run(EcsSystems ecsSystems)
        {
            var data = ecsSystems.GetShared<Data>();
            var hitFilter = ecsSystems.GetWorld().Filter<HitComponent>().End();
            var hitPool = ecsSystems.GetWorld().GetPool<HitComponent>();
            var playerFilter = ecsSystems.GetWorld().Filter<PlayerComponents>().End();
            var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponents>();

            foreach (var hitEntity in hitFilter)
            {
                ref var hitComponent = ref hitPool.Get(hitEntity);

                foreach (var playerEntity in playerFilter)
                {
                    ref var playerComponent = ref playerPool.Get(playerEntity);

                    if (hitComponent.other.CompareTag(Constants.Tags.CoinTag))
                    {
                        Debug.Log(hitComponent.other);
                        int i = 1;
                        playerComponent.coins += i;
                        data.coinCounter.text = playerComponent.coins.ToString();
                    }
                }

            }
        }
    }
}