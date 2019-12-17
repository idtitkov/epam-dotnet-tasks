using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._13
{
    public class SquareMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        public SquareMatrix(T[][] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            if (!this.IsInputCorrectly(numbers))
            {
                throw new Exception("Invalid parameter for this type" + nameof(numbers));
            }

            this.Numbers = numbers;
        }

        public override void SetElement(int i, int j, T element)
        {
            this.Numbers[i][j] = element;
            this.OnElementChanged(i, j);
        }

        public override sealed bool IsInputCorrectly(T[][] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i].Length != inputs.Length)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
