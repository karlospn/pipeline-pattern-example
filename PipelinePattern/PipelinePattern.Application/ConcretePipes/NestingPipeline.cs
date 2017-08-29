using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelinePattern.Application.Base;
using PipelinePattern.Application.ConcretePipes.Filters;
using PipelinePattern.Application.ConcretePipes.Models.Persons;
using PipelinePattern.Application.ConcretePipes.Transforms;

namespace PipelinePattern.Application.ConcretePipes
{
    public class NestingPipeline : Pipeline<IEnumerable<PersonsRequest>, IEnumerable<PersonsResponse>>
    {
        public NestingPipeline()
        {
            PipeFuncy = BuildPipe();
        }

        private Func<IEnumerable<PersonsRequest>, IEnumerable<PersonsResponse>> BuildPipe()
        {
            return input => input
                .Pipe(new FilterByAge())
                .Pipe(new FilterByPersonType())
                .Pipe(new CountryPipeline())
                .Pipe(new CreatePersonsRequest());
        }
    }
}
