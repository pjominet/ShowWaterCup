using System;
using System.Collections.Generic;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerInstance
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }
        public int Hitpoints { get; set; }
        
        public MapPosition Position { get; set; }
        public int ActionPoints { get; set; }
        
        public int ViewRadius { get; set; }
        
        private PlayerAI _playerAi { get; set; }

        public PlayerInstance(int playerId, string name, Character character, int hitpoints, MapPosition position, int viewRadius)
        {
            PlayerId = playerId;
            Name = name;
            Character = character;
            Hitpoints = hitpoints;
            Position = position;
            _playerAi = new PlayerAI(this, null);
            ActionPoints = 1; // to make testing easier
            ViewRadius = viewRadius;
        }

        public List<RoundAction> Play(Random rnd)
        {
            var actions = new List<RoundAction>();
            for (var i = 0; i < ActionPoints; i++)
            {
                var action = _playerAi.Play(rnd);
                if (action != null)
                    actions.Add(action);
            }

            return actions;
        }
    }
}