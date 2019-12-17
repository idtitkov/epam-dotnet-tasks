using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._13
{
    public class SymmetricMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        public SymmetricMatrix(T[][] numbers)
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
            this.Numbers[j][i] = element;
            this.OnElementChanged(i, j);
        }

        public override sealed bool IsInputCorrectly(T[][] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (inputs[i][j].CompareTo(inputs[j][i]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
