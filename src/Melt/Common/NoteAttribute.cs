
namespace Melt.Common
{
    using System;

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    internal sealed class NoteAttribute : Attribute
    {
        public NoteAttribute(string note) => this.Note = note;

        public string Note { get; }
    }
}
