﻿using Newtonsoft.Json.Linq;
using SolrExpress.Core;
using SolrExpress.Core.Search;
using SolrExpress.Core.Search.Parameter;
using SolrExpress.Core.Utility;
using System.Collections.Generic;
using System.Linq;

namespace SolrExpress.Solr5.Search.Parameter
{
    public sealed class FacetFieldParameter<TDocument> : BaseFacetFieldParameter<TDocument>, ISearchParameterExecute<JObject>
        where TDocument : IDocument
    {
        public FacetFieldParameter(IExpressionBuilder<TDocument> expressionBuilder) : base(expressionBuilder)
        {
        }

        /// <summary>
        /// Execute the creation of the parameter "facet.field"
        /// </summary>
        /// <param name="jObject">JSON object with parameters to request to SOLR</param>
        public void Execute(JObject jObject)
        {
            var facetObject = (JObject)jObject["facet"] ?? new JObject();

            var fieldName = this._expressionBuilder.GetFieldNameFromExpression(this.Expression);
            var aliasName = this._expressionBuilder.GetPropertyNameFromExpression(this.Expression);

            var array = new List<JProperty>
            {
                new JProperty("field", fieldName)
            };

            array.Add(new JProperty("mincount", 1));

            if (this.Excludes?.Any() ?? false)
            {
                var excludeValue = new JObject(new JProperty("excludeTags", new JArray(this.Excludes)));
                array.Add(new JProperty("domain", excludeValue));
            }

            if (this.SortType.HasValue)
            {
                string typeName;
                string sortName;

                ExpressionUtility.GetSolrFacetSort(this.SortType.Value, out typeName, out sortName);

                array.Add(new JProperty("sort", new JObject(new JProperty(typeName, sortName))));
            }

            if (this.Limit.HasValue)
            {
                array.Add(new JProperty("limit", this.Limit));
            }

            var value = new JProperty(aliasName, new JObject(new JProperty("terms", new JObject(array.ToArray()))));

            facetObject.Add(value);

            jObject["facet"] = facetObject;
        }
    }
}
