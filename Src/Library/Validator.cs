﻿using Microsoft.Extensions.DependencyInjection;

namespace FastEndpoints.Validation
{
    public abstract class Validator<TRequest> : AbstractValidator<TRequest> where TRequest : class
    {
#pragma warning disable CS8618
        internal IServiceProvider ServiceProvider { get; set; }
#pragma warning restore CS8618

        /// <summary>
        /// try to resolve an instance for the given type from the dependency injection container. will return null if unresolvable.
        /// </summary>
        /// <typeparam name="TService">the type of the service to resolve</typeparam>
        protected TService? Resolve<TService>() => ServiceProvider.GetService<TService>();
        /// <summary>
        /// try to resolve an instance for the given type from the dependency injection container. will return null if unresolvable.
        /// </summary>
        /// <param name="typeOfService">the type of the service to resolve</param>
        protected object? Resolve(Type typeOfService) => ServiceProvider.GetService(typeOfService);

        /// <summary>
        /// try to resolve an instance for the given type from the dependency injection container. will throw if unresolvable.
        /// </summary>
        /// <typeparam name="TService">the type of the service to resolve</typeparam>
        protected TService ResolveRequired<TService>() where TService : notnull => ServiceProvider.GetRequiredService<TService>();

        /// <summary>
        /// try to resolve an instance for the given type from the dependency injection container. will throw if unresolvable.
        /// </summary>
        /// <param name="typeOfService">the type of the service to resolve</param>
        protected object? ResolveRequired(Type typeOfService) => ServiceProvider.GetRequiredService(typeOfService);
    }
}
