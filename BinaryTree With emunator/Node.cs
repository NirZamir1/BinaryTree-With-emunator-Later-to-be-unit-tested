using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_With_emunator
{
    public class Node<T>  : IEnumerable<Node<T>> where T : IComparable 
    {
        T Value;
        public T GetValue { get => Value; }
        Node<T>? parent;
        Node<T> Left;
        Node<T> Right;
        public Node(T _value)
        {
            Value = _value;
            parent = null;
        }
        protected Node(T _value, Node<T>? _parent )
        {
            Value= _value;
            parent= _parent;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return new NodeEnumarator<T>(ToBottom());
        }
        public Node<T> NextInOrder()
        {
            if (Right != null)
                return Right.ToBottom();
            if (parent != null)
            {
                if (parent.Left!=null && parent.Left.Equals(this))
                {
                    return parent;
                }
                else
                {
                    return parent.BubbleUp();
                }
            }
            else

                return null;
        }
        public void Insert(T _value)
        {
            if(Value.CompareTo(_value) >= 0)
            {
                if (Left == null)
                    Left = new Node<T>(_value, this);
                else
                    Left.Insert(_value);

            }
            else
            {
                if(Right == null)
                    Right = new Node<T>(_value,this);
                else
                    Right.Insert(_value);
            }
        }
        public IEnumerable<Node<T>> Next()
        {
            if (Left != null)
                Left.Next();

            yield return this;

            if (Right != null)
                Right.Next();
        }

        public void print()
        {
            if(Left != null)
                Left.print();

            Console.WriteLine(Value);

            if(Right != null)
                Right.print();
        }
        private Node<T> ToBottom()
        {
            if (Left != null)
                return Left.ToBottom();
            else
                return this;
        }
        private Node<T> BubbleUp() //Used only when in right node to be used in NextInOrder function
        {
            if (parent != null)
            {
                if (parent.Left != null && parent.Left.Equals(this))
                    return parent;
                else
                    return parent.BubbleUp();
            }
            else
                return null;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        
    }
    
    internal class NodeEnumarator<T> : IEnumerator<Node<T>> where T : IComparable 
    {
       private Node<T> _Current;
        private int count =0;
        public NodeEnumarator(Node<T> Node)
        {
            _Current = Node;
        }
        public Node<T> Current => _Current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            //hello
        }
        public bool MoveNext()
        {
            if (count == 0)
            {
                count++;
                return true;
            }
            //throw new NotImplementedException();
            var cur = Current.NextInOrder();
            if (cur == null)
                return false;
            _Current = cur;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
