using Collections;

Random random = new Random();
int[] arr = //{ 1, 5, 3, 6, 7, 2, 9, 8, 4};
    Enumerable
    .Repeat(0, 100)
    .Select(x => random.Next(0, 100))
    .ToArray();

//SortAlgorithms.InsertionSort(arr);

//SortAlgorithms.SelectionSort(arr);

//SortAlgorithms.BubbleSort(arr);

SortAlgorithms.MergeSort(arr);

Console.WriteLine(SortAlgorithms.OpCount);

for (int i = 0; i < arr.Length; i++)
{
    Console.Write($"{arr[i]}, ");
}

//선택 정열 : 왼쪽에서 부터 이 숫자보다 가장 작은 수와 바꿔서 정열
//삽입 정열 : 왼쪽에서 부터(처번째는 제외) 앞에 숫자와 
