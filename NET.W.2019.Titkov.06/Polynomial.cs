/*
1. Разработать неизменяемый класс Polynomial (полином) для работы с многочленами степени от одной переменной
вещественного типа (в качестве внутренней структуры для хранения коэффициентов использовать sz-массив).
Для разработанного класса:
- переопределить виртуальные методы класса Object;
- перегрузить операции, допустимые для работы с многочленами (исключая деление многочлена на многочлен), включая "==" и "!=".
Разработать unit-тесты

Титков Иван 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._06
{
    /// <summary>
    /// Contains polynomial and operations with it.
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Readonly array with polynomial coefficients.
        /// </summary>
        private readonly double[] coefficients;

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="coefficients">Polynomial coefficients.</param>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException();
            }

            this.coefficients = new double[coefficients.Length];
            coefficients.CopyTo(this.coefficients, 0);
        }

        /// <summary>
        /// Read-only property.
        /// </summary>
        public double[] Coefficients
        {
            get
            {
                return coefficients;
            }
        }

        public int MyProperty { get; set; }

        #region Overloadings of operators.
        /// <summary>
        /// Operator '+' overload.
        /// </summary>
        /// <param name="a">Addend</param>
        /// <param name="b">Addend</param>
        /// <returns>Sum of polynomials</returns>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            double[] _shortArray;
            double[] _longArray;
            double[] _summedArray;

            if (a.coefficients.Length > b.coefficients.Length)
            {
                _longArray = a.Coefficients;
                _shortArray = b.Coefficients;
            }
            else
            {
                _longArray = b.Coefficients;
                _shortArray = a.Coefficients;
            }

            _summedArray = new double[_longArray.Length];
            _longArray.CopyTo(_summedArray, 0);

            for (int i = 0; i < _shortArray.Length; i++)
            {
                _summedArray[_longArray.Length - _shortArray.Length + i] += _shortArray[i];
            }

            return new Polynomial(_summedArray);
        }

        /// <summary>
        /// Operator '-' overload.
        /// </summary>
        /// <param name="a">Minuend</param>
        /// <param name="b">Subtrahend</param>
        /// <returns>Difference of polynomials.</returns>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            double[] _shortArray;
            double[] _longArray;
            double[] _differenceArray;

            if (a.coefficients.Length > b.coefficients.Length)
            {
                _longArray = a.Coefficients;
                _shortArray = b.Coefficients;
            }
            else
            {
                _longArray = b.Coefficients;
                _shortArray = a.Coefficients;
            }

            _differenceArray = new double[_longArray.Length];
            _longArray.CopyTo(_differenceArray, 0);

            for (int i = 0; i < _shortArray.Length; i++)
            {
                _differenceArray[_longArray.Length - _shortArray.Length + i] -= _shortArray[i];
            }

            return new Polynomial(_differenceArray);
        }

        /// <summary>
        /// Operator '*' overload.
        /// </summary>
        /// <param name="p">Polynomial class object</param>
        /// <param name="multiplier">Integer multiplier</param>
        /// <returns>Multiplied polynomial.</returns>
        public static Polynomial operator *(Polynomial p, int multiplier)
        {
            double[] _multipliedArray = new double[p.coefficients.Length];
            p.Coefficients.CopyTo(_multipliedArray, 0);

            for (int i = 0; i < _multipliedArray.Length; i++)
            {
                _multipliedArray[i] *= multiplier;
            }

            return new Polynomial(_multipliedArray);
        }

        /// <summary>
        /// Operator '*' overload.
        /// </summary>
        /// <param name="multiplier">Integer multiplier</param>
        /// <param name="p">Polynomial class object</param>
        /// <returns></returns>
        public static Polynomial operator *(int multiplier, Polynomial p)
        {
            return p * multiplier;
        }

        /// <summary>
        /// Operator '*' overload.
        /// </summary>
        /// <param name="p">Polynomial class object</param>
        /// <param name="multiplier">Double multiplier</param>
        /// <returns>Multiplied polynomial.</returns>
        public static Polynomial operator *(Polynomial p, double multiplier)
        {
            double[] _multipliedArray = new double[p.coefficients.Length];
            p.Coefficients.CopyTo(_multipliedArray, 0);

            for (int i = 0; i < _multipliedArray.Length; i++)
            {
                _multipliedArray[i] *= multiplier;
            }

            return new Polynomial(_multipliedArray);
        }

        /// <summary>
        /// Operator '*' overload.
        /// </summary>
        /// <param name="multiplier">Double multiplier</param>
        /// <param name="p">Polynomial class object</param>
        /// <returns></returns>
        public static Polynomial operator *(double multiplier, Polynomial p)
        {
            return p * multiplier;
        }

        /// <summary>
        /// /// <summary>
        /// Operator '*' overload.
        /// </summary>
        /// <param name="a">Polynomial multiplier</param>
        /// <param name="b">Polynomial multiplier</param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            double[] _totalArray = new double[a.coefficients.Length + b.coefficients.Length - 1];
            for (int i = 0; i < a.coefficients.Length; i++)
            {
                for (int j = 0; j < b.coefficients.Length; j++)
                {
                    _totalArray[i + j] += a.coefficients[i] * b.coefficients[j];
                }
            }

            return new Polynomial(_totalArray);
        }

        /// <summary>
        /// Operator "==" overload.
        /// </summary>
        /// <param name="a">Polynomial to compare with.</param>
        /// <param name="b">Polynomial to compare with</param>
        /// <returns>True if polynomials contain the same coefficients or false if not.</returns>
        public static bool operator ==(Polynomial a, Polynomial b)
        {
            if (a.coefficients.Length != b.coefficients.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < a.coefficients.Length; i++)
                {
                    if (a.coefficients[i] != b.coefficients[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Operator "!=" overload.
        /// </summary>
        /// <param name="a">Polynomial to compare with.</param>
        /// <param name="b">Polynomial to compare with</param>
        /// <returns>False if polynomials contain the same coefficients or true if not.</returns>
        public static bool operator !=(Polynomial a, Polynomial b)
        {
            return !(a == b);
        }
        #endregion

        #region Overloadings of Object class methods.
        /// <summary>
        /// Determines whether the specified polynomial is equal to the current polynomial.
        /// </summary>
        /// <param name="obj">Polynomial to compare with.</param>
        /// <returns>True if polynomials are equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynomial p = obj as Polynomial;

            return this == p;
        }

        /// <summary>
        /// Polynomial hash function.
        /// </summary>
        /// <returns>A hash code for the current polynomial.</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < coefficients.Length; i++)
            {
                hash += (int)Coefficients[i] ^ i;
            }

            return hash;
        }

        /// <summary>
        /// Returns a string that represents the current polynomial.
        /// </summary>
        /// <returns>A string that represents the current polynomial.</returns>
        public override string ToString()
        {
            StringBuilder _polynomialString = new StringBuilder();

            for (int i = 0, j = coefficients.Length - 1; i < coefficients.Length; i++, j--)
            {
                _polynomialString.AppendFormat($"{Coefficients[i]}x^{j} + ");
            }

            _polynomialString.Replace("+ -", "- ");
            _polynomialString.Replace("^1", string.Empty);
            _polynomialString.Replace("x^0 + ", string.Empty);
            return _polynomialString.ToString();
        }
        #endregion
    }
}