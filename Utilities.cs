using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7
{
    internal class Utilities
    {
        public static char MostFrequentChar(string s)
        {
            Dictionary<char, int> mostFrequent = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (mostFrequent.ContainsKey(c))
                {
                    mostFrequent[c]++;
                }
                else
                {
                    mostFrequent[c] = 1;
                }

            }
            char mostFrequentChar = '\0';
            int maxCount = 0;
            foreach (var pair in mostFrequent)
            {
                if (pair.Value > maxCount)
                {
                    maxCount = pair.Value;
                    mostFrequentChar = pair.Key;
                }
            }

            return mostFrequentChar;
        }
        public static void BubbleSortDemo(int[] nums)//ON2
        {//compares side by side if the one on the left is smaller it stays, if it doesnt it moves to the next index and compares to the index beside it,
         //goes through the whole array until their is no more swapping
            bool swapped;
            for (int i = 0; i < nums.Length - 1; i++)//outerloop
            {
                swapped = false;

                for (int j = 0; j < nums.Length - 1 - i; j++)//-i because we dont  need to go to the end anymore
                {
                    //Console.WriteLine($"This is j value {j}");
                    if (nums[j] > nums[j + 1])//checking if the number in index j is greater then the index next to it, if not go to the next index, if its true swap.
                    {
                        //standard swap operation
                        int temp = nums[j];//store the current value at this index

                        nums[j] = nums[j + 1];//takes the number at j and makes it equal to the number next to it
                        nums[j + 1] = temp;//now takes the number that was stored originally at that index to be moved +1
                        swapped = true;
                    }

                }
                if (!swapped)
                {
                    break;
                }
            }

        }
        public static int BinarySearch(int[] array, int target)//O(logN)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                Console.WriteLine($"This is the middle at {mid} with value {array[mid]}");
                if (array[mid] == target)
                {
                    return mid;

                }
                else if (array[mid] < target)
                {
                    left = mid + 1;

                }
                else
                {
                    right = mid - 1;

                }
                Console.WriteLine($"This is left [{left}]: {array[left]} ");
                Console.WriteLine($"This is right [{right}]: {array[right]}");
            }
            return -1;
        }
        public static int LinearSearch(int[] array, int target)//O(N)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    Console.WriteLine($"Student found at element {i} ");
                }
            }
            return -1;
        }
        public static void RecursionDemo(int n)//declare the type to recurse on
        {
            if (n <= 1) //if the number is less then or equal to 1 return, cant check evens with just 1 or 0
            { return; }

            if (n % 2 != 0) //if the number is divisible by 2 and equals zero
            {
                Console.WriteLine(n); //output the number, when its true its done.
            }

            RecursionDemo(n - 1);// recurse the number down to the end
        }
        public static int FactorialRecursive(int n)
        {

            if (n <= 1)
            { return 1; }

            else
            {
                return n * FactorialRecursive(n - 1);
            }



        }
        public static void FindFile(string filetofind, string directory, ref string foundpath)
        {
            if (!string.IsNullOrWhiteSpace(foundpath))
            {
                return;
            }
            var di = new DirectoryInfo(directory);
            foreach (var file in di.GetFiles())
            {
                if (file.Name.Contains(filetofind, StringComparison.OrdinalIgnoreCase))
                {
                    foundpath = file.FullName;
                    return;
                }
            }
            foreach (var folder in di.GetDirectories())
            {
                FindFile(filetofind, folder.FullName, ref foundpath);
            }

        }
        public static void InsertionSortDemo(int[] nums)//ON2
                                                        //starts at the left
        { //goes from one positon to another comparing each index, to sort it in order
            int key = 0;
            int j = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                key = nums[i];//temp variable
                j = i - 1;

                while (j >= 0 && nums[j] > key)
                {
                    nums[j + 1] = nums[j];
                    j--;

                    nums[j + 1] = key;
                }
            }

        }
        public static void SelectionSortDemo(int[] nums)//ON2
                                                        //start with the start index looks through all the numbers and finds the smallest
                                                        //whatevers left goes through all and does 1 for 1 swap
        {
            int j = 0;
            int minIndex = 0; //tracking the remaining elements where is the smallest number
            for (int i = 0; i < nums.Length - 1; i++)//overall iteration
            {
                minIndex = i;//sets the index for the lowest number
                for (j = i + 1; j < nums.Length; j++)//looks through the array after the the index[i]
                {
                    if (nums[j] < nums[minIndex])// if the number in j index is less then the number in minindex 
                    {
                        minIndex = j;

                    }
                }
                int temp = nums[i];//temp variable to hold 
                nums[i] = nums[minIndex];
                nums[minIndex] = temp;

            }
        }
        public static void SortWithQuickSortDemo(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;
            QuickSortDemo(nums, low, high);

        }
        public static void QuickSortDemo(int[] nums, int low, int high) //average case O(N Log N) can be ON2
        { //uses recursion to sort before and after a pivot point
            if (low < high)
            {
                int pivotIndex = PartitionForQuickSort(nums, low, high);
                QuickSortDemo(nums, low, pivotIndex - 1);
                QuickSortDemo(nums, pivotIndex + 1, high);
            }

        }
        public static int PartitionForQuickSort(int[] nums, int low, int high)
        {
            int pivot = nums[high];
            int temp = 0;
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (nums[j] <= pivot)
                {
                    i++;
                    temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }
            nums[high] = nums[i + 1];
            nums[i + 1] = pivot;

            return i + 1;
        }
        public static void SortWithMergeSortDemo(int[] nums)//O(N log N) ideal for linked lists
        {
            int left = 0;
            int right = nums.Length - 1;
            MergeSorter(nums, left, right);
        }

        public static void MergeSorter(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int middle = (right + left) / 2;
                MergeSorter(nums, left, middle);
                MergeSorter(nums, middle + 1, right);
                MergeForDemo(nums, left, middle, right);
            }
        }
        public static void MergeForDemo(int[] nums, int left, int middle, int right)
        {

            int[] leftArray = new int[middle - left + 1];
            //create rightArray
            //from arr[middle + 1 to right]
            int[] rightArray = new int[right - middle];

            Array.Copy(nums, left, leftArray, 0, leftArray.Length);
            Array.Copy(nums, middle + 1, rightArray, 0, rightArray.Length);

            //i, j, k = 0
            int i = 0;
            int j = 0;
            int k = left;

            while (i < leftArray.Length && j < rightArray.Length)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    nums[k] = leftArray[i];
                    i = i + 1;
                }
                else
                {
                    nums[k] = rightArray[j];
                    j = j + 1;
                }
                k = k + 1;
            }

            //copy remaining elements of leftArray(if any)
            while (i < leftArray.Length)
            {
                nums[k] = leftArray[i];
                i++;
                k++;
            }

            //copy remaining elements of rightArray(if any)
            while (j < rightArray.Length)
            {
                nums[k] = rightArray[j];
                j++;
                k++;
            }

        }
        public static void ShellSortDemo(int[] nums)// worst case is ON2, best case/average O(n*LogN)
        {// first sorts the elements that are far apart from each other
            int n = nums.Length;

            for (int gap = n / 2; gap > 0; gap /= 2) // start with large gap and gradually reduce it, the /= is dividing gap by 2 and reassigning gap to the result of the division.
            {
                //Console.WriteLine($"The value of gap is {gap}");
                for (int i = gap; i < n; i++)// traverse(walks through step by step) the array from the gap index to the end
                {
                    Console.WriteLine($"iteration count {i}");
                    //Console.WriteLine($"The value of I INDEX is {i}");
                    int temp = nums[i];// store the current element
                    int j;

                    for (j = i; j >= gap && nums[j - gap] > temp; j -= gap) // compare the current element with the elements in its group
                    {
                        nums[j] = nums[j - gap]; //shifts the elements up in the group
                        //Console.WriteLine($"The value of j index is {j}");
                    }
                    nums[j] = temp; //insert the current element in the correct posistion of the group


                    Console.WriteLine($"The gap = {gap} index I = {i} index J ={j}  temp = {temp}");
                }

            }

        }
        public static int FindMaximum(int a, int b, int c)
        {
            if (a < b)
            {
                if (a > c || a == c)
                {
                    return a;
                }
            }

            if (b < c)
            {
                if (b > c || b == c)
                { return b; }
            }

            return c;
        }
        public static void HashingDemo(string s, string[] data)

        {
            long total = 0;
            char[] c;
            c = s.ToCharArray();

        }

        public static int FindMaximum2(int a, int b, int c)
        {
            int max = a;//we assume max is a

            if (b > max)//if be is greater then max
            {
                max = b;//set max to b if greater
            }

            if (c > max)//if c is greater then a
            { max = c; } //set max to c

            return max;

        }
        public static Boolean IsComplex(string s)
        {
            return s.Any(char.IsUpper) && s.Any(char.IsLower)
                     && s.Any(char.IsDigit);
        }

        public static string NormalizeString(String s)
        {

            string lowercased = s.ToLower();
            string trimmed = lowercased.Trim();

            return s.ToLower().Trim().Replace(",", "");

        }
        public static void ParseString(string s)
        {
            foreach (char c in s)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("Option 2");
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                Console.WriteLine(c);
            }
        }

        public static void FindMaxArray(int[] array)//O(N)
        {
            int max = 0;

            foreach (int i in array)
            {
                if (i > max)
                    max = i;

            }
            Console.WriteLine(max);
        }
        public static Boolean IsUpperCase(String s)
        {
            return s.All(char.IsUpper);

        }
        public static Boolean IsLowerCase(String s)
        {
            return s.All(char.IsLower);

        }
        public static void TwoDArrayDemo(int[,] numArray)
        {
            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine($"Row: {i}");
                Console.WriteLine("**********************");
                Console.WriteLine();

                for (int j = 0; j < 3; j++)
                {

                    Console.WriteLine($"Seat: {numArray[i, j]}");

                }
                Console.WriteLine();
            }
        }
        public static void StacksDemo() { }
        public static void QueuesDemo()
        {
            var que = new Queue<int>();
            que.Enqueue(1);
            que.Enqueue(2);
            que.Enqueue(3);

            while (que.Count > 0)
            {
                Console.WriteLine($"{que.Dequeue()}");
            }
        }
        public static int[] InsertAtStartArray(int[] array, int target)
        {
            int[] newArray = new int[array.Length + 1];//creates a new array with extra space for the new element
            newArray[0] = target;//insert the target element at the start
            for (int i = 0; i < array.Length; i++)//iterates throught the length of the original array
            {
                newArray[i + 1] = array[i]; // this shifts the existing values to the right in the new array
            }


            return newArray;
        }
        public static bool IsAnagram(string word, string word2)//O(N)
        {
            if (word.Length != word2.Length)//if they arent the same size its false.
            {
                return false;
            }
            Dictionary<char, int> charCount = new Dictionary<char, int>();//create dictionary to count the frequency of each charcter in the first string
            foreach (char c in word)
            {
                if (charCount.ContainsKey(c))//iterates through the characters of the first string
                {
                    charCount[c]++;//if the char exists increments the count to 1
                }
                else
                {
                    charCount[c] = 1;//this stores the count of the chars that are found
                }


            }
            foreach (char c in word2)//iterates through the second string
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]--;//if the words match decrease it by 1

                    if (charCount[c] < 0)//if it goes past 0 its false because that means string 2 has more instances of the char
                    {
                        return false;
                    }

                }
                else//return false if not found
                {
                    return false;
                }
            }

            foreach (var count in charCount.Values) //checks the count of the chars, if it is not 0 then you return false because they are suppose to be the same.
            {
                if (count != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static int[] FindTwoSum(List<int> numbers, int target)//O(N)
        {
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();//create dictionary to store the occurences of the complement

            for (int i = 0; i < numbers.Count; i++)//iterate through the list
            {
                int complement = target - numbers[i];//subtrac the target from this index

                if (numToIndex.ContainsKey(complement))//if the dictionary contains the result of target - num[i] 
                {
                    return new int[] { numToIndex[complement], i };//return in an array index of the complament, and current index
                }

                if (!numToIndex.ContainsKey(numbers[i]))
                {
                    numToIndex[numbers[i]] = i;
                }
            }
            return null;

        }

        public static int[] PairProduct(List<int> numbers, int target)//O(N) one loop 
        {
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int complement = target / numbers[i];//divide to get the numbers that multiply together to get the target
                if (numToIndex.ContainsKey(complement))//does it contain a key? no go to the second if, repeat until you have 2 keys of the same
                {
                    return new int[] { numToIndex[complement], i };
                }

                if (!numToIndex.ContainsKey(numbers[i]))
                {
                    numToIndex[numbers[i]] = i;
                }
            }
            return null;
        }

        
            

    }
}
