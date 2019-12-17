using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._13
{
    public abstract class Matrix<T> where T : struct, IComparable<T>
    {
        public delegate void EventHandler(object sender, ElementEventArgs e);

        public event EventHandler ElementChanged;

        protected T[][] Numbers { get => Numbers; set => Numbers = value; }

        public T this[int i, int j] => Numbers[i][j];

        public abstract void SetElement(int i, int j, T element);

        public int Size() => Numbers.Length;

        public abstract bool IsInputCorrectly(T[][] inputs);

        protected void OnElementChanged(int i, int j)
        {
            ElementChanged?.Invoke(this, new ElementEventArgs(i, j));
        }
    }

    public class ElementEventArgs : EventArgs
    {
        public ElementEventArgs(int i, int j)
        {
            this.I = i;
            this.J = j;
        }

        public int I { get; private set; }

        public int J { get; private set; }
    }
}