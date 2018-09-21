namespace YouStartInATavern.Character.Player
{
    using Unity.Entities;
    using UnityEngine;
    using Framework;

    public class PlayerWalkSystem : ComponentSystem
    {
        public struct WalkData
        {
            public readonly int Length;
            public readonly ComponentArray<Walking> Walking;
            public readonly ComponentArray<PlayerInput> Input;
            public ComponentArray<Move2D> Move;
        }

        [ Inject ]
        private WalkData walkData;

        protected override void OnUpdate()
        {
            float deltaTime = Time.deltaTime;

            for( int i = 0; i < walkData.Length; i++ )
            {
                PlayerInput input = walkData.Input[ i ];
                Move2D move = walkData.Move[ i ];

                move.Value = input.Move * 10; //TODO : Store speed somewhere so it's not an arbitrary number. Perhaps on the player?
            }
        }
    }
}