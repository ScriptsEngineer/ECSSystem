using UnityEngine;
using Unity.Entities;
using System;


namespace ECS
{
    [Serializable]
    public struct MoveComponent : IComponentData
    {
        public float speed;
    }

    //public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed> {}
}
