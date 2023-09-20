using System;
using System.Linq;

Console.Write("пузырьковая сортировка | императивный стиль: ");
int[] arr = { -5, 16, 87, 0, -33, 25, -11 };
BubbleSortImp(arr);
for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + " "); Console.WriteLine();

Console.Write("пузырьковая сортировка | функциональный стиль: ");
int[] arr1 = { -5, 16, 87, 0, -33, 25, -11 };
arr1 = BubbleSortFunc(arr1);
for (int i = 0; i < arr1.Length; i++) Console.Write(arr1[i] + " "); Console.WriteLine();

Console.Write("сортировка вставками | императивный стиль: ");
int[] arr2 = { -5, 16, 87, 0, -33, 25, -11 };
InsertionSortImp(arr2);
for (int i = 0; i < arr2.Length; i++) Console.Write(arr2[i] + " "); Console.WriteLine();

Console.Write("сортировка вставками | функциональный стиль: ");
int[] arr3 = { -5, 16, 87, 0, -33, 25, -11 };
arr3 = InsertionSortFunc(arr3);
for (int i = 0; i < arr3.Length; i++) Console.Write(arr3[i] + " "); Console.WriteLine();

Console.Write("сортировка выбором | императивный стиль: ");
int[] arr4 = { -5, 16, 87, 0, -33, 25, -11 };
SelectionSortImp(arr4);
for (int i = 0; i < arr4.Length; i++) Console.Write(arr4[i] + " "); Console.WriteLine();

Console.Write("сортировка выбором | функциональный стиль: ");
int[] arr5 = { -5, 16, 87, 0, -33, 25, -11 };
arr3 = SelectionSortFunc(arr5);
for (int i = 0; i < arr5.Length; i++) Console.Write(arr5[i] + " "); Console.WriteLine();

// пузырьковая сортировка: императивный стиль
void BubbleSortImp(int[] arr)
{
    int n = arr.Length;

    for (int i = 0; i < n - 1; i++)
        for (int j = 0; j < n - i - 1; j++)
            if (arr[j] > arr[j + 1])
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
}
// пузырьковая сортировка: функциональный стиль
// повторяет процесс пузырьковой сортировки, пока массив не будет отсортирован
int[] BubbleSortFunc(int[] arr)
{
    if (IsSorted_BubFunc(arr))
    {
        return arr;
    } else {
        return BubbleSortFunc(Bubble_BubFunc(arr, 0));
    }
}
bool IsSorted_BubFunc(int[] array)
{
    return array.Zip(array.Skip(1), (a, b) => a <= b).All(x => x);
}
// меняет местами два элемента массива, если первый больше второго
int[] Swap_BubFunc(int[] array, int i)
{
    if (array[i] > array[i + 1])
    {
        (array[i], array[i + 1]) = (array[i + 1], array[i]);
    }
    return array;
}
// проходит по массиву и меняет местами соседние элементы, если нужно
int[] Bubble_BubFunc(int[] array, int i)
{
    if (i < array.Length - 1) return Bubble_BubFunc(Swap_BubFunc(array, i), i + 1);
    else return array;
}


// сортировка вставками: императивный стиль
void InsertionSortImp(int[] array)
{
    for (int i = 1; i < array.Length; i++)
    {
        int j;
        int buf = array[i];
        for (j = i - 1; j >= 0; j--)
        {
            if (array[j] < buf)
                break;

            array[j + 1] = array[j];
        }
        array[j + 1] = buf;
    }
}
// сортировка вставками: функциональный стиль
int[] InsertionSortFunc(int[] array)
{
    // если массив пуст или содержит один элемент, то возвращаем
    if (array.Length <= 1) return array;

    // находим наименьший элемент в массиве с помощью рекурсивной функции
    int min = FindMin_InsertFunc(array, 0, array[0]);

    // создаем новый массив без наименьшего элемента с помощью рекурсивной функции
    int[] newArray = RemoveElement_InsertFunc(array, min);

    // рекурсивно сортируем новый массив и добавляем наименьший элемент в начало
    return new int[] { min }.Concat(InsertionSortFunc(newArray)).ToArray();
}
int FindMin_InsertFunc(int[] array, int index, int min)
{
    if (index == array.Length) return min;

    // сравниваем текущий элемент с наименьшим и продолжаем поиск
    if (array[index] < min) min = array[index];

    return FindMin_InsertFunc(array, index + 1, min);
}
int[] RemoveElement_InsertFunc(int[] array, int element)
{
    if (array.Length == 0) return array;

    // проверяем, равен ли первый элемент заданному
    if (array[0] == element)
        // да => пропускаем его и продолжаем с остальными элементами
        return RemoveElement_InsertFunc(array.Skip(1).ToArray(), element);
    else
        // нет => добавляем его в начало нового массива и продолжаем с остальными элементами
        return new int[] { array[0] }.Concat(RemoveElement_InsertFunc(array.Skip(1).ToArray(), element)).ToArray();
}


// сортировка выбором: императивный стиль
void SelectionSortImp(int[] array, int currentIndex = 0)
{
    if (currentIndex == array.Length) return;

    var index = FindMinIndex_SelImp(array, currentIndex);
    if (index != currentIndex) (array[index], array[currentIndex]) = (array[currentIndex], array[index]);

    SelectionSortImp(array, currentIndex + 1);
}
// метод поиска позиции минимального элемента подмассива, начиная с позиции n
int FindMinIndex_SelImp(int[] array, int n)
{
    int result = n;
    for (var i = n; i < array.Length; ++i)
        if (array[i] < array[result]) result = i;

    return result;
}
// сортировка выбором: функциональный стиль
int[] SelectionSortFunc(int[] array)
{
    return Selection__SelFunc(array, 0);
}
int FindMinIndex_SelFunc(int[] array, int start)
{
    if (start == array.Length - 1) return start;
    else
    {
        int minIndex = FindMinIndex_SelFunc(array, start + 1);
        return array[start] < array[minIndex] ? start : minIndex;
    }
}
// Функция, которая меняет местами два элемента массива
int[] Swap_SelFunc(int[] array, int i, int j)
{
    if (i != j) (array[i], array[j]) = (array[j], array[i]);
    return array;
}
// Функция, которая проходит по массиву и выбирает наименьший элемент для каждой позиции
int[] Selection__SelFunc(int[] array, int i)
{
    if (i < array.Length - 1)
    {
        int minIndex = FindMinIndex_SelFunc(array, i);
        return Selection__SelFunc(Swap_SelFunc(array, i, minIndex), i + 1);
    }
    else return array;
}
