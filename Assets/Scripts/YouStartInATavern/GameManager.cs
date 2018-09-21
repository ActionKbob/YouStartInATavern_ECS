namespace YouStartInATavern
{
    using System.Collections.Generic;
    using Unity.Mathematics;
    using UnityEngine;
    using Rewired;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance{ get; private set; }
        public Player[] RewiredPlayers{ get; private set; }

        #region Inspector Properties
        public MovementSettings MovementSettings;
        #endregion

        void Awake()
        {
            if( Instance == null )
                Instance = this;
            else if( Instance != this )
                Destroy( gameObject );

            CollectReWiredPlayers();
        }

        private void CollectReWiredPlayers()
        {
            RewiredPlayers = new Player[ ReInput.players.playerCount ];

            for( int i = 0; i < RewiredPlayers.Length; i++ )
            {
                RewiredPlayers[ i ] = ReInput.players.GetPlayer( i );
            }
        }
    }

    [ System.Serializable ]
    public class MovementSettings
    {
        public float SkinWidth;
        public float2 RayCount;
    }
}