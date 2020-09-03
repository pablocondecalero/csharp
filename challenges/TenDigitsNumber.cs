//Pablo Conde - August 2020
/*Find the smallest number with all the digits (0,1,2...9) 
 * which is divisible by all these digits except 0 */

using System;

class TenDigitsNumber

{
    static void Main()
    {
        /*the greatest common divisor of 1, 2, 3, 4, 5, 6, 7, 8, 9*/
        int prod = 5 * 7 * 8 * 9; 

        /*Search of first number which multiplied by prod
         * results a number of 10*/
        int multiplyNum = (int) Math.Floor(Math.Pow(10, 9) / prod) + 1;
        
       long result = 1;
       string resultChain = "";
       bool found = false;
       do
       {
           result = prod * multiplyNum;
           resultChain = result.ToString();
           
           //Checking the number contains all the digits
           if(resultChain.IndexOf('0') != -1 &&
              resultChain.IndexOf('1') != -1 &&
              resultChain.IndexOf('2') != -1 &&
              resultChain.IndexOf('3') != -1 &&
              resultChain.IndexOf('4') != -1 &&
              resultChain.IndexOf('5') != -1 &&
              resultChain.IndexOf('6') != -1 &&
              resultChain.IndexOf('7') != -1 &&
              resultChain.IndexOf('8') != -1 &&
              resultChain.IndexOf('9') != -1)
           {
               found = true;
           }
           
           multiplyNum++;
        }
        while(!found);
        
       Console.WriteLine("The number is: " + result);
    }
}
