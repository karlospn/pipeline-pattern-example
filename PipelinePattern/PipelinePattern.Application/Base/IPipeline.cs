namespace PipelinePattern.Application.Base
{
    public interface IPipeline<in TInput, out TOutput>
    {
        TOutput Process(TInput input);
    }
}
