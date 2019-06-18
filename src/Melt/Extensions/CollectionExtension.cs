using System;
using System.Collections.Generic;
using System.Text;

namespace Melt.Extensions
{
    public static class CollectionExtension
    {
        public static  IEnumerable<T> PopMany<T>(this Stack<T> stack, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (stack.TryPop(out var k))
                {
                    yield return k;
                }
                else
                    yield break;

            }
        }

    }
}
