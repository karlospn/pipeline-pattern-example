using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Models.Persons;

namespace PipelinePattern.Application.ConcretePipes.Transforms
{
    public class CreatePersonsRequest : IPipeline<IEnumerable<PersonsRequest>, IEnumerable<PersonsResponse>>
    {
        public IEnumerable<PersonsResponse> Process(IEnumerable<PersonsRequest> input)
        {
            return input.Select(request => new PersonsResponse {FullName = request.FirstName + " " + request.LastName});
        }
    }
}
