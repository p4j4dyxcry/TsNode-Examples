﻿using System;
using System.Diagnostics;

namespace Ts.Core.Foundation.Reactive
{
    public class WhereObserver<T> : ObserverBase<T>
    {
        private readonly Func<T, bool> _predicate;

        public WhereObserver(IObservable<T> observable , Func<T,bool> predicate) : base(observable)
        {
            Debug.Assert(predicate != null);
            _predicate = predicate;
            InitializeSubscribe();
        }

        public override void OnNext(T value)
        {
            if(_predicate(value))
                base.OnNext(value);
        }
    }
}