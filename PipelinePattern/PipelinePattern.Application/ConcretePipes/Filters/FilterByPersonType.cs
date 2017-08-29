using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Models.Persons;

namespace PipelinePattern.Application.ConcretePipes.Filters
{
    public class FilterByPersonType : IPipeline<IEnumerable<PersonsRequest>, IEnumerable<PersonsRequest>>
    {
        public IEnumerable<PersonsRequest> Process(IEnumerable<PersonsRequest> input)
        {
            return input.Any(x => !Enum.IsDefined(typeof(PersonType), x.Type))
                ? throw new Exception("Type not valid")
                : input.Where(x => x.Type != PersonType.TypeA);
        }
    }
}
