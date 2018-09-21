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
            public ComponentArray<Heading2D> Heading;
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
                Heading2D heading = moveData.Heading[ i ];

                
            }
        }

        private void MoveHorizontally( ref float2 _delta )
        {

        }

        private void MoveVertically( ref float2 _delta )
        {
            
        }
    }
}