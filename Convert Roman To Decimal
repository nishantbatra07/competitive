public class Solution 
{
    public int RomanToInt(string s) 
    {
        Dictionary<char,int> mySet = new Dictionary<char,int>
        {
            {'I',1},
            {'V',5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000}
        };
        
        int num = mySet[s[0]];
        for(int i = 1; i< s.Length; i++)
        {
            num += mySet[s[i]];
            if(mySet[s[i]] > mySet[s[i-1]])
            {
                num = num - (2 * mySet[s[i-1]]);
            }
        }
        return num;
    }
}
