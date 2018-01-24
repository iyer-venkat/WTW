using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WTW
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[,] arrClaims;
            Dictionary<string, decimal[,]> claimsDict = new Dictionary<string, decimal[,]>();

            using (StreamReader fileReader = new StreamReader("C:\\Venkat\\wtw.txt"))
            {
                fileReader.ReadLine();  //Header
                var sLine = "";
                int minYear = Int32.MaxValue, maxYear = Int32.MinValue;
                int originYear, devYear;
                var productName = "";
                while (!String.IsNullOrEmpty(sLine = fileReader.ReadLine()))
                {
                    Regex inputRegex = new Regex(@"^[\w\-\s]+, \d{4}, \d{4}, \d*.\d*$", RegexOptions.Compiled);
                    if (!inputRegex.Match(sLine).Success)
                    {
                        Console.WriteLine("No Match?!?");
                        break;
                    }
                    originYear = Convert.ToInt32(sLine.Split(new string[] { ", " }, StringSplitOptions.None)[1]);
                    minYear = Math.Min(originYear, minYear);
                    maxYear = Math.Max(originYear, maxYear);
                }
                Console.WriteLine($"Origin Year={minYear} & Development Year={maxYear}");
                Console.WriteLine($"{minYear}, {maxYear - minYear + 1}");

                fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
                fileReader.ReadLine();
                arrClaims = new decimal[maxYear - minYear + 1, maxYear - minYear + 1];
                while (!String.IsNullOrEmpty(sLine = fileReader.ReadLine()))
                {
                    if (productName != "" && productName != sLine.Split(new string[] { ", " }, StringSplitOptions.None)[0])
                    {
                        claimsDict.Add(productName, arrClaims);
                        arrClaims = new decimal[maxYear - minYear + 1, maxYear - minYear + 1];
                    }
                    originYear = Convert.ToInt32(sLine.Split(new string[] { ", " }, StringSplitOptions.None)[1]);
                    devYear = Convert.ToInt32(sLine.Split(new string[] { ", " }, StringSplitOptions.None)[2]);
                    arrClaims[originYear - minYear, devYear - originYear] = Convert.ToDecimal(sLine.Split(new string[] { ", " }, StringSplitOptions.None)[3]);

                    productName = sLine.Split(new string[] { ", " }, StringSplitOptions.None)[0];
                }
                claimsDict.Add(productName, arrClaims);
            }

            var outputClaim = new StringBuilder();
            decimal cumulativeClaim = 0;
            foreach (var dict in claimsDict)
            {
                outputClaim.Append(dict.Key + ", ");
                for (int k = 0; k < dict.Value.GetLength(0); k++)
                {
                    cumulativeClaim = 0;
                    for (int l = 0; l < dict.Value.GetLength(1) - k; l++)
                    {
                        cumulativeClaim += dict.Value[k, l];
                        outputClaim.Append(cumulativeClaim + ", ");
                    }
                }
                outputClaim.Append(Environment.NewLine);
            }
            Console.WriteLine(outputClaim.ToString());
            Console.ReadLine();
            return;
        }
    }
}
