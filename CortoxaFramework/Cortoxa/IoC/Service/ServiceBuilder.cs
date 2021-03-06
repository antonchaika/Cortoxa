﻿#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ServiceBuilder.cs
//  *  Date:		24/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using System;
using System.Linq;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Base.ServiceFamily;
using Cortoxa.IoC.Common;
using Cortoxa.IoC.Interception;
using IServiceBuilder = Cortoxa.IoC.Base.ServiceFamily.IServiceBuilder;

namespace Cortoxa.IoC.Service
{
    public class ServiceBuilder : IServiceBuilder 
    {
        private readonly ServiceConfiguration context = new ServiceConfiguration();
        private readonly IServiceInterception interceptor;

        public ServiceBuilder()
        {
            interceptor = new ServiceInterception(this);
        }

        public virtual ServiceConfiguration Context
        {
            get { return context; }
        }

        public IServiceDependency Depend { get; private set; }

        public virtual IServiceBuilderCommon To<T>()
        {
            return To(typeof (T));
        }

        public virtual IServiceBuilderCommon To(Type type)
        {
            context.To = type;
            return this;
        }

        public virtual IServiceBuilderCommon ToSelf()
        {
            return To(context.For.First());
        }

        public virtual IServiceBuilder Name(string name)
        {
            context.Name = name;
            return this;
        }

        public IServiceBuilder LifeTime(LifeTime lifeTime)
        {
            context.Lifetime = lifeTime;
            return this;
        }

        public IServiceBuilder InterceptMethod(MethodInteception methodInteceptor)
        {
            context.Interceptors.Add(methodInteceptor);
            return this;
        }

        public IServiceBuilder DependOn(string name)
        {
            throw new NotImplementedException();
        }

        public IServiceBuilder DependOn(Type type, string dependencyName)
        {
            context.Dependencies.Add(type, dependencyName);
            return this;
        }

        public IServiceInterception Intercept
        {
            get { return interceptor; }
        }

        public IServiceBuilderTo For(Type[] serviceTypes)
        {
            Context.For = serviceTypes;
            return this;
        }

        public IServiceBuilderTo For(Type serviceType)
        {
            return For(new[] { serviceType });
        }

        public IServiceBuilderTo For<T>()
        {
            return For(new[] { typeof(T) });
        }

        public IServiceBuilderTo For<T, T2>()
        {
            return For(new[] { typeof(T), typeof(T2) });
        }

        public IServiceBuilderTo For<T, T2, T3>()
        {
            return For(new[] { typeof(T), typeof(T2), typeof(T3) });
        }

        public IServiceBuilderTo For<T, T2, T3, T4>()
        {
            return For(new[] { typeof(T), typeof(T2), typeof(T3), typeof(T4) });
        }

        public void Register(IToolContainer registrator)
        {
//            registrator.Register(context);
        }
    }
}