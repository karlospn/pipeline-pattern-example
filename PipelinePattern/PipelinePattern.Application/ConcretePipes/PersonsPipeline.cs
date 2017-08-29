using System;
using System.Collections.Generic;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Filters;
using PipelinePattern.Application.ConcretePipes.Models.Persons;

namespace PipelinePattern.Application.ConcretePipes
{
    public class PersonsPipeline : Pipeline<List<PersonsRequest>, List<PersonsRequest>>
    {
        public PersonsPipeline()
        {
            PipeFuncy = BuildPipe();
        }

        private Func<List<PersonsRequest>, List<PersonsRequest>> BuildPipe()
        {
            return input => input
                .Pipe(new FilterByAge())
                .Pipe(new FilterByPersonType());
        }
    }
}
