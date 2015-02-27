using BaseballStats.CrossCutting.Query.Interfaces;
using BaseballStats.Data;
using BaseballStats.Data.Entity;
using BaseballStats.Data.Interfaces;
using BaseballStatsEmporium.Composers.Infrastructure;
using BaseballStatsEmporium.ModelParameters;
using BaseballStatsEmporium.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BaseballStatsEmporium.Composers
{
    public class PlayerInformationComposer : ICompose<List<PlayerInformation>>.Using<PlayerInformationParameters>
    {
        private IBaseballContext context;
        private IBuildFilterExpressions filterBuilder;

        public PlayerInformationComposer(IBaseballContext context, IBuildFilterExpressions filterBuilder)
        {
            this.context = context;
            this.filterBuilder = filterBuilder;
        }

        public List<PlayerInformation> Compose(PlayerInformationParameters parameters)
        {
            var queryable = (parameters.Filter == null || parameters.Filter.Count() == 0) ? context.Query<Player>() : context.Query<Player>().Where(filterBuilder.BuildLambda<Player>(parameters.Filter));
            var skip = parameters.Skip ?? 0;
            var take = parameters.Take ?? 100;

            return queryable.Select(p => new PlayerInformation
            {
                PlayerId = p.PlayerId,
                LahmanId = p.LahmanId,
                BirthYear = p.BirthYear,
                BirthMonth = p.BirthMonth,
                BirthDay = p.BirthDay,
                BirthCountry = p.BirthCountry,
                BirthState = p.BirthState,
                BirthCity = p.BirthCity,
                NameFirst = p.NameFirst,
                NameLast = p.NameLast,
                Nickname = p.Nickname,
                Weight = p.Weight,
                Height = p.Height,
                Bats = p.Bats,
                Throws = p.Throws,
                Debut = p.Debut,
                FinalGame = p.FinalGame,
                College = p.College
            }).Skip(skip).Take(take).ToList();
        }
    }
}