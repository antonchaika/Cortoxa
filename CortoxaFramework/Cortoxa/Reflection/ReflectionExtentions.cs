﻿#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// 
// // /*
// //  * All rights reserved. This program and the accompanying materials
// //  * are made available under the terms of the GNU Lesser General Public License
// //  * (LGPL) version 2.1 which accompanies this distribution, and is available at
// //  * http://www.gnu.org/licenses/lgpl-2.1.html
// //  *
// //  *  Filename:	ReflectionExtentions.cs
// //  *  Date:		11/03/2014
// //  *  Author:   	Denis Korkhov
// //  *
// //  */
#endregion
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Cortoxa.Reflection
{
    public static class ReflectionExtentions
    {
        public static MethodInfo MethodFromExpression<T>(this Expression<Action<T>> methodExpr)
        {
            var call = methodExpr.Body as MethodCallExpression;
            if (call == null)
            {
                throw new InvalidOperationException("Expression must be a method call");
            }

            if (call.Object != methodExpr.Parameters[0])
            {
                throw new InvalidOperationException("Method call must target lambda argument");
            }
            return call.Method;
        }

        public static MemberExpression MemberInfo<T, P>(this Expression<Func<T, P>> method)
        {
            var lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");

            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    return ((UnaryExpression)lambda.Body).Operand as MemberExpression;
                case ExpressionType.MemberAccess:
                    return lambda.Body as MemberExpression;
                default:
                    throw new ArgumentException("method");
            }
        }
    }
}