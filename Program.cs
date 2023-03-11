bool inWork = true;
Random random = new Random();

#region Switch

while (inWork)
{
    Console.Clear();
    Console.Write($"Как хотите заполнить массив?"
    + "\n Введите \"1\" для заполнения вручную"
    + "\n Введите \"2\" для автозаполнения"
    + "\n Введите \"3\" для выхода"
    + " \n Ваш ответ: ");

    if (int.TryParse(Console.ReadLine(), out int i))
    {
        switch (i)
        {
            case 1:
                {
                    //Console.Clear();
                    HandControl();
                    Exit();

                    break;
                }

            case 2:
                {
                    Console.Clear();
                    AutoControl();
                    Exit();

                    break;
                }

            case 3: inWork = false; break;
        }
    }
}
#endregion

#region Tasks

void HandControl()
{
    string[] array = CreateArray(ReadInt("Введи колличество элемментов в массиве"));
    Console.WriteLine("Ваш массив:");
    PrintArray(array);
    Console.WriteLine();
    Console.WriteLine("Новый массив:");
    PrintArray(Search3Elements(array));
}

void AutoControl()
{
    string[] array = CreateAutoArray(random.Next(1, 7));
    Console.WriteLine("Созданный массив:");
    PrintArray(array);
    Console.WriteLine();
    Console.WriteLine("Новый массив:");
    PrintArray(Search3Elements(array));
}

#endregion

#region MetodsForTasks

int ReadInt(string argumrntName)
{
    Console.Write($"{argumrntName}: ");

    int number = 0;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("It's not a number");
    }
    return number;
}

string ReadString(string argumrntName)
{
    Console.Write($"{argumrntName}: ");
    return Console.ReadLine();
}

string[] CreateArray(int size)
{
    string[] array = new string[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = ReadString($"{i + 1} элемент");
    }

    return array;
}

string RandomWord()
{
    string word = "";
    string[] randomSymbol = {"a", "b", "c", "d", "e", "f", "g", "h", "i",
                            "j", "k", "l", "m", "n", "o", "p", "q", "r",
                            "s", "t", "u", "v", "w", "x", "y", "z", "0",
                            "1", "2", "3", "4", "5", "6", "7", "8", "9",
                            "=", "-", ")", "*", "_", "+", "()"};

    for (int i = 0; i < random.Next(1, 8); i++)
    {
        word += randomSymbol[random.Next(0, randomSymbol.Length)];
    }

    return word;
}

string[] CreateAutoArray(int size)
{
    string[] array = new string[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = RandomWord();
    }

    return array;
}

void PrintArray(string[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1)
        {
            Console.Write($"\"{array[i]}\"");
        }
        else
        {
            Console.Write($"\"{array[i]}\", ");
        }
    }
    Console.WriteLine("]");
}


string[] Search3Elements(string[] array)
{
    int k = 0;
    string[] newArr = new string[array.Length];

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= 3)
        {
            newArr[k] = array[i];
            k++;
        }
    }
    return DeleteEmptyElementsArray(newArr, k);
}

string[] DeleteEmptyElementsArray(string[] array, int size)
{
    string[] newArr = new string[size];
    for (int i = 0; i < newArr.Length; i++)
    {
        newArr[i] = array[i];
    }
    return newArr;
}

void Exit()
{
    Console.WriteLine("==============================");
    Console.WriteLine("Для выхода нажми любую кнопку");
    Console.ReadKey();
}

#endregion