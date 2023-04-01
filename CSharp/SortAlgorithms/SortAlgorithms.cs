using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class SortAlgorithms
    {
        public static int OpCount;
        #region Bubble Sort
        //거품 정열
        //바로 뒤의 요소가 현재 요소보다 작으면 바꾼다
        //Outer for loop가 한번 들때마다 가장 큰 수의 위치가 고정
        //O(N^2)
        //Stable  : 동일한 값의 정열 전의 요소들의 순서가 정렬 후에도 보장됨

        public static void BubbleSort(int[] arr)
        {
            OpCount = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region Selection Sort

        //선택 정열 : 현재 바로 뒤부터 끝까지 중에서 가장 작은 수를 찾아서 바꾼다
        //Outer for loop 가 한번 돌 때마다 가장 작은 수의 위치가 하나씩 고정
        //O(N^2)
        //unstable (위치가 고정되어 있지 않은)

        public static void SelectionSort(int[] arr)
        {
            OpCount = 0;
            int minindex;
            for (int i = 0; i < arr.Length; i++)
            {
                OpCount = 0;
                minindex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minindex])
                    {
                        minindex = j;

                    }

                }
                Swap(ref arr[i], ref arr[minindex]);
            }
        }

        #endregion

        #region I

        //삽입 정열 
        //현재 위치보다 이전 위치들 둥 더 큰값이 있으면 해당값을 그 다음 인덱스에 덮어쓰고
        //위 과정이 끝나면 마지막으로 찾았던 큰값 인덱스 위치에 현재 현재 탐색했던 위치의 값(key)를 덮어씀
        //O(N^2)
        public static void InsertionSort(int[] arr)
        {
            OpCount = 0;
            int key;
            int j;
            for (int i = 0; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                //key 값보다 큰값이 있을 경우 해당값을 바로 뒤에 덮어씀
                while (j >= 0 &&
                    arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                    OpCount++;
                }
                arr[j + 1] = key; // 마지막으로 찾은 key 가뵤의 인덱스에 key 값 대입
            }
        }

        #endregion

        #region

        //병합 정열
        //요소를 최소 단위 까지 나눈 후에 차례대로 병합을 하면서 정열함(Divide & conquer)
        //O(NLogN)
        //Stable

        #endregion

        //ref 키워드 : 인자로 참조를 받고 싶은 경우 사용
        //out 키워드 : 함수 반환시 해당 파라미터 값을 반환하고 싶을 때 사용.
        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
            OpCount += 3;
        }

        #region
        public static void MergeSort(int[]arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        public static void MergeSort(int[]arr, int start, int end)
        {
            if (start < end)
            {
                int mid = end + (start - end) / 2 - 1; //overflow 방지용. 결론적으로는 (start + end)/ 2이다
                MergeSort(arr, mid + 1, end);
                MergeSort(arr, start, mid);

                Merge(arr, start, mid, end);
            }
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] tmp = new int[end - start + 1];
            for(int i = 0; i <= end - start; i++)
                tmp[i] = arr[i + start];

            int part1 = start;
            int part2 = mid + 1;
            int index = start;

            while (part1 < mid &&
                part2 <= end) 
            {
                //part1이 part2 이하라면 part1을 채택
                if (tmp[part1 - start] <= tmp[part2 - start])
                {
                    arr[index] = tmp[part2 - start];
                    arr[index++] = tmp[part1++ - start];
                    
                }
                else
                {
                    arr[index++] = tmp[part2++ - start];
                }
            }

            //남은 part1을 뒤에 쭉 이여붙여줌
            //남은 part2는 이미 정복된  상태이기 태문에 그대로 쓰면됨.
            for (int i = 0; i <= mid - part1; i++)
            {
                arr[index + 1] = tmp[part1 - start + i];
            }

        }


        #endregion

        #region Quick Sort

        //빠른 정열
        //최악의 경우 O(N^2)
        //O(NlogN)
        //현존하는 정열 알고리즘 중에 가장 빠르다
        //정복 할때마다 Pivot에 해당하는 인덱스위치가 고정되어서
        //정복할 때 고려해야하는 경우의 수가 줄어듦
        //Pivot의 위치가 평균적으로 끝지점에 몰리지 않기 때문에
        //이분할을 하는 경우처럼 LogN이 된다
        //N^2이 되는 경우를 최대한 방지하기 \위해서 Pivot을 설정하는 특별한 알고리즘을
        //추가로 적용할 수 있다
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort(int[]arr, int start, int end)
        {
            if (start < end)
            {
                int p = Partition(arr, start, end);
                QuickSort(arr, start, p - 1);
                QuickSort(arr, p + 1, end);
            }
        }
        
        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end + (start - end) / 2];

            while (true) 
            {
                while (arr[start] < pivot)start++;
                while (arr[end] > pivot) end--;

                if(start < end)
                {
                    Swap(ref arr[start], ref arr[end]);
                }
                else
                {
                    return end; // start 가능
                }
            }
        }

        #endregion

        //Merge Sort : 숫자들 중에서 가운데 숫자 를 잡고 반으로 가른다 (중간 지점은 처음 숫자들 과 합친다) 낮 개가 나올 때까지 반복
        //낮 개가 되었을 때 파트1, 2로 나눈다(파트 1, 2를 나누는 기준은 파트 1은 처음부터 시작, 파트2는 중간 숫자 + 1 부터 시작)
        //나머지는 노션 사진 참고
        

        //부모 노드 구하는 방법 = (현재 노드 - 1 ) / 2 

    }
}