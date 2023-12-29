namespace OtherExercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine($"[{string.Join(",", UniqueNumber(new int[] { 1, 2, 3, 4 }))}]");
            Console.WriteLine($"[{string.Join(",", UniqueNumber(new int[] { 1, 1, 1, 1, 1 }))}]");
            Console.WriteLine($"[{string.Join(",", UniqueNumber(new int[] { 3, 3, 1, 1, 2, 2 }))}]");
        }

        /*
            Output Unique Numbers
            Definition:
                Given an input file numbersFile. We define numbersFile as containing a list of numbers given the constraints described below. The exact 
                format is not important, but you can assume the file is filled with numbers separated by new lines.
            Exercise:
                Process the input file numbersFile and output only the unique values.
                In a short paragraph describe the general flow, algorithm and/or data structure(s) you would use to soleve the above problem
            Assumptions
                No details needed on how you would read in/stream in the file and output the result
                Order of input file is not guaranteed
                Order of output is not relevant (can be sorted, random, or natural)
            Example 1:
                Input: numbersFile = [1,2,3,4]
                Output: [1,2,3,4]
                Explanation: Entire input file is unique, therefore the output will be the same
            Example 2:
                Input: nums = [1,1,1,1,1]
                Output: [1]
                Explanation: All the values are the same, therefore, there is only one unique input value.
            Example 3:
                Input: nums = [3,3,1,1,2,2]
                Output: [2,3,1]
                Explanation: The only unique values are 1,2,3 and the output order does not matter
            Constraints:
                0 <= [count of numbers in input file] <= 10^9
                0 <= [range of value in input file] <= 2^64 
         */

        static int[] UniqueNumber(int[] intArray)
        {
            //var intArrayTemp = intArray.ToList();
            return intArray.ToList().Distinct().ToArray();
        }

        /*
            Containers / Collections Usage
            Collections/Containers are an integral part of software development. There are many varieties and all programming languages either have them 
            built in, or they can be included from a third-party.
            Choose a language in which you are most comfortable and proficient, and name two collections you have used while developing software. In a 
            few sentences, talk about what the differences are between them and why you would use one over the other.
        */
        static void Collections()
        {
            /*
            Type of Collection:
                List: Represents an ordered collection of elements. Elements in a list are accessed by their index, and the order of elements is preserved.
                Dictionary: Represents a collection of key-value pairs. Each element (value) in a dictionary is associated with a unique key, and you access elements by their keys rather than an index.
            Performance Characteristics:
                List: Suitable for scenarios where the order of elements matters and when you need to iterate through elements sequentially.
                Dictionary: Provides fast access to values based on keys, making it suitable for scenarios where you need to look up values based on specific identifiers.
            Duplicate Keys:
                List: Allows duplicate elements. You can have multiple identical elements in a list.
                Dictionary: Requires keys to be unique. Each key must be unique within a dictionary, and attempting to add a duplicate key will overwrite the existing value.
             */

            List<string> list = new List<string>() { "string1", "string2"};
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("a", 1);
            dic.Add("b", 2);
        }
    }
}
