using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBot
{
    internal class Program
    {
        public static string login, email, password, re_password, hint_question, hint_answer;
        public static int totalautomaton, startfrom;
        static void Main(string[] args)
        {
            Console.Title = "Automaton Create Account";
            SetData();
            Thread.Sleep(2000);
            var driver = new ChromeDriver(@"D:\\kegabutan\\SeleniumBot\\SeleniumBot\\bin\\Debug\\");
            driver.Navigate().GoToUrl("https://www.pb-memories.id/register");

            Thread.Sleep(3000);
            for (int i = startfrom; i < totalautomaton; i++)
            {
                Thread.Sleep(3000);
                IWebElement element = driver.FindElement(By.Id("login"));
                element.SendKeys($"{login}{i}");

                Thread.Sleep(1000);
                IWebElement element2 = driver.FindElement(By.Id("check_username"));
                element2.Click();

                Thread.Sleep(1000);
                IWebElement element3 = driver.FindElement(By.Id("email"));
                element3.SendKeys($"{email}{i}@gmail.com");

                Thread.Sleep(1000);
                IWebElement element4 = driver.FindElement(By.Id("password"));
                element4.SendKeys($"{password}");

                Thread.Sleep(1000);
                IWebElement element5 = driver.FindElement(By.Id("re_password"));
                element5.SendKeys($"{re_password}");

                Thread.Sleep(1000);
                IWebElement element6 = driver.FindElement(By.Id("hint_question"));
                var selectedElement = new SelectElement(element6);
                selectedElement.SelectByValue($"{hint_question}"); // What was your childhood nickname?

                Thread.Sleep(1000);
                IWebElement element7 = driver.FindElement(By.Id("hint_answer"));
                element7.SendKeys($"{hint_answer}");

                Thread.Sleep(1000);
                IWebElement element8 = driver.FindElement(By.Id("submit"));
                element8.Click();

                element.Clear();
                element3.Clear();
                element4.Clear();
                element5.Clear();
                element7.Clear();
            }
            driver.Close();
            Console.WriteLine("Success");
        }

        static void SetData()
        {
            Console.WriteLine("Enter Your Username: ");
            string _username = Console.ReadLine();
            Console.WriteLine("Enter Your Email: ");
            string _email = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string _password = Console.ReadLine();
            Console.WriteLine("Enter Your Confirm Password: ");
            string _re_password = Console.ReadLine();
            Console.WriteLine("Enter Your Hint Question: ");
            string _hint_question = Console.ReadLine();
            Console.WriteLine("Enter Your Hint Answer: ");
            string _hint_answer = Console.ReadLine();
            Console.WriteLine("Enter Your Total Automaton: ");
            int _automaton = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Start From: ");
            int _startfrom = int.Parse(Console.ReadLine());

            login = _username;
            email = _email;
            password = _password;
            re_password = _re_password;
            hint_question = _hint_question;
            hint_answer = _hint_answer;
            totalautomaton = _automaton;
            startfrom = _startfrom;
        }
    }
}
