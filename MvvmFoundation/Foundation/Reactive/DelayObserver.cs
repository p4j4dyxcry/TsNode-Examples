﻿using System;
using System.Threading.Tasks;

namespace Ts.Core.Foundation.Reactive
{
    public class DelayObserver<T> : ObserverBase<T>
    {
        private readonly TimeSpan _timeSpan;
        
        public DelayObserver(IObservable<T> observable , TimeSpan timeSpan) : base(observable)
        {
            _timeSpan = timeSpan;
            InitializeSubscribe();
        }
        
        public override async void OnNext(T value)
        {
            await Task.Delay(_timeSpan);
            base.OnNext(value);
        }
    }
}