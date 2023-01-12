using System;
using System.Collections;
using System.Collections.Generic;
namespace StackApp
{
    public class NodeStack<T> : IEnumerable<T>, IStack<T>
    {
        Node<T> head;
        int count;

        public bool IsEmpty
        {
            get {return count < 1;}
        }

        public int Count{
            get { return count; }
        }

        public void Push(T item){
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            count++;
        } 

        public T Pull(){
            if (IsEmpty) 
                throw new InvalidOperationException("stack is empty");
            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }

        public T Peek(){
            if (IsEmpty) throw new InvalidOperationException();
            return head.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
           while (current != null){
               yield return current.Data;
               current = current.Next;
           }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}