﻿using System.Collections.Generic;
using SolrExpress.Core.Query;

namespace SolrExpress.Solr4.Parameter
{
    public sealed class StartParameter : IParameter<List<string>>
    {
        private readonly int _value;

        /// <summary>
        /// Create a limit parameter
        /// </summary>
        /// <param name="value">Parameter to include in the query</param>
        public StartParameter(int value)
        {
            this._value = value;
        }

        /// <summary>
        /// True to indicate multiples instance of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get { return false; } }

        /// <summary>
        /// Execute the creation of the parameter "start"
        /// </summary>
        /// <param name="container">Container to parameters to request to SOLR</param>
        public void Execute(List<string> container)
        {
            container.Add(string.Concat("start=", this._value));
        }
    }
}