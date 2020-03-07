using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Circular_Linked_List
{
    class Node<T>
    {
        public T Value
        {
            get;
            private set;
        }

        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }

        public Node(T val)
        {
            this.Value = val;
        }
    }
    class CircularLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public CircularLinkedList()
        {
            Head = null;
            Tail = Head;
        }

        public int Count { get; private set; }
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void AddLast(T val)
        {
            Node<T> current = Head;
            if (Head == null)
            {
                Head = new Node<T>(val);
                Tail = Head;
            }
            else
            {
                Tail.Next = new Node<T>(val);
                Node<T> previousTail = Tail;
                Tail = Tail.Next;
                Tail.Prev = previousTail;
                //circular:
                Tail.Next = Head;
                Head.Prev = Tail;
               
            }
            Count++;
        }
        public void AddFirst(T val)
        {
            Node<T> current = Head;

            if (Head == null)
            {
                Head = new Node<T>(val);
                Tail = Head;
            }
            else
            {
                Head.Prev = new Node<T>(val);
                Head = Head.Prev;
                current = Head.Next;
                //circular:
                Tail.Next = Head;
                Head.Prev = Tail;
                
            }
            Count++;
        }
        public bool RemoveFirst()
        {
            if (Head == null)
            {
                return false;

            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
                //circular:
                Tail.Next = Head;
                Head.Prev = Tail;

                Count--;
                return true;
            }
        }
        public bool RemoveLast()
        {
            if (Head == null)
            {
                return false;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
                //circular:
                Tail.Next = Head;
                Head.Prev = Tail;

                Count--;
                return true;
            }
        }
        public bool Remove(T val)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(val))
                {
                    if (current == Head)
                    {
                        RemoveFirst();

                        return true;
                    }
                    else if (current == Tail)
                    {
                        RemoveLast();

                        return true;
                    }
                    else
                    {
                        current.Prev = current.Next;
                        current.Next = current.Prev;
                        Count++;
                        return true;
                    }
                }
            }
            return false;
        }
        public void PrintForwards()
        {
            Node<T> current = Head;
            do
            {
                Console.Write(current.Value + "-> ");
                current = current.Next;

            } while (current != Head);
            Console.WriteLine();
        }

        //QUESTION: How to tell a list is circular or not?
        //values can be unique
        //next can point to any node, including itself
        //assuming its circular
        static public bool isCircular(Node<T> StartingNode)
        {
            if (StartingNode == null)
            {
                return false;
            }

            Node<T> tortoise = StartingNode;
            Node<T> hare = StartingNode;
            while (hare != null || hare.Next != null)
            {
                tortoise = tortoise.Next;
                hare = hare.Next.Next;

                if (tortoise == hare)
                {
                    return true;
                }
            }
            return false;
        }

        public void Reverse()//iterative approach
        {
            Node<T> current = Head;
            Node<T> prev = null;
            Node<T> next = null;
            do
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current =next;

            } while (current != Head);
            Head.Next = prev;
            Head = prev;

            ////circular:
            //Tail.Next = Head;
            //Head.Prev = Tail;
        }
        
        public void Reverse2Ptrs()
        {
            Node<T> start = Head;
            Node<T> end = Tail;
            if(Count % 2 ==0)
            {
                start = end;
                end = start;
                start.Next = end;
            }
        }

    }

}
