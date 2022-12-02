using System;
using System.Collections.Generic;

namespace MainNameSpace {

    class Matrix {
        private int rows;
        public int Rows {
            get { return rows; }
            set { }
        }

        private int columns;
        public int Columns {
            get { return columns; }
            set { }
        }

        private int[,] matrix;

        public Matrix(int rows, int columns) {
            this.rows = rows;
            this.columns = columns;
            this.matrix = new int[rows, columns];
        }

        public int this[int row, int column] {
            get { return matrix[row, column]; }
            set { matrix[row, column] = value; }
        }

        public void Print() {
            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    Console.Write($"{matrix[row, column]}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        public void Min() {
            int min = matrix[0, 0];
            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    if (matrix[row, column] < min) {
                        min = matrix[row, column];
                    }
                }
            }

            Console.WriteLine($"A mátrix minimuma: {min}");
        }

        public void Max() {
            int max = matrix[0, 0];
            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    if (matrix[row, column] > max) {
                        max = matrix[row, column];
                    }
                }
            }

            Console.WriteLine($"A mátrix maximuma: {max}");
        }

        public void Average() {
            int sum = 0;
            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    sum += matrix[row, column];
                }
            }

            Console.WriteLine($"A mátrix átlaga: {sum / (rows * columns)}");
        }

        public void is12() {
            bool is12 = false;
            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    if (matrix[row, column] == 12) {
                        is12 = true;
                        break;
                    }
                }
            }

            if (is12) {
                Console.WriteLine("A mátrix tartalmazza a 12-et.");
            } else {
                Console.WriteLine("A mátrix nem tartalmazza a 12-et.");
            }
        }

        public void SortAll(bool asc) {
            Matrix sortedMatrix = new Matrix(rows, columns);

            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    sortedMatrix[row, column] = matrix[row, column];
                }
            }

            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    for (int row2 = 0; row2 < rows; row2++) {
                        for (int column2 = 0; column2 < columns; column2++) {
                            if (asc) {
                                if (sortedMatrix[row, column] < sortedMatrix[row2, column2]) {
                                    int temp = sortedMatrix[row, column];
                                    sortedMatrix[row, column] = sortedMatrix[row2, column2];
                                    sortedMatrix[row2, column2] = temp;
                                }
                            } else {
                                if (sortedMatrix[row, column] > sortedMatrix[row2, column2]) {
                                    int temp = sortedMatrix[row, column];
                                    sortedMatrix[row, column] = sortedMatrix[row2, column2];
                                    sortedMatrix[row2, column2] = temp;
                                }
                            }
                        }
                    }
                }
            }

            if (asc) Console.WriteLine("A teljes rendezett mátrix növekvő sorrendbe: ");
            else Console.WriteLine("A teljes rendezett mátrix csökkenő sorrendbe: ");
            sortedMatrix.Print();
        }

        public void Sort(bool asc) {
            Matrix sortedMatrix = new Matrix(rows, columns);

            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    sortedMatrix[row, column] = matrix[row, column];
                }
            }

            switch (asc) {
                case true:
                    for (int row = 0; row < rows; row++) {
                        for (int column = 0; column < columns; column++) {
                            for (int column2 = 0; column2 < columns - 1; column2++) {
                                if (sortedMatrix[row, column2] > sortedMatrix[row, column2 + 1]) {
                                    int temp = sortedMatrix[row, column2];
                                    sortedMatrix[row, column2] = sortedMatrix[row, column2 + 1];
                                    sortedMatrix[row, column2 + 1] = temp;
                                }
                            }
                        }
                    }
                    break;

                case false:
                    for (int row = 0; row < rows; row++) {
                        for (int column = 0; column < columns; column++) {
                            for (int column2 = 0; column2 < columns - 1; column2++) {
                                if (sortedMatrix[row, column2] < sortedMatrix[row, column2 + 1]) {
                                    int temp = sortedMatrix[row, column2];
                                    sortedMatrix[row, column2] = sortedMatrix[row, column2 + 1];
                                    sortedMatrix[row, column2 + 1] = temp;
                                }
                            }
                        }
                    }
                    break;
            }

            if (asc) Console.WriteLine("A mátrix sorai növekvő sorrendbe: ");
            else Console.WriteLine("A mátrix sorai csökkenő sorrendbe: ");
            sortedMatrix.Print();
        }

        public void EvenOdd() {
            List<int> even = new List<int>();
            List<int> odd = new List<int>();

            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    if (matrix[row, column] % 2 == 0) {
                        even.Add(matrix[row, column]);
                    } else {
                        odd.Add(matrix[row, column]);
                    }
                }
            }

            Console.Write("Páros számok: ");
            foreach (int number in even) {
                Console.Write($"{number}, ");
            }

            Console.WriteLine();

            Console.Write("Páratlan számok: ");
            foreach (int number in odd) {
                Console.Write($"{number}, ");
            }

            Console.WriteLine();
        }


    }

    internal class Program {
        static void Main(string[] args) {

            Console.Write("Kérem adja meg a mátrix sorainak számát: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Kérem adja meg a mátrix oszlopainak számát: ");
            int columns = int.Parse(Console.ReadLine());

            Matrix matrix = new Matrix(rows, columns);

            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    Console.Write($"Kérem adja meg a mátrix {row + 1}. sorának {column + 1}. oszlopának értékét: ");
                    matrix[row, column] = int.Parse(Console.ReadLine());
                }
            }

            matrix.Print();

            matrix.Min();
            matrix.Max();
            matrix.Average();
            matrix.is12();
            matrix.EvenOdd();

            matrix.Sort(true);
            matrix.Sort(false);

            matrix.SortAll(true);
            matrix.SortAll(false);
        }
    }
}
