namespace PipelinePattern.Application.ConcretePipes.Models.Persons
{
    public class PersonsRequest
    {
        public string FirstName;
        public string LastName;
        public string Country;
        public int Age;
        public PersonType Type;
    }

    public enum PersonType
    {
        TypeA,
        TypeB,
        TypeC
    }
}
