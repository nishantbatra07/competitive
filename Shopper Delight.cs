// Shopping Options:  An Amazon Customer wants to buy a pair of jeans, a pair of shoes, a skirt, and a top 
// but has a limited budget in dollars. Given different pricing options for each product, determine how 
// many options our customer has to buy 1 of each product. You can not spend more money than the budgeted amount.
// priceOfJean = [2,3]
// priceOfShoes = [4]
// priceOfSkirts = [2,3]
// priceofTops = [1,2]

// The customer must buy shoes for 4 dollars since there is only one option. 
// This leaves 6 dollars to spend on the other 3 items. Combination of prices 
// paid for jeans, skirts, and tops respectively that add up to 6 dollars or 
// fewer [2,2,2], [2,2,1], [3,2,1], [2,3,1].  

// There are 4 ways the customer can purchase all 4 items.

// Functional Description 

// Complete the getNumberOfOptions function in the editor below. The function must return an integer that represents the number of options present to buy the four items. getNumberOfOptions has 5 parameters:

// List<Integer> priceOfJeans : An integer array list that contains the price of the pairs of jeans available.
// List<Integer> priceOfShoes: An integer array list that contains the price of the pairs of shoes available.
// List<Integer> priceOfSkirts: An integer array list that contains the price of the skirts available.
// List<Integer> priceOfTops : An integer array list that contains the price of the tops available.
// int dollars: The total number of dollars available to shop with.


// SOLUTION :  WE ARE DOING THIS APPROACH TO AVOID O(N^4). THIS WILL BE NEAR TO O(N^2)
// PLAN :  Create combination of two lists by merging two lists . #STEP 1
//         Check for bigger list and put it in the outer loop sorted in ascending.
//         Sort inside loop list in descending #STEP 2
//         Create entry controlled while loop to reduce complexity and set limit variable to look out
//         with condition to check for out of budget and it will come outside once it starts coming inside 
//         budget and afterward all could be bought         
//
//         IN THIS EXAMPLE: Outside :  [3,4,4,5]   
//                  Inside : [7,6]
//
//         Outside Iteration 1:
//                     Remaining = 10 -3 = 7
//         Limit = 0 (We can buy both as per the budget) 
//         Ways + = (Lenght of Second List - Limit) = 2
//
//         Outside Iteration 2:
//                     Remaining = 10 -4 = 6
//         Limit = 1 (We can only buy 1 as per the budget) 
//         Ways + = (Lenght of Second List - Limit) = 1
//
//         Outside Iteration 3:
//                     Remaining = 10 -4 = 6
//         Limit = 1 (We can only buy 1 as per the budget) 
//         Ways + = (Lenght of Second List - Limit) = 1
//
//         Outside Iteration 4:
//                     Remaining = 10 -5 = 5
//         Limit = 2 (We cannot  buy anything as per the budget) 
//         Ways + = (Lenght of Second List - Limit) = 0

using System;
using System.Collections.Generic;

public class Solution {
    public int GetWays(int[] priceOfJean,int[] priceOfShoes,int[] priceOfSkirts,int[] priceOfTops,int dollars) {
        int ways= 0;

        
        List<int> jeans_shoes = new List<int>();
        List<int> skirts_tops = new List<int>();
        List<int> CombinationA = new List<int>();
        List<int> CombinationB = new List<int>();

        // STEP 1

        foreach(var jeans in priceOfJean)
        {
            foreach(var shoes in priceOfShoes)
            {
                jeans_shoes.Add(jeans+shoes);
            }
        
        }
        foreach(var skirts in priceOfSkirts)
        {
            foreach(var tops in priceOfTops)
            {
               skirts_tops.Add(skirts+tops);
            }
        }

        
        if (jeans_shoes.Count < skirts_tops.Count)
        {
            CombinationB = jeans_shoes;
            CombinationA = skirts_tops;
            
        }
        else
        {
            CombinationB = skirts_tops; // [3,4,4,5]
            CombinationA = jeans_shoes; // [7,6]
        }
        CombinationA.Sort((a, b) => a.CompareTo(b));
        CombinationB.Sort((a, b) => b.CompareTo(a));
        
        // OUTER LOOP TO BE OF MAX LIST COUNT STEP 2

        foreach(var combA in CombinationA)
        {
            int limit = 0;
            // CHECK THE REMAINING BUDGET
            int remaining = dollars - combA;

            remaining = dollars-combA;

            //
            while((limit < CombinationB.Count) && (CombinationB[limit]>remaining))
            {

                limit+=1;
            }

            ways += (CombinationB.Count - limit); 
        }
        return ways;
    }
    public static void Main()
    {
        int[] priceOfJean = {2,3};
        int[] priceOfShoes = {4,1};
        int[] priceOfSkirts = {2,3};
        int[] priceOfTops = {1,2};

 		Solution obj = new Solution();       
        Console.WriteLine(obj.GetWays(priceOfJean,priceOfShoes,priceOfSkirts,priceOfTops,10));
    }
}