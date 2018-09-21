namespace YouStartInATavern.Framework
{
    using Unity.Entities;
    using Unity.Mathematics;
    using UnityEngine;

    public class MoveSystem : ComponentSystem
    {
        public struct MoveData
        {
            public readonly int Length;
            public readonly ComponentArray<Move2D> Move;
            public ComponentArray<Position2D> Position;
            public readonly ComponentArray<BoxCollider2D> Collider;
        }

        [ Inject ]
        private MoveData moveData;

        protected override void OnUpdate()
        {
            float deltaTime = Time.deltaTime;

            for( int i = 0; i < moveData.Length; i++ )
            {
                Move2D move = moveData.Move[ i ];
                Position2D position = moveData.Position[ i ];
                
                if( move.Value.x != 0 )
                    MoveHorizontally( ref move.Value );

                if( move.Value.y != 0 )
                    MoveVertically( ref move.Value );

                position.Value += move.Value * deltaTime;
            }
        }

        private void MoveHorizontally( ref float2 _delta )
        {
            //TODO : CheckRaycasts and alter delta based on those ...things
        }

        private void MoveVertically( ref float2 _delta )
        {
            //TODO : CheckRaycasts and alter delta based on those ...things
        }
    }
}