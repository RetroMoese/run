using Leopotam.EcsLite;
using UnityEngine;

namespace Platformer
{
    public class CheckCollision : MonoBehaviour
    {
        public EcsWorld ecsWorld {get;set;}

       //private void OnCollisionEnter(Collision collision)
       //{
       //    var hit = ecsWorld.NewEntity();
       //
       //    var hitPool = ecsWorld.GetPool<HitComponent>();
       //    hitPool.Add(hit);
       //    ref var hitComponent = ref hitPool.Get(hit);
       //
       //    hitComponent.first = transform.root.gameObject;
       //    hitComponent.other = collision.gameObject;
       //}

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.Tags.CoinTag))
            {
                other.gameObject.SetActive(false);
                // instantly destroy coin to avoid multiple OnTriggerEnter() calls.
            }
            var hit = ecsWorld.NewEntity(); // Create new Entity

            var hitPool = ecsWorld.GetPool<HitComponent>(); // Get Component
            hitPool.Add(hit); // Add entity at Component
            ref var hitComponent = ref hitPool.Get(hit); 

            hitComponent.first = transform.root.gameObject;
            hitComponent.other = other.gameObject;
        }

    }
}

