namespace PipelinePattern.Application.Base
{
    public static class PipelineExtensions
    {
        public static TOutput Pipe<TInput, TOutput>(this TInput input, IPipeline<TInput, TOutput> pipeline)
        {
            return pipeline.Process(input);
        }

    }
}
