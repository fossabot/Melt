
namespace Melt.Common
{
    using System;

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    internal sealed class NoteMaybeAttribute : Attribute
    {
        public NoteMaybeAttribute(string note) => this.Note = note;

        public string Note { get; }
    }
}
