﻿using CoffeeCat.RiotCommon.Dto.Match;
using CoffeeCat.RiotCommon.Utils;
using System;
using System.Threading.Tasks;

namespace CoffeeCat.RiotClient.Clients
{
    public class MatchListClient : BaseClient
    {
        public string Version { get; private set; }

        public MatchListClient(string region, string version, string apiKey) : base(region, apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(version, nameof(version));
            this.Version = version;
        }

        public Task<MatchListDto> GetMatchList(string summonerId)
        {
            Validation.ValidateNotNullOrWhitespace(summonerId, nameof(summonerId));

            var uri = this.EndpointFactory.GetMatchListUri(this.Version, summonerId);
            return this.DownloadRiotData<MatchListDto>(uri);
        }

        public Task<MatchListDto> GetMatchList(
            string summonerId, 
            DateTime beginTime, 
            DateTime endTime)
        {
            Validation.ValidateNotNullOrWhitespace(summonerId, nameof(summonerId));

            var uri = this.EndpointFactory.GetMatchListUri(this.Version, summonerId, beginTime, endTime);
            return this.DownloadRiotData<MatchListDto>(uri);
        }
    }
}
