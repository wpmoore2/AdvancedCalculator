using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculator
{
    class Matrix
    {
        private int numRow { get; set; }
        private int numCol { get; set; }
        private int[][] array { get; set; }

        public Matrix ()
        {
        }

        public Matrix(int[][] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();

            numRow = arr.Length;
            numCol = arr[0].Length;
            array = arr;
        }


        /**
         *   Get the number of rows for a matrix
         * */
        public int getRow()
        {
            return array.Length;
        }


        /**
         *   Get the number of columns for a matrix
         * */
        public int getCol()
        {
            return array[0].Length;
        }


        /**
         *   Set a single value at a specified position of the matrix
         * */
        public void setValue(int row, int col, int value)
        {
            array[row][col] = value;
        }


        /**
         *   Get a single value at a specified position of the matrix
         * */
        public int getValue(int row, int col)
        {
            return array[row][col];
        }

    }
}
