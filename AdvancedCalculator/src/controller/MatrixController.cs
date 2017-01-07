using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculator
{
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

        public void addMatrix(Matrix m)
        {
            matrixList.Add(m);
            numMatrices++;
        }

    }
}
