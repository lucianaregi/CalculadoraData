using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraData
{
   public class Program
    {
        public static void Main(string[] args)
        {

            string data1 = CalcularData("01/03/2021 23:00", "+", 4000);
            string data2 = CalcularData("01/03/2021", "+", 0);
            string data3 = CalcularData("01/03/2021 23:00", "*", 3000);
            string data4 = CalcularData("01/03/2021 23:00", "-", 5600);
            string data5 = CalcularData("01/03/2021 23:00", "-", -2000);

            Console.WriteLine("data1 = " + data1);
            Console.WriteLine("data2 = " + data2);
            Console.WriteLine("data3 = " + data3);
            Console.WriteLine("data4 = " + data4);
            Console.WriteLine("data5 = " + data5);
        }

        public static string CalcularData(string data, string operacao, long valor)
        {
            string date = string.Empty;
            string message = string.Empty;
            bool _data = Helper.Util.DateValidate(data);
            valor = Helper.Util.PositiveNumber(valor);
            bool _valor = Helper.Util.IsValid(valor);
            bool _operacao = Helper.Util.OperatorValidate(operacao);
            try
            {
                if (_data && _valor && _operacao)
                {
                    var op = operacao;
                    var valueDate = data.Split('/');
                    var day = valueDate[0];
                    var month = valueDate[1];
                    var year = valueDate[2].Split(' ')[0];
                    var hour = valueDate[2].Split(' ')[1].Split(':')[0];
                    var minute = valueDate[2].Split(' ')[1].Split(':')[1];

                    double dateJulian = Helper.ConversorCalendario.JulianDate(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(minute), op, valor);
                    
                    date = Helper.ConversorCalendario.JulianToGregorian(dateJulian);
                }
                else
                {
                    message = "Dados inválidos!";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return date;
        }


    }
}
