// <copyright file="IValidationService.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Validation
{
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Queries;

    /// <summary>Validation Service Interface.</summary>
    public interface IValidationService
    {
        /// <summary>Validates the asynchronous.</summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<ValidationResponse> ValidateAsync<TCommand>(TCommand command)
            where TCommand : ICommand;

        /// <summary>Validates the specified command.</summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command.</param>
        void Validate<TCommand>(TCommand command)
            where TCommand : ICommand;

        /// <summary>Validates the query.</summary>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        void ValidateQuery<TQuery>(TQuery query)
            where TQuery : class;

        /// <summary>Validates the query asynchronous.</summary>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>task.</returns>
        Task<ValidationResponse> ValidateQueryAsync<TQuery>(TQuery query)
            where TQuery : class;
    }
}
