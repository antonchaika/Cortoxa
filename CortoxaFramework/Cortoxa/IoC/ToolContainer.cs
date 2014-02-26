﻿#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	BaseToolContainer.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using Cortoxa.IoC.Base;

namespace Cortoxa.IoC
{
    public class ToolContainer : IToolContainer
    {
        private readonly IToolRegistrator registrator;

        private readonly IToolResolver resolver;

        public ToolContainer(IToolRegistrator registrator, IToolResolver resolver)
        {
            this.registrator = registrator;
            this.resolver = resolver;
        }

        public IToolRegistrator Register
        {
            get { return registrator; }
        }

        public IToolResolver Resolve
        {
            get { return resolver; }
        }
    }
}