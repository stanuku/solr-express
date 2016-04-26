﻿using SolrExpress.Core;
using SolrExpress.Core.Query.Parameter;
using System.Collections.Generic;

namespace SolrExpress.Solr4.Parameter
{
    public sealed class QueryFieldParameter : IQueryFieldParameter, IParameter<List<string>>
    {
        private string _expression;

        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get; } = false;

        /// <summary>
        /// Execute the creation of the parameter "query field"
        /// </summary>
        /// <param name="container">Container to parameters to request to SOLR</param>
        public void Execute(List<string> container)
        {
            container.Add($"qf={this._expression}");
        }

        /// <summary>
        /// Configure current instance
        /// </summary>
        /// <param name="expression">Query used to make the query field</param>
        public IQueryFieldParameter Configure(string expression)
        {
            Checker.IsNullOrWhiteSpace(expression);

            this._expression = expression;

            return this;
        }
    }
}
