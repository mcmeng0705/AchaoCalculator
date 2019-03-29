using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace ConsoleApp3
{
    public class Program
    {
        public static string makeformula()//创建等式
        {
            StringBuilder sb = new StringBuilder();
            String[] op = { "+", "-", "*", "/" };
            var seed = Guid.NewGuid().GetHashCode();
            Random rd = new Random(seed);
            int fuahogeshu = rd.Next(1, 3);
            int i = 0;
            int shu1 = rd.Next(0, 101);
            sb.Append(shu1);
            while (i <= fuahogeshu)
            {
                int fuhao = rd.Next(0, 4); // 生成符号
                int shu2 = rd.Next(0, 101);
                sb.Append(op[fuhao]).Append(shu2);
                i++;
            }
            return sb.ToString();

        }
        public static string Solve(string a)
        {
            DataTable dt = new DataTable();
            Object ob;
            ob = dt.Compute(a, "");
            while (ob.ToString().Contains(".") || a.Contains("/0") || Convert.ToInt32(ob) < 0)
            {
                a = makeformula();
                ob = dt.Compute(a, "");
            }
            return a + "=" + ob.ToString();
        }
        public static void Main(string[] args)
        {
 
            int n;
            Console.WriteLine("请输入你想产生几道题");
            n = int.Parse(Console.ReadLine());
            StreamWriter sw = new StreamWriter(@"C:\Users\dell\Documents\GitHub\AchaoCalculator\qmc.txt");
            for (int i = 0; i < n; i++)
            {
                string a = makeformula();
                String ret = Solve(a);
                Console.WriteLine(ret);

                sw.WriteLine(ret);

                a = null;
                ret = null;
            }
            sw.Close();
    
        }
    }
}

