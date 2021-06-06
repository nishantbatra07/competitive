public class Solution {
    public int MaxSubArray(int[] nums) {
        int size = nums.Length;
        int max_so_far = int.MinValue,
            max_ending_here = 0;
        Console.WriteLine(max_so_far);
 
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("ITERATION: "+i);
            Console.WriteLine("max_ending_here:"+max_ending_here);
            max_ending_here = max_ending_here + nums[i];
            Console.WriteLine("max_ending_here after adding nums[i]: "+max_ending_here);
            Console.WriteLine("max_so_far: "+max_so_far);
            Console.WriteLine("----------------");
            if (max_so_far < max_ending_here)
                max_so_far = max_ending_here;
            /// if max_ending_here is less than 1 lets say for example in [2,3,4,-4,-8,4,6]
            /// max_ending_here will go like : 2,5,9,5,-3 (reset to 0 here),4,10
            /// max_so_far will go like:       2,5,9,9, 9 (_______________),9,10
            /// we did a reset at -3 as it has become negative and if added in further numbers, 
            /// it will definitely lower the sum so we have to start afresh 
            if (max_ending_here < 0)
                max_ending_here = 0;
        }
         
        return max_so_far;
    }
}