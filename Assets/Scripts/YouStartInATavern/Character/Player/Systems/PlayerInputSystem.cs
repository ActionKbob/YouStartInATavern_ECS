namespace YouStartInATavern.Character.Player
{
    using Unity.Entities;
    using Unity.Mathematics;
    using Rewired;

    public class PlayerInputSystem : ComponentSystem
    {
        public struct Data
        {
            public readonly int Length;
            public ComponentArray<Player> Player;
            public ComponentArray<PlayerInput> Input;
        }
        [ Inject ]
        private Data playerInputData;
        
        protected override void OnUpdate()
        {

            Rewired.Player[] rewiredPlayers = GameManager.Instance.RewiredPlayers;

            for( int i = 0; i < playerInputData.Length; i++ )
            {
                Player player = playerInputData.Player[ i ];
                PlayerInput input = playerInputData.Input[ i ];

                if( rewiredPlayers[ player.Id ] != null )
                {
                    float moveX = rewiredPlayers[ player.Id ].GetAxis( "Move Horizontally" );
                    float moveY = rewiredPlayers[ player.Id ].GetAxis( "Move Vertically" );
                    
                    float2 movementVector = float2.zero;

                    if( moveX != 0 || moveY != 0 )
                        movementVector = math.normalize( new float2( moveX, moveY ) );

                    input.Move = movementVector;
                    input.Dodge = rewiredPlayers[ player.Id ].GetButton( "Dodge" );
                }
            }
        }
    }
}