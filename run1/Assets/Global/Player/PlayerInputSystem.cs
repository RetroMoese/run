using UnityEngine;
using Leopotam.EcsLite;

namespace Platformer
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        public void Run(EcsSystems ecs)
        {
            var filter = ecs.GetWorld().Filter<PlayerInputSystemComponents>().Inc<PlayerComponents>().End();
            var playerInputPool = ecs.GetWorld().GetPool<PlayerInputSystemComponents>();
            var playerComponentsPool = ecs.GetWorld().GetPool<PlayerComponents>();
            var data = ecs.GetShared<Data>();


            foreach (var entity in filter)
            {
                ref var playerInput = ref playerInputPool.Get(entity);
                ref var playerComponents = ref playerComponentsPool.Get(entity);


                if(playerComponents.coins >= 1000)
                {
                    data.playerWinPanel.SetActive(true);
                }


                if (Input.GetMouseButton(0))
                {
                    var input = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                    var getInput = input.x;

                    if (getInput < 0.5f)
                    {
                        playerInput.moveDirection.z = -1;
                    }
                    else if (getInput > 0.5)
                    {
                        playerInput.moveDirection.z = 1;
                    }
                }
                else
                {
                    playerInput.moveDirection.z = 0;
                }

               //if (Input.touchCount > 0)
               //{
               //    var input = Camera.main.ScreenToViewportPoint(Input.mousePosition);
               //
               //    var getInput = input.x;
               //
               //    Touch touch = Input.GetTouch(0);
               //    if (touch.phase == TouchPhase.Moved)
               //    {
               //        if (getInput < 0.5f)
               //        {
               //            playerInput.moveDirection.z = -1;
               //        }
               //        else if (getInput > 0.5)
               //        {
               //            playerInput.moveDirection.z = 1;
               //        }
               //    }
               //    else if (touch.phase == TouchPhase.Ended)
               //    {
               //        playerInput.moveDirection.z = 0;
               //    }
               //}
            }
        }
    }
}