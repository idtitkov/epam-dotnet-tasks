using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._13
{
    /// <summary>
    /// Custom Queue class.
    /// </summary>
    /// <typeparam name="T">Generic value.</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public Queue()
        {
        }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="node">T value</param>
        public Queue(T node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            Enqueue(node);
        }

        /// <summary>
        /// Queue length.
        /// </summary>
        public int Count
        {
            get; private set;
        }

        /// <summary>
        /// Returning true if Queue is empty, otherwise false.
        /// </summary>
        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        /// <summary>
        /// Adds T to a Queue.
        /// </summary>
        /// <param name="data">T value.</param>
        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;

            if (Count == 0)
            {
                head = tail;
            }
            else
            {
                tempNode.Next = tail;
            }

            Count++;
        }

        /// <summary>
        /// Removes first value from a Queue.
        /// </summary>
        /// <returns>T value.</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T output = head.Data;
            head = head.Next;
            Count--;
            return output;
        }

        /// <summary>
        /// Shows first element without removing.
        /// </summary>
        /// <returns>T value.</returns>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return head.Data;
        }

        /// <summary>
        /// Checks if provided element exists in Queue.
        /// </summary>
        /// <param name="data">T value.</param>
        /// <returns>True, if elemenn exists in Queue, otherwise false.</returns>
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Deletes all elements from Queue.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        #region Node
        private class Node<U>
        {
            public Node(U data)
            {
                Data = data;
            }

            public U Data { get; set; }

            public Node<U> Next { get; set; }
        }
        #endregion

        #region QueueEnumerator
        private sealed class QueueEnumerator : IEnumerator<T>
        {
            private readonly Queue<T> queue;

            private int curIndex;
            private Node<T> curNode;

            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue;
                curIndex = -1;
                curNode = queue.head;
            }

            public T Current
            {
                get
                {
                    return curNode.Data;
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (++curIndex >= queue.Count)
                {
                    return false;
                }
                else
                {
                    // Returning curNode to a header.
                    curNode = queue.head;

                    // Getting [curIndex] Node from a Queue.
                    for (int i = 0; i < curIndex; i++)
                    {
                        curNode = curNode.Next;
                    }
                }

                return true;
            }

            public void Reset()
            {
                curIndex = -1;
            }

            public void Dispose()
            {
            }
        }
        #endregion
    }
}
