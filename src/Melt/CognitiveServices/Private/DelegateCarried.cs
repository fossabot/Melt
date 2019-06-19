
namespace Melt.CognitiveServices
{
    using System;

    partial class Cognitive<TSelf> where TSelf : Cognitive<TSelf>, new()
    {
        private sealed class DelegateCarried
        {
            internal DelegateCarried(Func<object, object> getValue, Action<object, object> setValue, Type type)
            {
                this.GetValue = getValue;
                this.SetValue = setValue;
                this.Type = type;
            }

            internal Func<object, object> GetValue { get; }
            internal Action<object, object> SetValue { get; }
            internal Type Type { get; }
        }
    }
}
