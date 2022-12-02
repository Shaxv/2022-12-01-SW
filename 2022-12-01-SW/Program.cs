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
            Console.WriteLine("Az eredeti mátrix: ");
            this.Print();

            Console.WriteLine($"A mátrix minimuma: {min}");

            Console.WriteLine();
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
            Console.WriteLine("Az eredeti mátrix: ");
            this.Print();

            Console.WriteLine($"A mátrix maximuma: {max}");

            Console.WriteLine();
        }

        public void Average() {
            int sum = 0;
            for (int row = 0; row < rows; row++) {
                for (int column = 0; column < columns; column++) {
                    sum += matrix[row, column];
                }
            }
            Console.WriteLine("Az eredeti mátrix: ");
            this.Print();

            Console.WriteLine($"A mátrix átlaga: {sum / (rows * columns)}");

            Console.WriteLine();
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
            Console.WriteLine("Az eredeti mátrix: ");
            this.Print();

            if (is12) {
                Console.WriteLine("A mátrix tartalmazza a 12-et.");
            } else {
                Console.WriteLine("A mátrix nem tartalmazza a 12-et.");
            }

            Console.WriteLine();
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
            Console.WriteLine("Az eredeti mátrix: ");
            this.Print();

            if (asc) Console.WriteLine("A teljes rendezett mátrix növekvő sorrendbe: ");
            else Console.WriteLine("A teljes rendezett mátrix csökkenő sorrendbe: ");
            sortedMatrix.Print();

            Console.WriteLine();
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
            Console.WriteLine("Az eredeti mátrix: ");
            this.Print();

            if (asc) Console.WriteLine("A mátrix sorai növekvő sorrendbe: ");
            else Console.WriteLine("A mátrix sorai csökkenő sorrendbe: ");
            sortedMatrix.Print();

            Console.WriteLine();
            Console.WriteLine();
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
            Console.WriteLine("Az eredeti mátrix: ");
            this.Print();

            Console.Write("Páros számok: ");
            if (even.Count == 0) {
                Console.Write("Nincs páros szám.");
            } else {
                foreach (int number in even) {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();

            Console.Write("Páratlan számok: ");
            if (odd.Count == 0) {
                Console.Write("Nincs páratlan szám.");
            } else {
                foreach (int number in odd) {
                    Console.Write($"{number}, ");
                }
            }

            Console.WriteLine();
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

            Console.WriteLine("A létrehozott mátrix: ");
            matrix.Print();

            int choice = 1;
            while (choice != 0) {
                Console.WriteLine("1. A mátrix minimum eleme");
                Console.WriteLine("2. A mátrix maximum eleme");
                Console.WriteLine("3. A mátrix átlaga");
                Console.WriteLine("4. Található-e 12 a mátrixban");
                Console.WriteLine("5. A mátrix sorai rendezve növekvő sorrendbe");
                Console.WriteLine("6. A mátrix sorai rendezve csökkenő sorrendbe");
                Console.WriteLine("7. A mátrix páros és páratlan számok");
                Console.WriteLine("8. A teljes mátrix rendezve növekvő sorrendbe");
                Console.WriteLine("9. A teljes mátrix rendezve csökkenő sorrendbe");
                Console.WriteLine("0. Kilépés");

                Console.Write("Kérem válasszon egy menüpontot: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice) {
                    case 1:
                        matrix.Min();
                        break;

                    case 2:
                        matrix.Max();
                        break;

                    case 3:
                        matrix.Average();
                        break;

                    case 4:
                        matrix.is12();
                        break;

                    case 5:
                        matrix.Sort(true);
                        break;

                    case 6:
                        matrix.Sort(false);
                        break;
                        
                    case 7:
                        matrix.EvenOdd();
                        break;

                    case 8:
                        matrix.SortAll(true);
                        break;

                    case 9:
                        matrix.SortAll(false);
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Hibás menüpont!");
                        break;
                }
            }
        }
    }
}
