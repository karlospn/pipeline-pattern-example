using System;

namespace PipelinePattern.Application.Base
{
    public abstract class Pipeline<TInput, TOutput> : IPipeline<TInput, TOutput>
    {
        public Func<TInput, TOutput> PipeFuncy { get; protected set; }

        public TOutput Process(TInput input)
        {
            return PipeFuncy(input);
        }
    }
}
