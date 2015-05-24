﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SolrExpress.Enumerator;
using SolrExpress.Solr5.Parameter;

namespace SolrExpress.Tests.Solr5.Parameter
{
    [TestClass]
    public class FacetRangeParameterTests
    {
        [TestMethod]
        public void WhenExecuteWithDefaultArguments_CreateJson()
        {
            // Arrange
            var expected = JObject.Parse(@"
            {
              ""facet"": {
                ""X"": {
                  ""range"": {
                    ""field"": ""Id"",
                    ""gap"": ""1"",
                    ""start"": ""10"",
                    ""end"": ""20"",
                    ""other"": [
                      ""before"",
                      ""after""
                    ]
                  }
                }
              }
            }");
            string actual;
            var jObject = new JObject();
            var parameter = new FacetRangeParameter<TestDocument>(q => q.Id, "X", "1", "10", "20");

            // Act
            parameter.Execute(jObject);
            actual = jObject.ToString();

            // Assert
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void WhenExecuteWithSortTypeAndDirection_CreateJson()
        {
            // Arrange
            var expected = JObject.Parse(@"
            {
              ""facet"": {
                ""X"": {
                  ""range"": {
                    ""field"": ""Id"",
                    ""gap"": ""1"",
                    ""start"": ""10"",
                    ""end"": ""20"",
                    ""other"": [
                      ""before"",
                      ""after""
                    ],
                    ""sort"": {
                      ""count"": ""desc""
                    }
                  }
                }
              }
            }");
            string actual;
            var jObject = new JObject();
            var parameter = new FacetRangeParameter<TestDocument>(q => q.Id, "X", "1", "10", "20", SolrFacetSortType.Quantity, false);

            // Act
            parameter.Execute(jObject);
            actual = jObject.ToString();

            // Assert
            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
