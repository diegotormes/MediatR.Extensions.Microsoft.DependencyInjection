﻿using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace MediatR.Extensions.Microsoft.DependencyInjection.Tests
{
    public class LifetimeHandlersRegistrationTests
    {
        private readonly ServiceCollection _services;

        public LifetimeHandlersRegistrationTests()
        {
            _services = new ServiceCollection();
            _services.AddMediatR(typeof(Ping));
        }

        [Fact]
        public void SingletonHandlerRegistrationShouldBeSingleton()
        {
            _services.First(s => s.ImplementationType == typeof(SingletonHandler)).Lifetime.ShouldBe(ServiceLifetime.Singleton);
        }

        [Fact]
        public void SingletonHandlerRegistrationShouldBeScoped()
        {
            _services.First(s => s.ImplementationType == typeof(ScopedHandler)).Lifetime.ShouldBe(ServiceLifetime.Scoped);
        }

        [Fact]
        public void SingletonHandlerRegistrationShouldBeTransient()
        {
            _services.First(s => s.ImplementationType == typeof(TransientHandler)).Lifetime.ShouldBe(ServiceLifetime.Transient);
        }
    }
}
