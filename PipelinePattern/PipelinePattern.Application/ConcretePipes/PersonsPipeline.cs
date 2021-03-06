﻿using System;
using System.Collections.Generic;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Filters;
using PipelinePattern.Application.ConcretePipes.Models.Persons;
using PipelinePattern.Application.ConcretePipes.Transforms;

namespace PipelinePattern.Application.ConcretePipes
{
    public class PersonsPipeline : Pipeline<IEnumerable<PersonsRequest>, IEnumerable<PersonsResponse>>
    {
        public PersonsPipeline()
        {
            PipeFuncy = BuildPipe();
        }

        private Func<IEnumerable<PersonsRequest>, IEnumerable<PersonsResponse>> BuildPipe()
        {
            return input => input
                .Pipe(new FilterByAge())
                .Pipe(new FilterByPersonType())
                .Pipe(new CreatePersonsRequest());
        }
    }
}
