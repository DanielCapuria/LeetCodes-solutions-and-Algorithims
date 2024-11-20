using HumanModels;
using System.Net.Cache;
using System.Reflection.Metadata.Ecma335;
using System.IO;
using System.Numerics;
using System.Text;
using System;
using System.Linq;
using System.ComponentModel.Design;

namespace Week7
{
    public class Program
    {
        public static void Main(string[] args)

        {


        }
        public static int LeetCodeRomanToInt(string s)
        {
            int answer = 0;
            int num = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                switch (s[i])
                {
                    case 'I':
                        num = 1;
                        break;
                    case 'V':
                        num = 5;
                        break;
                    case 'X':
                        num = 10;
                        break;
                    case 'L':
                        num = 50;
                        break;
                    case 'C':
                        num = 100;
                        break;
                    case 'D':
                        num = 500;
                        break;
                    case 'M':
                        num = 1000;
                        break;
                }
                if (4 * num < answer)
                {
                    answer -= num;
                }
                else
                {
                    answer += num;
                }

            }

            return answer;
        }
      
        public static int LeetCodeRemoveElement(int[] nums, int val)
        {
            var index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }

            return index;
        }
        //public static void FindBucketData(int Id)
        //{
        //    List<Bucket<int, string>> Buckets = new List<Bucket<int, string>>();
        //    List<Bucket<bool, string>> Buckets2 = new List<Bucket<bool, string>>();

        //    Buckets.Add(new Bucket<int, string>(0, "Sand"));
        //    Buckets.Add(new Bucket<int, string>(1, "Metal"));
        //    Buckets.Add(new Bucket<int, string>(2, "Water"));
        //    Buckets.Add(new Bucket<int, string>(3, "Glass"));
        //    Buckets.Add(new Bucket<int, string>(4, "Paper"));
        //    Buckets.Add(new Bucket<int, string>(5, "Dirt"));
        //    int index = Id;
        //    for (int i = 0; i < Buckets.Count; i++)
        //    {
        //        if (Buckets[i] == Buckets[index])
        //        {
        //            Console.WriteLine(Buckets[i]);
        //        }
        //    }


        //}
        public bool LeetCodeIsPalindrome(int x)
        {    //find solution in english (not code)
             //is there anything that would immediatly not work? example negative numbers.(edge case)

            if (x < 0)
            {
                return false;
            }
            if (x < 10)
            {
                return true;
            }
            //find solution in english (not code)
            string s = x.ToString();//
            int i = 0;//beginning index
            int j = s.Length - 1;//last index
            while (i < j)//while beginning index is less then end index, keep going until the indexs meet
            {
                if (s[i] != s[j])//s[i] left hand picking up number, s[j] right hand picking up number on the end
                {
                    return false;//return = exit because the condition was met.
                }
                i++;//left hand proceeds right only if it is equal to the right hand
                j--;//right hand goes left to next number if it is equal to left hand
            }
            return true;
        }
        public void LeetCodeMoveZeroes(int[] nums)
        {
            //move all the 0s to the end while maintaning order
            //what algo would it take?
            int index = 0;//create a pointer that starts a new index

            for (int i = 0; i < nums.Length; i++)//iterate through the array
            {
                if (nums[i] != 0)//focuses on numbers that are not 0.
                {
                    nums[index] = nums[i];//moves non-zero element to position index;
                    index++;//increment index for the next non zero.
                }
            }
            //now index points to the first position where zero should be placed.
            for (int i = index; i < nums.Length; i++) //iterate again to find the 0s.
            {
                nums[i] = 0; // fills remaining position with zeros.
            }
            return;

        }
        public void LeetCodeMerge(int[] nums1, int m, int[] nums2, int n)
        {
            //return to nums1 since it has the length of m + n.
            int index = 0; //set a variable for new index to store the array.
            for (int i = m; i < nums1.Length; i++)//iterate throught he array starting at m index.
            {

                nums1[i] = nums2[index]; //since we started at m index it adds nums 2 to the end of our array
                index++;//iterates to next number

            }
            Array.Sort(nums1);//sort in order


        }
    
        public static bool LeetCodeCanConstruct(string ransomNote, string magazine)
        {
            char[] chars = ransomNote.ToCharArray();
            //are their multiples in the ransomnote?
            char[] magazineChars = magazine.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                if (chars[i] == magazineChars[i])
                {
                    i++;
                    return true;

                }

            return false;
        }
        public static bool LeetCodeCanConstruct2(string ransomNote, string magazine)
        {
            int matchCount = 0;
            foreach (char c in magazine)
                if (ransomNote.Contains(c))
                {
                    matchCount++;
                    if (matchCount >= 2)
                    {
                        return true;
                    }
                }

            return false;

        }

    
        public string LeetCodeMaximumOddBinaryNumber(string s)
        {
            int originalLength = s.Length;
            s = s.Replace("0", "");
            int numOfOnes = s.Length;

            if (numOfOnes == 1)
            {
                return "1".PadLeft(originalLength, '0');
            }
            else
            {
                return "1".PadRight(numOfOnes - 1, '1') + "1".PadLeft(originalLength - numOfOnes + 1, '0');
            }

            //what do we know about the string?
            //assume only contains 1s and 0s
            //length of string we know

            //what do we know about what matter from that string?
            //need to know number of 1s.
            //what do we need to know?

        }

        public int LeetCodeLengthOfLastWord(string s)
        {
            //need to find and return the length of the last word in the string
            //need to find and return the length of the last word in the string

            return s.Trim().Split(' ').Last().Length;
            //trim the string "s" in the front and end of all white space,
            //.Split to convert the words into an array. .Last is a LINQ to get the last index of the array
            //.Length gets the length of the last word

        }
        public int[] LeetCodeTwoSum(int[] nums, int target)
        {
            //find 2 indexs in the array that equal the target
            //find 2 indexs in the array that equal the target
            for (int i = 0; i < nums.Length; i++)//initialize a for loop to iterate through through the indexs
            {
                for (int j = i + 1; j < nums.Length; j++)//initialize a for loop to iterate through through the indexs to compare to the first forloop
                {
                    if (nums[i] + nums[j] == target)//if this index in the I forloop + the index in the j for loop equals the target
                    {

                        int[] index = { i, j };//create a new array that stores those indexs
                        return index;//return this index
                    }
                }
            }
            return nums;//will return the new array since its inside the loop.
        }
        public int LeetCodeXORSingleNumber(int[] nums)
        {
            //need to find the number or index that isnt dsplayed more then once
            //we need to iterate through the array and get rid of everything that is displayed twice and return the number that isnt
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }
            return result;
        }

        public int[] LeetCodePlusOne(int[] digits)
        {
            //need to iterate through the arry and add + 1 to the final index
            int[] newArray = new int[digits.Length + 1];//need to make a new array to the size of the old one + 1
                                                        //because if it is just 9 or 9s it becomes 2 digits

            for (int i = digits.Length - 1; i >= 0; i--)//iterate through the array from the end because we want to add to the end
            {
                if (digits[i] < 9)//if digits i is less then 9 
                {
                    digits[i]++;//we add to the last index and immediatly return
                    return digits;//we immediatly return here because we do not need to go through the rest of the loop
                }
                digits[i] = 0;//if it is 9 we make it 0 because 9 + 1 = 0

            }
            newArray[0] = 1;//set index 0 to 1 because 9 + 1 = 1,0
            return newArray;//returns the new array

            return digits;
        }
        public void LeetCodeReverseString(char[] s)
        {
            //reverse the array so it goes backwards.
            //for the length of the array, display from the end index to the first index
            //display the array starting at that index
            //FOR TEST CASE HELLO
            int left = 0;//this starts at index 0 which would be H
            int right = s.Length - 1;//this starts at the last index which is o

            while (left < right)//whil the left index is less then the right
            {
                var temp = s[left];//temp var is equal to s[0] which is H
                s[left] = s[right];//now we swap s[0] "h" equals s[4] "o"

                s[right] = temp;//now we set s[4] to equal temp which is h so it looks like oellh

                left++;//iterate the left pointer towards the end
                right--;//traverse back to the start.

            }
        }
        public string LeetCodeReverseVowels(string s)
        {
            string[] vowels = { "a", "e", "i", "o", "u" };
            int left = 0;
            int right = s.Length - 1;



            return string.Empty;
        }
        public static char LeetCodeNextGreatestLetter(char[] letters, char target)
        {
            //find the letter that is close to the target if its a letter such as z return the first index
            //input is a char[] array our output is what is close to target

            for (int i = 0; i < letters.Length; i++)//iterate throug the char array
            {
                if (letters[letters.Length - 1] < target)//if the letters in the array are less then target 
                {
                    return letters[0];
                }
                if (target < letters[i])//if target is less then the index vaLUE
                {
                    Console.WriteLine(letters[i]);
                    return letters[i];//put that value here

                }

            }

            return letters[0];//return that value because its the only value and going to be in position 0
        }
        public static bool IsPrime(int target)
        {
            for (int i = 2; i <= Math.Sqrt(target); i++)//iterate to the square root check if target is divisible by any number
            {
                if (target % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
       
        public bool BruteForceLeetCodeContainsDuplicate(int[] nums)
        {
            //return true if any elements in the array appear at least twice
            //for every number in the array iterate to the end
            //compare index to the rest of the array if index is equal to another index return true

            for (int i = 0; i < nums.Length - 1; i++)//create a loop to iterate 
            { //possibly use a 2 pointer method to compare this iteration to the other
                for (int j = i + 1; j < nums.Length; j++)//create a second loop to iterate through and compare the index in the first loop to the second loop.
                {
                    if (nums[i] == nums[j])//now compare if they are equal
                    {
                        return true;//returns true
                    }
                }

            }




            return false;//return false if every element is distinct and doesnt duplicate
        }
        public int LeetCodeCommonFactors(int a, int b)
        {
            //find how many ints are divisble by a and b
            int count = 0;


            for (int i = 1; i <= Math.Min(a, b); i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    count++;
                }

            }
            return count;
        }

        //public ListNode LeetCodeRemoveNthFromEnd(ListNode head, int n)
        //    {
        //        int size = 0;
        //        ListNode temp, removedOne;
        //        temp = head;
        //        removedOne = null;
        //        while (temp != null)
        //        {
        //            temp = temp.next;
        //            size++;
        //        }
        //        if (size == 1) return null;
        //        else if (size == n)
        //        { return head.next; }
        //        temp = head;

        //        while (size != n)
        //        {
        //            removedOne = temp;
        //            temp = temp.next;
        //            size--;
        //        }
        //        removedOne.next = temp.next;
        //        return head;


        //    }
        //}
    }




}


