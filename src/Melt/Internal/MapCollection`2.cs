// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Internal
{

    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.ComponentModel;

    internal class MapCollection<TLeft, TRight> : IEnumerable<MapCollection<TLeft, TRight>.Relation>
    {
        private readonly Dictionary<TLeft, TRight> _map_lf;
        private readonly Dictionary<TRight, TLeft> _map_rt;

        // Compiler Magic
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(ValueTuple<TLeft, TRight> left_right)
        {
            if (!this.Link(left_right.Item1, left_right.Item2))
                throw new ArgumentException("Relation was existed.");
        }
        // Compiler Magic
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(ValueTuple<TRight, TLeft> left_right)
        {
            if (!this.Link(left_right.Item2, left_right.Item1))
                throw new ArgumentException("Relation was existed.");
        }

        // Compiler Magic
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(TLeft left, TRight right)
        {
            if (!this.Link(left, right))
                throw new ArgumentException("Relation was existed.");
        }
        // Compiler Magic
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(TRight right, TLeft left)
        {
            if (!this.Link(left, right))
                throw new ArgumentException("Relation was existed.");
        }

        public MapCollection()
        {
            _map_lf = new Dictionary<TLeft, TRight>();
            _map_rt = new Dictionary<TRight, TLeft>();
        }
        public bool Link(TLeft left, TRight right)
        {
            if (_map_lf.ContainsKey(left) || _map_rt.ContainsKey(right))
                return false;
            _map_lf.Add(left, right);
            _map_rt.Add(right, left);
            return true;
        }
        public bool Unlink(TLeft left)
        {
            if (_map_lf.TryGetValue(left, out var right))
            {
                return _map_rt.Remove(right);
            }
            return false;
        }
        public bool Unlink(TRight right)
        {
            if (_map_rt.TryGetValue(right, out var left))
            {
                return _map_lf.Remove(left);
            }
            return false;
        }
        public bool Relink(TLeft left, TRight right)
        {
            if (_map_lf.TryGetValue(left, out var r))
            {
                _map_lf[left] = right;
                _map_rt[right] = left;
                return _map_rt.Remove(r);
            }
            else if (_map_rt.TryGetValue(right, out var l))
            {
                _map_lf[left] = right;
                _map_rt[right] = left;
                return _map_lf.Remove(l);
            }
            return false;
        }
        public bool TryGet(TRight right, out Relation item)
        {
            if (_map_rt.TryGetValue(right, out var left))
            {
                item = new Relation(left, right);
                return true;
            }
            item = null;
            return false;
        }
        public bool TryGet(TLeft left, out Relation item)
        {
            if (_map_lf.TryGetValue(left, out var right))
            {
                item = new Relation(left, right);
                return true;
            }
            item = null;
            return false;
        }

        public delegate bool Filter(TLeft left, TRight right);

        public MapCollection<TLeft,TRight> Map(Filter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var l = new MapCollection<TLeft, TRight>();
            foreach (var r in this)
            {
                if (filter(r.Left, r.Right))
                    l.Link(r.Left, r.Right);
            }
            return l;
        }


        public int Reduce(MapCollection<TLeft,TRight> relations)
        {
            var count = 0;
            foreach (var r in relations)
            {
                if (this.Link(r.Left, r.Right))
                    count++;
            }
            return count;
        }

        public int Linked => _map_lf.Count;

        public void UnlinkAll()
        {
            _map_lf.Clear();
            _map_rt.Clear();
        }


        public sealed class Relation
        {
            internal Relation(TLeft left, TRight right)
            {
                Left = left;
                Right = right;
            }

            public TLeft Left { get; }
            public TRight Right { get; }

            public override string ToString() => $"[{Left}, {Right}]";

            public void Deconstruct(out TLeft left, out TRight right)
            {
                left = Left;
                right = Right;
            }

            public void Deconstruct(out TRight right, out TLeft left)
            {
                right = Right;
                left = Left;
            }
            public static implicit operator ValueTuple<TLeft, TRight>(Relation relation)
            {
                return (relation.Left, relation.Right);
            }
            public static implicit operator ValueTuple<TRight, TLeft>(Relation relation)
            {
                return (relation.Right, relation.Left);
            }
        }

        public IEnumerator<Relation> GetEnumerator()
        {
            foreach (var m in _map_lf)
            {
                yield return new Relation(m.Key, m.Value);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


