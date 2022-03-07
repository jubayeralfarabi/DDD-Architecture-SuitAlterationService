// <copyright file="QueryResponse.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Queries
{
    using SuitSupply.Platform.Infrastructure.Core.Validation;

    /// <summary>Command response model.</summary>
    public class QueryResponse<TResult>
    {
        public QueryResponse()
        {
        }

        public QueryResponse(ValidationResponse validationResult, TResult result)
        {
            this.ValidationResult = validationResult;
            this.Result = result;
        }

        public ValidationResponse ValidationResult { get; set; }

        public TResult Result { get; set; }
    }
}
