using System;
using System.Collections.Generic;
using ShowWaterCup.Services.Models.Blockly;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Player
{
    public class PlayerAI
    {
        private PlayerInstance _player;
        private AI _aI;
        private List<PlayerAIStep> _aiSteps;

        public PlayerAI(PlayerInstance player, AI aI)
        {
            _player = player;
            _aiSteps = new List<PlayerAIStep>();
            _aI = aI;
        }

        private bool GetBoolValue(Value value)
        {
            AbstractBlock block = value.Block;
            if (block.Type.Equals("logic_boolean"))
                return Boolean.Parse(((FieldBlock)block).Field.Content);
            
            else if (block.Type.Equals("wet_feet"))            
                return true;
            
            else if (block.Type.Equals("ennemy_attack_range"))            
                return true;
            
            else
                return false;

        }

        private int GetNumericValue(Value value)
        {
            AbstractBlock block = value.Block;
            if (block.Type.Equals("math_number"))
                return int.Parse(((FieldBlock)value.Block).Field.Content);
            
            else if (block.Type.Equals("current_hitpoints"))            
                return 42;
            
            else
                return 42;
            
        }

        private bool EvaluateLogical(LogicalBlock logicalBlock)
        {
            if (logicalBlock.Field.Content.Contains("AND"))            
                return GetBoolValue(logicalBlock.LeftValue) && GetBoolValue(logicalBlock.RightValue);
            
            else if(logicalBlock.Field.Content.Contains("OR"))            
                return GetBoolValue(logicalBlock.LeftValue) || GetBoolValue(logicalBlock.RightValue);
            
            else if (logicalBlock.Field.Content.Contains("GT"))            
                return GetNumericValue(logicalBlock.LeftValue) > GetNumericValue(logicalBlock.RightValue);
            
            else if (logicalBlock.Field.Content.Contains("LT"))            
                return GetNumericValue(logicalBlock.LeftValue) < GetNumericValue(logicalBlock.RightValue);

            else if (logicalBlock.Field.Content.Contains("GTE"))
                return GetNumericValue(logicalBlock.LeftValue) >= GetNumericValue(logicalBlock.RightValue);

            else if (logicalBlock.Field.Content.Contains("LTE"))
                return GetNumericValue(logicalBlock.LeftValue) <= GetNumericValue(logicalBlock.RightValue);

            else if (logicalBlock.Field.Content.Contains("NEQ"))
                return GetNumericValue(logicalBlock.LeftValue) != GetNumericValue(logicalBlock.RightValue);

            else            
                return GetNumericValue(logicalBlock.LeftValue) == GetNumericValue(logicalBlock.RightValue);            
        }

        private string EvaluateConditional(ConditionalBlock conditionalBlock)
        {
            if (EvaluateLogical((LogicalBlock) conditionalBlock.Value.Block))
                return EvaluateBlock(conditionalBlock.OnSuccess);
            else
                return EvaluateBlock(conditionalBlock.Default);
        }

        private string EvaluateBlock(AbstractBlock block)
        {
            string type = block.Type;

            switch (type)
            {
                case "controls_if":
                    return EvaluateConditional((ConditionalBlock) block);
                case "move_forward":
                    return "move_forward";                    
                case "move_backward":
                    return "move_backward";
                case "move_right":
                    return "move_right";
                case "move_left":
                    return "move_left";
                case "move_center":
                    return "move_center";
                case "move_closest_opponent":
                    return "move_closest_opponent";
                case "approach_ennemy":
                    return "approach_ennemy";
                case "flee_ennemy":
                    return "flee_ennemy";
                case "attack_closest_ennemy":
                    return "attack_closest_ennemy";
                case "attack_weakest_ennemy":
                    return "attack_weakest_ennemy";
                case "attack_strongest_ennemy":
                    return "attack_strongest_ennemy";
                default:
                    return "move_center";
            }            
        }

        

        public RoundAction Play()
        {
            var playerAction = EvaluateBlock(_aI.FirstBlock);

            var round = new RoundAction
            {
                PlayerId = _player.PlayerId,
                ActionType = ActionType.Move,
                Direction = Direction.Down,
                Target = new PlayerPosition(_player.Position.X, _player.Position.Y -= 1)
            };

            if (round.ActionType == ActionType.Move)
                Move(round.Target, round.Direction);
            else Attack(round.Target);

            return round;
        }

        public void Move(PlayerPosition newPosition, Direction direction)
        {
            if (newPosition.IsAvailable(direction) && _player.ActionPoints > 0)
            {
                _player.Position = newPosition;
                _player.ActionPoints -= 1;
            }
        }

        public void Attack(PlayerPosition targetPosition)
        {
            var target = GetTargetPlayer(targetPosition);
            if (target != null && _player.ActionPoints > 0)
            {
                target.Hitpoints -= 1;
                _player.ActionPoints -= 1;
            }
        }

        public PlayerInstance GetTargetPlayer(PlayerPosition position)
        {
            // if position has enemy
            return null;
        }
    }
}