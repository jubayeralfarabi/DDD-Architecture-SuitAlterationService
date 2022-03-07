// <copyright file="ValidationResponse.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Validation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>Validation Result Class.</summary>
    public class ValidationResponse
    {
        public List<ValidationError> Errors { get; set; }

        public ValidationResponse()
        {
            this.Errors = new List<ValidationError>();
        }

        public ValidationResponse(List<ValidationError> errors)
        {
            this.Errors = errors;
        }

        /// <summary>Adds the error.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="resourceName">Name of the resource.</param>
        public void AddError(string errorMessage, string propertyName = "", string errorCode = "", string resourceName = "")
        {
            this.Errors.Add(new ValidationError { ErrorMessage = errorMessage, PropertyName = propertyName, ErrorCode = errorCode, ResourceName = resourceName });
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            var errorMessages = new StringBuilder();
            foreach (var error in this.Errors)
            {
                if (!string.IsNullOrEmpty(errorMessages.ToString()))
                {
                    errorMessages.Append(",\n");
                }

                errorMessages.Append(error.ErrorMessage);
            }

            return errorMessages.ToString();
        }

        public bool IsValid => !this.Errors.Any();
    }
}
