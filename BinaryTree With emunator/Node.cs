using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_With_emunator
{
    public class Node<T>  : IEnumerable<T> where T : IComparable 
    {
        T Value;
        Node<T> parent;
        Node<T> Left;
        Node<T> Right;
        public Node(T _value)
        {
            Value = _value;
            parent = this;
        }
        public Node(T _value, Node<T> _parent)
        {
            Value= _value;
            parent= _parent;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
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
        public void print()
        {
            if(Left != null)
                Left.print();

            Console.WriteLine(Value);

            if(Right != null)
                Right.print();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
