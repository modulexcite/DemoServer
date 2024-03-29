﻿using System.Linq;
using DemoMethods.Entities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace DemoMethods.Indexes
{
    public class LastFmAnalyzed : AbstractIndexCreationTask<LastFm, LastFmAnalyzed.Result>
    {
        public class Result
        {
            public string Query;
        }

        public LastFmAnalyzed()
        {
            Map = songs => from song in songs
                select new
                {
                    Query = new object[]
                    {
                        song.Artist, 
                        song.TimeStamp, 
                        song.Tags, 
                        song.Title, 
                        song.TrackId
                    }
                };

            Index(x => x.Query, FieldIndexing.Analyzed);
        }
    }
}