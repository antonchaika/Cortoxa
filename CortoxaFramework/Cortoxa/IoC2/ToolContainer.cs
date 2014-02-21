﻿#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ToolContainer.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

namespace Cortoxa.IoC2
{
    public abstract class ToolContainer : IToolContainer2
    {
        private IToolRegistrator toolRegistrator;

        private IToolResolver toolResolver;

        public abstract IToolRegistrator CreateRegistrator();

        public abstract IToolResolver CreateResolver();

        public IToolRegistrator Register
        {
            get
            {
                return toolRegistrator ?? (toolRegistrator = CreateRegistrator());
            }
        }

        public IToolResolver Resolve
        {
            get { return toolResolver ?? (toolResolver = CreateResolver()); }
        }

        public abstract T Container<T>();
    }
}