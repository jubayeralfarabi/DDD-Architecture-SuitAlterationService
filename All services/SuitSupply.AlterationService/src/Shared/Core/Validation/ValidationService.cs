// <copyright file="ValidationService.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Core.Commands;

    /// <summary>Validation service to validate message.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Validation.IValidationService" />
    public class ValidationService : IValidationService
    {
        private readonly IValidationProvider validationProvider;

        public ValidationService(IValidationProvider validationProvider)
        {
            this.validationProvider = validationProvider;
        }

        /// <summary>Validates the command asynchronously.</summary>
        /// <typeparam name="TCommand">ICommand.</typeparam>
        /// <param name="command">The command.</param>
        /// <exception cref="System.ArgumentNullException">command.</exception>
        /// <exception cref="ValidationException">Validation Exception.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<ValidationResponse> ValidateAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var validationResponse = await this.validationProvider.ValidateAsync(command).ConfigureAwait(false);
            return validationResponse;
        }

        /// <summary>Validates the command.</summary>
        /// <typeparam name="TCommand">ICommand.</typeparam>
        /// <param name="command">The command.</param>
        /// <exception cref="System.ArgumentNullException">command.</exception>
        /// <exception cref="ValidationException">Validation Exception.</exception>
        public void Validate<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var validationResponse = this.validationProvider.Validate(command);

            if (!validationResponse.IsValid)
            {
                //throw new ValidationException(BuildErrorMessage(validationResponse.Errors));
            }
        }

        /// <summary>Builds the error message.</summary>
        /// <param name="errors">The errors.</param>
        /// <returns>string.</returns>
        private static string BuildErrorMessage(IEnumerable<ValidationError> errors)
        {
            var errorsText = errors.Select(x => $"\r\n - {x.ErrorMessage}").ToArray();
            return $"Validation failed: {string.Join(string.Empty, errorsText)}";
        }

        public void ValidateQuery<TQuery>(TQuery query)
            where TQuery : class
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var validationResponse = this.validationProvider.ValidateQuery(query);

            if (!validationResponse.IsValid)
            {
                //throw new ValidationException(BuildErrorMessage(validationResponse.Errors));
            }
        }

        /// <summary>Validates the query asynchronous.</summary>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <exception cref="ArgumentNullException">query.</exception>
        /// <exception cref="ValidationException">Validation Exception.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<ValidationResponse> ValidateQueryAsync<TQuery>(TQuery query)
            where TQuery : class
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var validationResponse = await this.validationProvider.ValidateQueryAsync(query).ConfigureAwait(false);

            return validationResponse;
        }
    }
}
