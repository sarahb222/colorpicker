using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomConverter : MonoBehaviour
{
    public int RandomNumber(char A, char B)
    {
        int convA = ConvertToInt(A);
        int convB = ConvertToInt(B);
        int result;
        if (convA > convB)
        {
            result = Random.Range(convB, convA + 1);
        }
        else
        {
            result = Random.Range(convA, convB + 1);
        }
        return result;
    }

    public int ConvertToInt(char unconverted)
    {
        int conversion;
        if (unconverted == '0')
        {
            conversion = 0;
        }
        else if (unconverted == '1')
        {
            conversion = 1;
        }
        else if (unconverted == '2')
        {
            conversion = 2;
        }
        else if (unconverted == '3')
        {
            conversion = 3;
        }
        else if (unconverted == '4')
        {
            conversion = 4;
        }
        else if (unconverted == '5')
        {
            conversion = 5;
        }
        else if (unconverted == '6')
        {
            conversion = 6;
        }
        else if (unconverted == '7')
        {
            conversion = 7;
        }
        else if (unconverted == '8')
        {
            conversion = 8;
        }
        else if (unconverted == '9')
        {
            conversion = 9;
        }
        else if (unconverted == 'A')
        {
            conversion = 10;
        }
        else if (unconverted == 'B')
        {
            conversion = 11;
        }
        else if (unconverted == 'C')
        {
            conversion = 12;
        }
        else if (unconverted == 'D')
        {
            conversion = 13;
        }
        else if (unconverted == 'E')
        {
            conversion = 14;
        }
        else if (unconverted == 'F')
        {
            conversion = 15;
        }
        else
        {
            Debug.Log("Error, invalid convert from char to int");
            conversion = -1;
        }
        return conversion;
    }
    public char ConvertToChar(int unconverted)
    {
        char conversion;
        if (unconverted == 0)
        {
            conversion = '0';
        }
        else if (unconverted == 1)
        {
            conversion = '1';
        }
        else if (unconverted == 2)
        {
            conversion = '2';
        }
        else if (unconverted == 3)
        {
            conversion = '3';
        }
        else if (unconverted == 4)
        {
            conversion = '4';
        }
        else if (unconverted == 5)
        {
            conversion = '5';
        }
        else if (unconverted == 6)
        {
            conversion = '6';
        }
        else if (unconverted == 7)
        {
            conversion = '7';
        }
        else if (unconverted == 8)
        {
            conversion = '8';
        }
        else if (unconverted == 9)
        {
            conversion = '9';
        }
        else if (unconverted == 10)
        {
            conversion = 'A';
        }
        else if (unconverted == 11)
        {
            conversion = 'B';
        }
        else if (unconverted == 12)
        {
            conversion = 'C';
        }
        else if (unconverted == 13)
        {
            conversion = 'D';
        }
        else if (unconverted == 14)
        {
            conversion = 'E';
        }
        else if (unconverted == 15)
        {
            conversion = 'F';
        }
        else
        {
            Debug.Log("Error, invalid convert from int to char");
            conversion = 'Z';
        }

        return conversion;

    }
}
