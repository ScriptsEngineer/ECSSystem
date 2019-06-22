using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

namespace JobSystem
{
    public class GameManager : GameManagerAsbtract
    {

        TransformAccessArray transforms;
        MovementJob moveJob;
        JobHandle moveHandle;


        private void OnDisable()
        {
            moveHandle.Complete();
            transforms.Dispose();
        }

        private void Start()
        {
            transforms = new TransformAccessArray(0, -1);
            Init();
        }

        private void Update()
        {
            moveHandle.Complete();

            CheckInput();

            moveJob = new MovementJob()
            {
                moveSpeed = enemySpeed,
                topBound = topBound,
                bottomBound = bottomBound,
                deltaTime = Time.deltaTime
            };

            moveHandle = moveJob.Schedule(transforms);
            JobHandle.ScheduleBatchedJobs();
        }

        protected override void AddShips(int amount)
        {
            moveHandle.Complete();
            transforms.capacity = transforms.length + amount;

            for (int i = 0; i < amount; i++)
            {
                GameObject obj = InstantiateShip();
                transforms.Add(obj.transform);
            }

            InsertAmount(amount);
        }
    }
}

