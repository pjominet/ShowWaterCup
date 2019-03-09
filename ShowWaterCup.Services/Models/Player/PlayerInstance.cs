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
        
        public PlayerPosition Position { get; set; }
        public int ActionPoints { get; set; }
        
        private PlayerAI _playerAi { get; set; }

        public PlayerInstance(string name, Character character, int hitpoints, PlayerPosition position)
        {
            Name = name;
            Character = character;
            Hitpoints = hitpoints;
            Position = position;
            ActionPoints = 2;
            _playerAi = new PlayerAI(this, null);
        }

        public List<RoundAction> Play()
        {
            var rounds = new List<RoundAction>();
            for (var i = 0; i < ActionPoints; i++)
            {
                rounds.Add(_playerAi.Play());
            }

            return rounds;
        }
        
    }
}