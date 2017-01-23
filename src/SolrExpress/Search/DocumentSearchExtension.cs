﻿using SolrExpress.Search.Parameter;
using SolrExpress.Utility;
using System;
using System.Linq.Expressions;

namespace SolrExpress.Search
{
    public static class DocumentSearchExtension
    {
        /// <summary>
        /// Create a not mapped parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="name">Name of parameter</param>
        /// <param name="value">Value of parameter</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Any<TDocument>(this DocumentSearch<TDocument> documentSearch, string name, string value)
            where TDocument : IDocument
        {
            Checker.IsNullOrWhiteSpace(name);
            Checker.IsNullOrWhiteSpace(value);

            // TODO: Get from DI Engine
            IAnyParameter<TDocument> parameter = null;
            parameter.Name = name;
            parameter.Value = value;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a boost parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="query">Query used to make boost</param>
        /// <param name="boostFunction">Boost type used in calculation</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Boost<TDocument>(this DocumentSearch<TDocument> documentSearch, ISearchQuery<TDocument> query, BoostFunctionType boostFunction)
            where TDocument : IDocument
        {
            Checker.IsNull(query);
            Checker.IsNull(boostFunction);

            // TODO: Get from DI Engine
            IBoostParameter<TDocument> parameter = null;
            parameter.BoostFunctionType = boostFunction;
            parameter.Query = query;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a facet field parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find property name</param>
        /// <param name="facet">Instance of facet ready to configure</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> FacetField<TDocument>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, Action<IFacetFieldParameter<TDocument>> facet = null)
            where TDocument : IDocument
        {
            Checker.IsNull(fieldExpression);

            // TODO: Get from DI Engine
            IFacetFieldParameter<TDocument> parameter = null;
            parameter.FieldExpression = fieldExpression;

            facet?.Invoke(parameter);

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a facet limit parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="value">Value of limit</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> FacetLimit<TDocument>(this DocumentSearch<TDocument> documentSearch, int value)
            where TDocument : IDocument
        {
            // TODO: Get from DI Engine
            IFacetLimitParameter<TDocument> parameter = null;
            parameter.Value = value;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a facet query parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="aliasName">Name of alias added in query</param>
        /// <param name="query">Query used to make facet</param>
        /// <param name="facet">Instance of facet ready to configure</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> FacetQuery<TDocument>(this DocumentSearch<TDocument> documentSearch, string aliasName, ISearchQuery<TDocument> query, Action<IFacetQueryParameter<TDocument>> facet = null)
            where TDocument : IDocument
        {
            // TODO: Get from DI Engine
            IFacetQueryParameter<TDocument> parameter = null;
            parameter.AliasName = aliasName;
            parameter.Query = query;

            facet?.Invoke(parameter);

            documentSearch.Add(parameter);

            return documentSearch;
        }


        ////////////public static DocumentSearch<TDocument> FacetRange<TDocument>(this DocumentSearch<TDocument> documentSearch,
        ////////////where TDocument : IDocument
        ////////////public static DocumentSearch<TDocument> FacetSpatial<TDocument>(this DocumentSearch<TDocument> documentSearch,
        ////////////where TDocument : IDocument
        ////////////public static DocumentSearch<TDocument> Fields<TDocument>(this DocumentSearch<TDocument> documentSearch,
        ////////////where TDocument : IDocument
        ////////////public static DocumentSearch<TDocument> Filter<TDocument>(this DocumentSearch<TDocument> documentSearch, (field, params of T) //common case, equal ID or ID in
        ////////////where TDocument : IDocument
        ////////////public static DocumentSearch<TDocument> Filter<TDocument>(this DocumentSearch<TDocument> documentSearch, (field, instancia)
        ////////////where TDocument : IDocument


        /// <summary>
        /// Create a limit parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="value">Value of limit</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Limit<TDocument>(this DocumentSearch<TDocument> documentSearch, long value)
            where TDocument : IDocument
        {
            // TODO: Get from DI Engine
            ILimitParameter<TDocument> parameter = null;
            parameter.Value = value;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a minimum should match
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="expression">Expression used to make mm parameter</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> MinimumShouldMatch<TDocument>(this DocumentSearch<TDocument> documentSearch, string expression)
            where TDocument : IDocument
        {
            // TODO: Get from DI Engine
            IMinimumShouldMatchParameter<TDocument> parameter = null;
            parameter.Expression = expression;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a offset parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="value">Value of offset</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Offset<TDocument>(this DocumentSearch<TDocument> documentSearch, long value)
            where TDocument : IDocument
        {
            // TODO: Get from DI Engine
            IOffsetParameter<TDocument> parameter = null;
            parameter.Value = value;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a limit and a offset parameters
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="itemsPerPage">Quantity of items in one page</param>
        /// <param name="currentPage">Current page</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Page<TDocument>(this DocumentSearch<TDocument> documentSearch, long itemsPerPage, long currentPage)
            where TDocument : IDocument
        {
            documentSearch.Limit(itemsPerPage);
            documentSearch.Offset((currentPage - 1) * itemsPerPage);

            return documentSearch;
        }

        /// <summary>
        /// Create a query field parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="expression">Query used to make query field</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> QueryField<TDocument>(this DocumentSearch<TDocument> documentSearch, string expression)
            where TDocument : IDocument
        {
            // TODO: Get from DI Engine
            IQueryFieldParameter<TDocument> parameter = null;
            parameter.Expression = expression;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        ////////public static DocumentSearch<TDocument> Query<TDocument>(this DocumentSearch<TDocument> documentSearch, (field, params of T) //common case, equal ID or ID in
        ////////where TDocument : IDocument
        ////////public static DocumentSearch<TDocument> Query<TDocument>(this DocumentSearch<TDocument> documentSearch, (field, instancia)
        ////////where TDocument : IDocument
        
        /// <summary>
        /// Create a sort parameter
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <param name="fieldExpression">Expression used to find property name</param>
        /// <param name="ascendent">True to ascendent order, otherwise false</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> Sort<TDocument>(this DocumentSearch<TDocument> documentSearch, Expression<Func<TDocument, object>> fieldExpression, bool ascendent)
            where TDocument : IDocument
        {
            // TODO: Get from DI Engine
            ISortParameter<TDocument> parameter = null;
            parameter.FieldExpression = fieldExpression;
            parameter.Ascendent = ascendent;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        /// <summary>
        /// Create a sort parameter configured to do a random sort
        /// </summary>
        /// <param name="documentSearch">Document search engine</param>
        /// <returns>Document search engine</returns>
        public static DocumentSearch<TDocument> SortRandomly<TDocument>(this DocumentSearch<TDocument> documentSearch)
            where TDocument : IDocument
        {
            // TODO: Get from DI Engine
            ISortRandomlyParameter<TDocument> parameter = null;

            documentSearch.Add(parameter);

            return documentSearch;
        }

        //////////public static DocumentSearch<TDocument> SpatialFilter<TDocument>(this DocumentSearch<TDocument> documentSearch,
        //////////where TDocument : IDocument
    }
}