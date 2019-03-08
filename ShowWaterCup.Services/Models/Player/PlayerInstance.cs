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
        
        private PlayerPosition _position { get; set; }
        private int _actionPoints { get; set; }
        
        private PlayerAI _playerAi { get; set; }

        public PlayerInstance(string name, Character character, int hitpoints, PlayerPosition position)
        {
            Name = name;
            Character = character;
            Hitpoints = hitpoints;
            _position = position;
            _actionPoints = 2;
            _playerAi = new PlayerAI(this);
        }

        public List<RoundAction> Play()
        {
            var rounds = new List<RoundAction>();
            for (var i = 0; i < _actionPoints; i++)
            {
                rounds.Add(_playerAi.Play());
            }

            return rounds;
        }
        
    }
}