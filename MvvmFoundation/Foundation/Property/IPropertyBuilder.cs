using System;
using System.Collections.Generic;
using TsOperationHistory;

namespace Ts.Core.Foundation.Property
{
    public interface IPropertyBuilder
    {
        IPropertyBuilder Register<T>(string propertyName);
        IPropertyBuilder Register<T>(Func<T> getter,Action<T> setter);
        IPropertyBuilder RegisterReadOnly<T>(Func<T> getter);
        IPropertyBuilder OperationController(IOperationController controller);
        IEnumerable<IProperty> Build();
    }
}
