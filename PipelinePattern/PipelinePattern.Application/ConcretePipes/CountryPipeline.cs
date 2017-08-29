using System;
using System.Collections.Generic;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Filters;
using PipelinePattern.Application.ConcretePipes.Models.Persons;

namespace PipelinePattern.Application.ConcretePipes
{
    public class CountryPipeline : Pipeline<IEnumerable<PersonsRequest>, IEnumerable<PersonsRequest>>
    {
        public CountryPipeline()
        {
            PipeFuncy = BuildPipe();
        }

        private Func<IEnumerable<PersonsRequest>, IEnumerable<PersonsRequest>> BuildPipe()
        {
            return input => input
                .Pipe(new FilterByCountry());
        }
    }
}
