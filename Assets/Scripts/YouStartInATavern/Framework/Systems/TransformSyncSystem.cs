namespace YouStartInATavern.Framework
{
    using Unity.Collections;
    using Unity.Entities;
    using UnityEngine;

    public class  PositionSyncSystem : ComponentSystem
    {
        public struct Data
        {
            public Transform Output;
            public readonly Position2D Position;
        }

        protected override void OnUpdate()
        {
            foreach( Data entity in GetEntities<Data>() )    
            {
                entity.Output.position = new Vector3( entity.Position.Value.x, entity.Position.Value.y, 0 );
            }
        }
    }
}