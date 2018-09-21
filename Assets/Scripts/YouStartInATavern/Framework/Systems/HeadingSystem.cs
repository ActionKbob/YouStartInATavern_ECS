namespace YouStartInATavern.Framework
{
    using Unity.Entities;
    using Character.Player;

    public class HeadingSystem : ComponentSystem
    {
        public struct HeadingData
        {
            public readonly int Length;
            public readonly ComponentArray<PlayerInput> Input;
            public ComponentArray<Heading2D> Heading;
        }

        [ Inject ]
        private HeadingData headingData;

        protected override void OnUpdate()
        {
            for( int i = 0; i < headingData.Length; i++ )
            {
                PlayerInput input = headingData.Input[ i ];
                Heading2D heading = headingData.Heading[ i ];

                if( input.Move.x != 0 || input.Move.y != 0 )
                    heading.Value = input.Move;
            }
        }
    }
}