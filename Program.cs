class Solution
{
    public static int Determinant(SquareMatrix Matrix)
    {
        int Result = 0;
        for (int OneDigit = 0; OneDigit < Matrix.Size; ++OneDigit)
        {
            int Addition = 1;
            for (int TwoDigit = 0; TwoDigit < Matrix.Size; ++TwoDigit)
            {
                int SecondPos = OneDigit + TwoDigit;
                if (SecondPos > Matrix.Size - 1) SecondPos = SecondPos - Matrix.Size;
                Addition *= Matrix.Digits[TwoDigit, SecondPos];
            }
            Result += Addition;
        }

        for (int OneDigit = Matrix.Size - 1; OneDigit >= 0; --OneDigit)
        {
            int WhatDelete = 1;
            for (int TwoDigit = 0; TwoDigit < Matrix.Size; ++TwoDigit)
            {
                int SecondPos = OneDigit - TwoDigit;
                if (SecondPos < 0) SecondPos = SecondPos + Matrix.Size;
                WhatDelete *= Matrix.Digits[TwoDigit, SecondPos];
            }
            Result -= WhatDelete;
        }
        return Result;
    }

    public static void MatrixReverse(SquareMatrix Matrix)
    {
        Console.WriteLine("Инверсия матрицы: ");
        Console.Write("\n1 / " + Determinant(Matrix) + " *\n");
        SquareMatrix NewMatrix = new SquareMatrix();
        for (int OneDigit = 0; OneDigit < Matrix.Size; ++OneDigit)
        {
            for (int TwoDigit = 0; TwoDigit < Matrix.Size; ++TwoDigit)
            {
                int OneBuf = 0;
                int TwoBuf = 0;
                for (int OneNewDigit = 0; OneNewDigit < Matrix.Size - 1; ++OneNewDigit)
                {
                    for (int TwoNewDigit = 0; TwoNewDigit < Matrix.Size - 1; ++TwoNewDigit)
                    {
                        if (OneNewDigit == OneDigit)
                        {
                            OneBuf = 1;
                        }
                        if (TwoNewDigit == TwoDigit)
                        {
                            TwoBuf = 1;
                        }
                        NewMatrix.Digits[OneNewDigit, TwoNewDigit] = Matrix.Digits[OneNewDigit + OneBuf, TwoNewDigit + TwoBuf];
                    }
                }
                int Result = Convert.ToInt32(Math.Pow(-1.0, Convert.ToDouble(OneDigit * TwoDigit))) * Solution.Determinant(NewMatrix);
                Console.Write(Result + " ");
            }
            Console.Write("\n");
        }
    }
     public static int FindingTraceMatrix(SquareMatrix Matrix)
    {
        int SumDiagonal = 0;
        for (int numberCol = 0; numberCol < Matrix.Size; numberCol++) 
        {

        }
    }
}
public static class ExtensionMethods
{
    public static SquareMatrix MatrixTransposition(SquareMatrix Matrix)
    {
        SquareMatrix NewMatrix = new SquareMatrix();
        for (int numberCol = 0; numberCol < Matrix.Size; numberCol++)
        {
            for (int numberRow = 0; numberRow < Matrix.Size; numberRow++)
            {
                NewMatrix.Digits[numberCol, numberRow] = Matrix.Digits[numberRow, numberCol];
            }
        }
        return NewMatrix;
    }
}


public class BigSize : System.Exception
{
    public BigSize()
    : base() { }
    public BigSize(string message)
    : base(message) { }
    public BigSize
    (string message, System.Exception inner)
    : base(message, inner) { }

}

class SquareMatrix
{
    public int Size;
    public int[,] Digits = new int[10, 10];
    public void ToString(SquareMatrix Matrix)
    {
        for (int OneDigit = 0; OneDigit < Matrix.Size; ++OneDigit)
        {
            for (int TwoDigit = 0; TwoDigit < Matrix.Size; ++TwoDigit)
            {
                Console.Write("{0,5}", Matrix.Digits[OneDigit, TwoDigit]);
            }
            Console.WriteLine();
        }
    }

    public static SquareMatrix operator +(SquareMatrix Matrix, int Digit)
    {
        for (int RowIndex = 0; RowIndex < Matrix.Size; ++RowIndex)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix.Size; ++ColumnIndex)
            {
                Matrix.Digits[RowIndex, ColumnIndex] = Digit + Matrix.Digits[RowIndex, ColumnIndex];
            }
        }
        return Matrix;
    }
    public static SquareMatrix operator *(SquareMatrix Matrix, int Digit)
    {
        for (int RowIndex = 0; RowIndex < Matrix.Size; ++RowIndex)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix.Size; ++ColumnIndex)
            {
                Matrix.Digits[RowIndex, ColumnIndex] = Digit * Matrix.Digits[RowIndex, ColumnIndex];
            }
        }
        return Matrix;
    }
    public int Sum(SquareMatrix Matrix)
    {
        int Sum = 0;
        for (int RowIndex = 0; RowIndex < Matrix.Size; ++RowIndex)
        {
            for (int ColumnIndex = 0; ColumnIndex < Matrix.Size; ++ColumnIndex)
            {
                Sum += Matrix.Digits[RowIndex, ColumnIndex];
            }
        }
        return Sum;
    }
    public static bool operator >(SquareMatrix LeftMatrix, SquareMatrix RightMatrix)
    {
        if (LeftMatrix.Sum(LeftMatrix) > RightMatrix.Sum(RightMatrix))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator <(SquareMatrix LeftMatrix, SquareMatrix RightMatrix)
    {
        if (LeftMatrix.Sum(LeftMatrix) < RightMatrix.Sum(RightMatrix))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator >=(SquareMatrix LeftMatrix, SquareMatrix RightMatrix)
    {
        if (LeftMatrix.Sum(LeftMatrix) >= RightMatrix.Sum(RightMatrix))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator <=(SquareMatrix LeftMatrix, SquareMatrix RightMatrix)
    {
        if (LeftMatrix.Sum(LeftMatrix) <= RightMatrix.Sum(RightMatrix))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator ==(SquareMatrix LeftMatrix, SquareMatrix RightMatrix)
    {
        if (LeftMatrix.Sum(LeftMatrix) == RightMatrix.Sum(RightMatrix))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator !=(SquareMatrix LeftMatrix, SquareMatrix RightMatrix)
    {
        if (LeftMatrix.Sum(LeftMatrix) != RightMatrix.Sum(RightMatrix))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static explicit operator string(SquareMatrix Matrix)
    {
        string Result = "";
        for (int OneNumber = 0; OneNumber < Matrix.Size; ++OneNumber)
        {
            for (int TwoNumber = 0; TwoNumber < Matrix.Size; ++TwoNumber)
            {
                Result += "   " + Convert.ToString(Matrix.Digits[OneNumber, TwoNumber]);
                Console.Write("{0,5}", Matrix.Digits[OneNumber, TwoNumber]);
            }
            Result += "\n";
        }
        return Result;
    }
    public static bool operator true(SquareMatrix Matrix)
    {
        bool Result = true;
        for (int OneNumber = 0; OneNumber < Matrix.Size; ++OneNumber)
        {
            for (int TwoNumber = 0; TwoNumber < Matrix.Size; ++TwoNumber)
            {
                if (Matrix.Digits[OneNumber, TwoNumber] == 0)
                {
                    Result = false;
                }
            }
        }
        return Result;
    }
    public static bool operator false(SquareMatrix Matrix)
    {
        bool Result = false;
        for (int OneNumber = 0; OneNumber < Matrix.Size; ++OneNumber)
        {
            for (int TwoNumber = 0; TwoNumber < Matrix.Size; ++TwoNumber)
            {
                if (Matrix.Digits[OneNumber, TwoNumber] == 0)
                {
                    Result = true;
                }
            }
        }
        return Result;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Laboratory work 3");
        Console.Write("Specify the size of your matrix (up to 10): ");
        SquareMatrix OneMatrix = new SquareMatrix();
        OneMatrix.Size = Convert.ToInt32(Console.ReadLine());

        if (OneMatrix.Size > 10) throw new BigSize("Matrix size greater than 10");
        Console.Clear();
        Random Random = new Random();
        SquareMatrix TwoMatrix = new SquareMatrix();
        for (int RowIndex = 0; RowIndex < OneMatrix.Size; ++RowIndex)
        {
            for (int ColumnIndex = 0; ColumnIndex < OneMatrix.Size; ++ColumnIndex)
            {
                OneMatrix.Digits[RowIndex, ColumnIndex] = Random.Next(0, 10);
                TwoMatrix.Digits[RowIndex, ColumnIndex] = Random.Next(0, 10);
            }
        }
        Console.WriteLine("The first matrix:");
        OneMatrix.ToString(OneMatrix);
        TwoMatrix.Size = OneMatrix.Size;

        Console.WriteLine("Меnu:\n1) Add a number to the matrix\n2) Multiplication of the matrix by a number\n3) Operation >\n4) Operation <\n5) Operation >=\n6) Operation <=\n7) Operation ==\n8) Operation !=\n9) true / false\n10) The determinant of the matrix");
        int Choice = Convert.ToInt32(Console.ReadLine());
        switch (Choice)
        {
            case 1:
                Console.WriteLine("Enter the number to add to your matrix: ");
                int PlusNumber = Convert.ToInt32(Console.ReadLine());
                OneMatrix.ToString(OneMatrix + PlusNumber);
                break;
            case 2:
                Console.WriteLine("Enter the number by which you want to multiply your matrix: ");
                int MultiplyNumber = Convert.ToInt32(Console.ReadLine());
                OneMatrix.ToString(OneMatrix * MultiplyNumber);
                break;
            case 3:
                Console.WriteLine("The second matrix: ");
                TwoMatrix.ToString(TwoMatrix);
                Console.WriteLine(OneMatrix > TwoMatrix);
                break;
            case 4:
                Console.WriteLine("The second matrix: ");
                TwoMatrix.ToString(TwoMatrix);
                Console.WriteLine(OneMatrix < TwoMatrix);
                break;
            case 5:
                Console.WriteLine("The second matrix: ");
                TwoMatrix.ToString(TwoMatrix);
                Console.WriteLine(OneMatrix >= TwoMatrix);
                break;
            case 6:
                Console.WriteLine("The second matrix: ");
                TwoMatrix.ToString(TwoMatrix);
                Console.WriteLine(OneMatrix <= TwoMatrix);
                break;
            case 7:
                Console.WriteLine("The second matrix: ");
                TwoMatrix.ToString(TwoMatrix);
                Console.WriteLine(OneMatrix == TwoMatrix);
                break;
            case 8:
                Console.WriteLine("The second matrix: ");
                TwoMatrix.ToString(TwoMatrix);
                Console.WriteLine(OneMatrix != TwoMatrix);
                break;
            case 9:
                if (OneMatrix)
                {
                    Console.WriteLine("matrix without zeros");
                }
                else
                {
                    Console.WriteLine("matrix with zeros");
                }
                break;
            case 10:
                Console.WriteLine(Solution.Determinant(OneMatrix));
                break;
        }
        Console.ReadKey();
    }
}
