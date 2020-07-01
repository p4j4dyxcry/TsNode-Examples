using System;

namespace Ts.Core.Foundation.Reactive
{
    public class MergeObserver<T> : MultiObserverBase<T>
    {
        public MergeObserver(IObservable<T> observable, params IObservable<T>[] subPrams) : base(observable, subPrams)
        {
            InitializeSubscribe();
        }
    }
}