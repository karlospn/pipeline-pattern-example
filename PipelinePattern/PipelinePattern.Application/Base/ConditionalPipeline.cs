using System;

namespace PipelinePattern.Application.Base
{
    public class SimpleConditionalPipeline<TInput, TOutput> : IPipeline<TInput, TOutput> where TInput : TOutput
    {
        private readonly Func<TInput, bool> _conditional;
        private readonly IPipeline<TInput, TOutput> _pipe;

        public SimpleConditionalPipeline(Func<TInput, bool> conditional, IPipeline<TInput, TOutput> pipe)
        {
            _conditional = conditional;
            _pipe = pipe;
        }
        public TOutput Process(TInput input)
        {
            if (_conditional(input))
            {
                _pipe.Process(input);
            }
            return input;
        }
    }

    public class ConditionalPipeline<TInput, TOutput> : IPipeline<TInput, TOutput> where TInput : TOutput
    {
        private readonly Func<TInput, bool> _conditional;
        private readonly IPipeline<TInput, TOutput> _pipe1;
        private readonly IPipeline<TInput, TOutput> _pipe2;

        public ConditionalPipeline(Func<TInput, bool> conditional, IPipeline<TInput, TOutput> pipe1, IPipeline<TInput, TOutput> pipe2 )
        {
            _conditional = conditional;
            _pipe1 = pipe1;
            _pipe2 = pipe2;
        }
        public TOutput Process(TInput input)
        {
            if (_conditional(input))
            {
                _pipe1.Process(input);
            }
            return _pipe2.Process(input);
        }
    }
}
