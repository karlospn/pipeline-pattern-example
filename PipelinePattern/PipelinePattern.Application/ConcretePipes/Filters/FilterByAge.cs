﻿using System.Collections.Generic;
using System.Linq;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Models.Persons;

namespace PipelinePattern.Application.ConcretePipes.Filters
{
    public class FilterByAge: IPipeline<IEnumerable<PersonsRequest>, IEnumerable<PersonsRequest>>
    {
        public IEnumerable<PersonsRequest> Process(IEnumerable<PersonsRequest> input)
        {
            return input.Where(x => x.Age > 18);

        }
    }
}