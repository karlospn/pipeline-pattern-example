using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PipelinePattern.Application.ConcretePipes;
using PipelinePattern.Application.ConcretePipes.Models.Persons;

namespace PipelinePattern.UnitTest
{
    [TestClass]
    public class PersonsPipelineTest
    {
        [TestMethod]
        public void Given_a_pipeline_and_a_request_it_filters_successfully()
        {
            var request = new List<PersonsRequest>();
            request.Add( new PersonsRequest {Age =  10, Country = "Spain", FirstName = "John", LastName = "Hanson", Type = PersonType.TypeA});
            request.Add(new PersonsRequest { Age = 33, Country = "USA", FirstName = "Peter", LastName = "Morrison", Type = PersonType.TypeC });
            request.Add(new PersonsRequest { Age = 58, Country = "France", FirstName = "Arthur", LastName = "Mans", Type = PersonType.TypeA });
            request.Add(new PersonsRequest { Age = 17, Country = "Italy", FirstName = "Shawn", LastName = "Collins", Type = PersonType.TypeB });

            var pipe = new PersonsPipeline();
            var result = pipe.Process(request);

            Assert.AreEqual(result.Count(), 1);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Given_a_pipeline_and_a_request_with_invalid_types_throws_and_exception()
        {
            var request = new List<PersonsRequest>();
            request.Add(new PersonsRequest { Age = 22, Country = "Spain", FirstName = "John", LastName = "Hanson", Type = (PersonType) 5 });
            request.Add(new PersonsRequest { Age = 33, Country = "USA", FirstName = "Peter", LastName = "Morrison", Type = PersonType.TypeC });


            var pipe = new PersonsPipeline();
            var result = pipe.Process(request);

            Assert.AreEqual(result.Count(), 1);

        }
    }
}
