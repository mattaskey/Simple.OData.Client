﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Simple.OData.Client
{
    public interface IClientWithCommand : IClient, ICommand
    {
        string CommandText { get; }

        // see http://stackoverflow.com/questions/10531575/passing-a-dynamic-parameter-throws-runtimebinderexception-when-calling-method-fr
        new IClientWithCommand As(string derivedCollectionName);
        new IClientWithCommand As(ODataExpression expression);
        new IClientWithCommand Key(params object[] entryKey);
        new IClientWithCommand Key(IEnumerable<object> entryKey);
        new IClientWithCommand Key(IDictionary<string, object> entryKey);
        new IClientWithCommand Filter(string filter);
        new IClientWithCommand Filter(ODataExpression expression);
        new IClientWithCommand Expand(IEnumerable<string> associations);
        new IClientWithCommand Expand(params string[] associations);
        new IClientWithCommand Expand(params ODataExpression[] associations);
        new IClientWithCommand Select(IEnumerable<string> columns);
        new IClientWithCommand Select(params string[] columns);
        new IClientWithCommand Select(params ODataExpression[] columns);
        new IClientWithCommand OrderBy(IEnumerable<KeyValuePair<string, bool>> columns);
        new IClientWithCommand OrderBy(params string[] columns);
        new IClientWithCommand OrderBy(params ODataExpression[] columns);
        new IClientWithCommand OrderByDescending(params string[] columns);
        new IClientWithCommand OrderByDescending(params ODataExpression[] columns);
        new IClientWithCommand NavigateTo(string linkName);
        new IClientWithCommand NavigateTo(ODataExpression expression);
        new IClientWithCommand Set(object value);
        new IClientWithCommand Set(IDictionary<string, object> value);
    }

    public interface IClientWithCommand<T> : IClientWithCommand, ICommand<T>
    {
        // see http://stackoverflow.com/questions/10531575/passing-a-dynamic-parameter-throws-runtimebinderexception-when-calling-method-fr
        new IClientWithCommand<U> As<U>(string derivedCollectionName = null);
        new IClientWithCommand<T> Filter(Expression<Func<T, bool>> expression);
        new IClientWithCommand<T> Expand(Expression<Func<T, object>> expression);
        new IClientWithCommand<T> Select(Expression<Func<T, object>> expression);
        new IClientWithCommand<T> OrderBy(Expression<Func<T, object>> expression);
        new IClientWithCommand<T> OrderByDescending(Expression<Func<T, object>> expression);
        new IClientWithCommand<U> NavigateTo<U>(string linkName = null);
    }
}
