using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота9Мехоношин
{


    class Money
    {
        static int count = 0;
        int rubles;
        int kopeks;

        public int Rubles
        {
            set
            {
                if (value>=0)
                {
                    rubles = value;
                }
                else
                {
                    rubles = 0;
                }

            }

            get { return rubles; }
        }

        public int Kopeks
        {
            set
            {
                if (value < 100)
                {
                    if (value < 0)
                    {
                        kopeks = 0;
                    }
                    else
                    {
                        kopeks = value;
                    }

                }
                else
                {
                    kopeks = value % 100;
                    rubles = rubles + ((value - kopeks) / 100);
                }
            }
            get { return kopeks; }
        }


        public Money(int irubles, int ikopeks)
        {
            Rubles = irubles;
            Kopeks = ikopeks;
            count++;
        }

        public Money ()
        {
            Rubles = 0;
            Kopeks = 0;
            count++;
        }

        public void MoneyShow (Money m1)
        {
            Console.Write(m1.Rubles);
            Console.Write(".");
            if (m1.Kopeks > 9)
            {
                Console.Write(m1.Kopeks);
            }
            else
            {
                Console.Write(0);
                Console.Write(m1.Kopeks);
            }


        }

        public void CountObjects()
        {
            Console.Write("Всего на данный момент было создано ");
            Console.Write(count);
            Console.Write(" объектов класса Money");
        }

        public Money Minus (Money m1, Money m2)
        {
            Money m3 = new Money ();
            int temp1, temp2, temp3;

            temp1 = m1.Rubles * 100 + m1.Kopeks;
            temp2 = m2.Rubles * 100 + m2.Kopeks;

            temp3 = temp1 - temp2;


                m3.Kopeks = temp3 % 100;
                m3.Rubles = (temp3 - m3.kopeks) / 100; 


            return m3;
                        
        }

        public static Money operator ++ (Money m1)
        {

            m1.Kopeks++;

            return m1;
        }

        public static Money operator --(Money m1)          
        {
          //  Money m2 = new Money();

            if (m1.Kopeks == 0)
            {
                m1.Kopeks = 99;
                m1.Rubles--;
            }
            else
            {
                m1.Kopeks++;
            }

          
            return m1;


          
        }


        public int RublesInt (Money m1)
        {
            return m1.Rubles;
        }


        public double KopeksDouble (Money m1)
        {
            return ((Convert.ToDouble(m1.kopeks)) / 100);
        }


        public static Money operator + (Money m1, int irubles)
        {
            Money m2 = new Money();

            m1.Rubles = m1.Rubles + irubles;
            m2 = m1;

            return m2;
        }


        public static Money operator +(int irubles, Money m1)
        {
            Money m2 = new Money();


            m1.Rubles = m1.Rubles + irubles;
            m2 = m1;

            return m2;
        }


        public static Money operator -(Money m1, int irubles)
        {
            Money m2 = new Money();


                m1.Rubles = m1.Rubles - irubles;


            m2 = m1;

            return m2;
        }


        public static Money operator -(int irubles, Money m1)
        {
            Money m2 = new Money();
            int temp1, temp2, temp3;


            temp1 = irubles*100;
            temp2 = m1.Rubles * 100 + m1.Kopeks;

            temp3 = temp1 - temp2;


                m2.Kopeks = temp3 % 100;
                m2.Rubles = (temp3 - m2.kopeks) / 100;


            return m2;
        }

    }



    class Program 
    {

        public static Money MinusFunction(Money m1, Money m2)
        {
            Money m3 = new Money();
            int temp1, temp2, temp3;

            temp1 = m1.Rubles * 100 + m1.Kopeks;
            temp2 = m2.Rubles * 100 + m2.Kopeks;

            temp3 = temp1 - temp2;


                m3.Kopeks = temp3 % 100;
                m3.Rubles = (temp3 - m3.Kopeks) / 100;


            return m3;

        }


        static void Main(string[] args)
        {

            Console.SetWindowSize(105, 39);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("Вас приветствует программа по работе с классом Money.");

            Money m1 = new Money (10,0);
            Money m2 = new Money(5, 99);
            Money m3 = new Money();

            Console.WriteLine();

            Console.WriteLine("Для начала, создадим три объекта класса Money:");

            Console.Write("Money m1 = ");
            m1.MoneyShow(m1);
            Console.WriteLine();
            Console.Write("Money m2 = ");
            m2.MoneyShow(m2);
            Console.WriteLine();
            Console.Write("Money m3 = ");
            m3.MoneyShow(m3);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Присвоим m3 значение выражения m1 - m2, воспользовавшись методом класса:");
            Console.Write("m3 = ");

            m3 = m3.Minus(m1, m2);
            m3.MoneyShow(m3);
            Console.WriteLine();

            Console.WriteLine("А теперь то же самое, но при помощи статической функции:");
            Console.Write("m3 = ");

            m3 = MinusFunction(m1, m2);
            m3.MoneyShow(m3);
            Console.WriteLine();

            Console.WriteLine("как видите, ничего не изменилось - метод класса и статическая функция работают одинаково.");
            Console.WriteLine();
            Console.WriteLine("Теперь поработаем с унарными операциями: сперва вычтем 1 копейку из объекта m1:");
            Console.Write("m1 = ");

            m1--;
            m1.MoneyShow(m1);
            Console.WriteLine();

            Console.WriteLine("А затем прибавим 1 копейку к объекту m2:");
            Console.Write("m2 = ");

            m2++;
            m2.MoneyShow(m2);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Отлично. Сейчас пройдемся по операциям приведения - сначала получим целое число рублей в m2:");
            Console.Write("В m2 всего ");

            Console.Write(m2.RublesInt(m2));
            Console.WriteLine(" рублей.");

            Console.WriteLine("А затем - число копеек (рубли отбрасываются) в m1 в формате double:");
            Console.Write("В m1, если отбросить целые рубли, останется всего ");

            Console.Write(m1.KopeksDouble(m1));
            Console.WriteLine(" рублей");

            Console.WriteLine();

            Console.WriteLine("И наконец, бинарные операции. Во-первых, создадим еще два объекта класса Money - m4 и m5:");
            Money m4 = new Money();
            Money m5 = new Money();

            Console.WriteLine("Теперь присвоим m4 значение m1 + 5 (программа интерпретирует 5 как число рублей):");
            Console.Write("m4 = ");

            m4 = m1 + 5;
            m4.MoneyShow(m4);
            Console.WriteLine();

            Console.WriteLine("И присвоим m5 значение 15 - m2 (программа интерпретирует 15 как число рублей):");
            Console.Write("m5 = ");

            m5 = 15 - m2;
            m5.MoneyShow(m5);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Теперь пусть наша программа сосчитает, сколько объектов класса Money было создано за время ее работы.");
            m5.CountObjects();
            Console.WriteLine();
            Console.WriteLine("Пять из этих объектов были созданы в теле программы вручную, и еще по одному за каждую из шести проделанных операций, не считая унарных. 5 + 6 = 11");
            Console.WriteLine("Работа с программой завершена. Для продолжения нажмите любую клавишу.");
            Console.ReadLine();



        }
    }
}
