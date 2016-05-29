﻿using Xunit;
using SolrExpress.Solr4.Query.Parameter;
using System.Collections.Generic;

namespace SolrExpress.Solr4.UnitTests.Query.Parameter
{
    public class RowsParameterTests
    {
        /// <summary>
        /// Where   Using a RowsParameter instance
        /// When    Invoking the method "Execute"
        /// What    Create a valid string
        /// </summary>
        [Fact]
        public void RowsParameter001()
        {
            // Arrange
            var container = new List<string>();
            var parameter = new RowsParameter();
            parameter.Configure(10);

            // Act
            parameter.Execute(container);

            // Assert
            Assert.Equal(1, container.Count);
            Assert.Equal("rows=10", container[0]);
        }
    }
}
