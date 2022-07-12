// Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
// так чтобы в одной группе все числа друг на друга не делились? 
// Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.
// Например, для N = 50, M получается 6

int n = InputNumbers("Введи число N: ");

int[] array = CreateArray(n);
CreateGroup(array);

void CreateGroup(int[] secondArray)
{
  int[] thirdArray = new int[secondArray.Length];
  int m = 1;
  int count = 0;
  int tempNumber = 0;
  int tempNumber2 = 0;
  int tempSwitch = 0;
  
  for (int i = 0; i < secondArray.Length; i++)
  {
    Array.Clear(thirdArray);
    count = 0;
    if (secondArray[i] != 0)
    {
      thirdArray[count] = secondArray[i];
      tempNumber2 = secondArray[i];

      for (int j = i; j < secondArray.Length; j++)
      {
        if (secondArray[j] % tempNumber2 != 0 
        || secondArray[j] / tempNumber2 == 1)
        {
          tempSwitch = 0;
          tempNumber = secondArray[j];
          for (int k = 0; k < count; k++)
          {
            if (tempNumber % thirdArray[k] == 0) tempSwitch++;
          }
          if (tempSwitch == 0)
          {
            thirdArray[count] = secondArray[j];
            count++;
            secondArray[j] = 0;
          }
        }
      }
      Console.WriteLine($"Группа {m++}: {PrintIntArray(thirdArray)}");
    }
  }
}

int InputNumbers(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

int[] CreateArray(int n)
{
  int[] temp = new int[n];
  for (int i = 0; i < temp.GetLength(0); i++)
  {
    temp[i] = i + 1;
  }
  return temp;
}

string PrintIntArray(int[] array)
{
  string result = string.Empty;
  for (int i = 0; i < array.Length; i++)
  {
    if (array[i] != 0) result += $"{array[i],1} ";
  }
  return result;
}