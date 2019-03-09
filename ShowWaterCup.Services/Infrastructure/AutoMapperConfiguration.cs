using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ShowWaterCup.Services.Infrastructure
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Entities.Tournament, Models.Tournament.TournamentInstance>();
                cfg.CreateMap<Models.Tournament.TournamentInstance, Entities.Tournament>();

                cfg.CreateMap<Entities.Round, Models.Tournament.Round>();
                cfg.CreateMap<Models.Tournament.Round, Entities.Round>();

                cfg.CreateMap<Entities.RoundAction, Models.Tournament.RoundAction>();
                cfg.CreateMap<Models.Tournament.RoundAction, Entities.RoundAction>();

                cfg.CreateMap<Entities.Player, Models.Player.PlayerInstance>();
                cfg.CreateMap<Models.Player.PlayerInstance, Entities.Player>();

                cfg.CreateMap<Entities.PlayerAI, Models.Player.PlayerAI>();
                cfg.CreateMap<Models.Player.PlayerAI, Entities.PlayerAI>();

                cfg.CreateMap<Entities.PlayerAIStep, Models.Player.PlayerAIStep>();
                cfg.CreateMap<Models.Player.PlayerAIStep, Entities.PlayerAIStep>();

                cfg.CreateMap<Entities.Position, Models.Player.PlayerPosition>();
                cfg.CreateMap<Models.Player.PlayerPosition, Entities.Position>();

            });
        }
    }
}
