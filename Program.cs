using System;
using System.Linq;

Console.Write("пузырьковая сортировка: императивный стиль: ");
int[] arr = { -5, 16, 87, 0, -33, 25, -11 };
BubbleSortImp(arr);
for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + " "); Console.WriteLine();

Console.Write("пузырьковая сортировка: функциональный стиль: ");
int[] arr1 = { -5, 16, 87, 0, -33, 25, -11 };
arr1 = BubbleSortFunc(arr1, arr1.Length);
for (int i = 0; i < arr1.Length; i++) Console.Write(arr1[i] + " "); Console.WriteLine();

Console.Write("сортировка вставками: императивный стиль: ");
int[] arr2 = { -5, 16, 87, 0, -33, 25, -11 };
InsertionSortImp(arr2);
for (int i = 0; i < arr2.Length; i++) Console.Write(arr2[i] + " "); Console.WriteLine();

Console.Write("сортировка вставками: функциональный стиль: ");
int[] arr3 = { -5, 16, 87, 0, -33, 25, -11 };
arr3 = InsertionSortFunc(arr3);
for (int i = 0; i < arr3.Length; i++) Console.Write(arr3[i] + " "); Console.WriteLine();

Console.Write("сортировка выбором: императивный стиль: ");
int[] arr4 = { -5, 16, 87, 0, -33, 25, -11 };
SelectionSortImp(arr4);
for (int i = 0; i < arr4.Length; i++) Console.Write(arr4[i] + " "); Console.WriteLine();

Console.Write("сортировка выбором: функциональный стиль: ");
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
static int[] BubbleSortFunc(int[] arr, int length)
{
    int[] array = arr;

    // eсли массив пуст или содержит один элемент, то возвращаем
    if (array.Length <= 1) return array;

    // Иначе вызываем рекурсивную функцию, которая сортирует массив за один проход
    return BubbleSortOnePass(array, 0, new int[array.Length]);
}

// Рекурсивная функция, которая сортирует массив за один проход
static int[] BubbleSortOnePass(int[] array, int index, int[] result)
{
    // если конец массива, возвращаем результат
    if (index == array.Length) return result;

    // проверяем, нужно ли менять местами текущий элемент и следующий
    if (index < array.Length - 1 && array[index] > array[index + 1])
    {
        // Если да, то меняем их местами в результате
        result[index] = array[index + 1];
        result[index + 1] = array[index];
        // Продолжаем сортировку с индексом, увеличенным на 2
        return BubbleSortOnePass(array, index + 2, result);
    }
    else
    {
        // Если нет, то копируем текущий элемент в результат без изменений
        result[index] = array[index];
        // Продолжаем сортировку с индексом, увеличенным на 1
        return BubbleSortOnePass(array, index + 1, result);
    }
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
    int min = FindMin(array, 0, array[0]);

    // создаем новый массив без наименьшего элемента с помощью рекурсивной функции
    int[] newArray = RemoveElement(array, min);

    // рекурсивно сортируем новый массив и добавляем наименьший элемент в начало
    return new int[] { min }.Concat(InsertionSortFunc(newArray)).ToArray();
}
static int FindMin(int[] array, int index, int min)
{
    if (index == array.Length) return min;

    // сравниваем текущий элемент с наименьшим и продолжаем поиск
    if (array[index] < min) min = array[index];

    return FindMin(array, index + 1, min);
}
static int[] RemoveElement(int[] array, int element)
{
    if (array.Length == 0) return array;

    // проверяем, равен ли первый элемент заданному
    if (array[0] == element)
        // да => пропускаем его и продолжаем с остальными элементами
        return RemoveElement(array.Skip(1).ToArray(), element);
    else
        // нет => добавляем его в начало нового массива и продолжаем с остальными элементами
        return new int[] { array[0] }.Concat(RemoveElement(array.Skip(1).ToArray(), element)).ToArray();
}


// сортировка выбором: императивный стиль
void SelectionSortImp(int[] array, int currentIndex = 0)
{
    if (currentIndex == array.Length) return;

    var index = IndexOfMin(array, currentIndex);
    if (index != currentIndex) (array[index], array[currentIndex]) = (array[currentIndex], array[index]);

    SelectionSortImp(array, currentIndex + 1);
}
// метод поиска позиции минимального элемента подмассива, начиная с позиции n
int IndexOfMin(int[] array, int n)
{
    int result = n;
    for (var i = n; i < array.Length; ++i)
        if (array[i] < array[result]) result = i;

    return result;
}
// сортировка выбором: функциональный стиль
int[] SelectionSortFunc(int[] array)
{
    return array;
}
