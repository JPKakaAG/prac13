using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac13
{
    static class visulaarray
    {
        /// <summary>
        /// Метод для двухмерного массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
        /// <summary>
        /// Функция заполянет массив  числами от 0 до 10
        /// </summary>
        /// <param name="array"> имя массива для заполнения</param>
        public static void Fill2Array(int[,] array)
        {
            // Получаем размеры массива
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            Random rnd = new Random();

            // Заполняем массив заданным значением
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = rnd.Next(0, 10);
                }
            }
        }
    }
}
