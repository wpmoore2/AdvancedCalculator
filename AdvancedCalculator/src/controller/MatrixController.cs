using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculator
{

    /**
     *      A Matrix Controller allows for storing, retreiving, and 
     *      manipulating a series of Matrices.
     **/
    class MatrixController
    {
        private int numMatrices;
        private List<Matrix> matrixList;

        public MatrixController()
        {
            numMatrices = 0;
            matrixList = new List<Matrix>();
        }



        public int getNumMatrices()
        {
            return this.numMatrices;
        }

        public void setNumMatrices(int num)
        {
            this.numMatrices = num;
        }

        /**
         *     Add another matrix to the global list.
         *     
         *     @param  The matrix to be added.
         **/
        public void addMatrix(Matrix m)
        {
            matrixList.Add(m);
            numMatrices++;
        }


        public void updateMatrix(Matrix m, int idx)
        {
            matrixList.RemoveAt(idx);
            matrixList.Insert(idx, m);
        }


        /**
         *   Return the 
         **/
        public Matrix getMatrix(int index)
        {
            Matrix ret = null;
            try
            {
                ret = this.matrixList[index];
            } catch (IndexOutOfRangeException e)
            {
                return null;    
            }
            return ret;
        }

    }
}
