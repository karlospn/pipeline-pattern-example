using System;
using System.Collections.Generic;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Filters;
using PipelinePattern.Application.ConcretePipes.Models.Persons;
using PipelinePattern.Application.ConcretePipes.Transforms;

namespace PipelinePattern.Application.ConcretePipes
{
    public class ConditionsPipeline : Pipeline<IEnumerable<PersonsRequest>, IEnumerable<PersonsResponse>>
    {
        public ConditionsPipeline()
        {
            PipeFuncy = BuildPipe();
        }

        private Func<IEnumerable<PersonsRequest>, IEnumerable<PersonsResponse>> BuildPipe()
        {
            return input => input
                .Pipe(new FilterByCountry())
                .Pipe(new SimpleConditionalPipeline<IEnumerable<PersonsRequest>, IEnumerable<PersonsRequest>>(req => true, new FilterByAge()))
                .Pipe(new CreatePersonsRequest());
        }
    }
}
