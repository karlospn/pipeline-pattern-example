using System.Collections.Generic;
using System.Linq;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Models.Persons;

namespace PipelinePattern.Application.ConcretePipes.Filters
{
    public class FilterByAge: IPipeline<List<PersonsRequest>, List<PersonsRequest>>
    {
        public List<PersonsRequest> Process(List<PersonsRequest> input)
        {
            return input.Where(x => x.Age > 18) as List<PersonsRequest>;
        }
    }
}