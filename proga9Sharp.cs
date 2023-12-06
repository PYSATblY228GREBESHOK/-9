using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        DisplayProcesses();
    }
    private static void DisplayProcesses()
    {
        Process[] processes = Process.GetProcesses();
        int index = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите процесс:");
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine($"{i}. {processes[i].ProcessName} - Память: {processes[i].WorkingSet64} байты");
            }
            Console.WriteLine("\nИспользуйте клавиши со стрелками для навигации, Enter для выбора, D для завершения, Delete для завершения всех процессов с тем же именем.");
            Console.WriteLine(index);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (index > 0)
                {
                    index--;
                }
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (index < processes.Length - 1)
                {
                    index++;
                }
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                DisplayProcessDetails(processes[index]);
            }
            else if (keyInfo.Key == ConsoleKey.D)
            {
                try
                {
                    processes[index].Kill();
                    Console.WriteLine("Процесс завершен.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                Console.ReadKey();
            }
            else if (keyInfo.Key == ConsoleKey.Delete)
            {
                try
                {
                    Process[] sameNameProcesses = Process.GetProcessesByName(processes[index].ProcessName);
                    foreach (Process process in sameNameProcesses)
                    {
                        process.Kill();
                    }
                    Console.WriteLine("Процесс завершен.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                Console.ReadKey();
            }
        }
    }

    private static void DisplayProcessDetails(Process process)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Имя: " + process.ProcessName);
            Console.WriteLine("Id: " + process.Id);
            Console.WriteLine("Память: " + process.WorkingSet64 + " байты");
            Console.WriteLine("\nНажмите Backspace, чтобы вернуться к списку процессов, D, чтобы завершить, Delete, чтобы завершить все процессы с тем же именем.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.D)
            {
                try
                {
                    process.Kill();
                    Console.WriteLine("Процесс завершен.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                Console.ReadKey();
            }
            else if (keyInfo.Key == ConsoleKey.Delete)
            {
                try
                {
                    Process[] sameNameProcesses = Process.GetProcessesByName(process.ProcessName);
                    foreach (Process proc in sameNameProcesses)
                    {
                        proc.Kill();
                    }
                    Console.WriteLine("Процессы завершены.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                Console.ReadKey();
            }

            else if (keyInfo.Key == ConsoleKey.Enter)
            {

            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.D)
            {
                try
                {
                    process.Kill();
                    Console.WriteLine("Процесс завершен.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                Console.ReadKey();
            }
            else if (keyInfo.Key == ConsoleKey.Delete)
            {
                try
                {
                    Process[] sameNameProcesses = Process.GetProcessesByName(process.ProcessName);
                    foreach (Process p in sameNameProcesses)
                    {
                        p.Kill();
                    }
                    Console.WriteLine("Процессы завершены.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                Console.ReadKey();
            }
        }
    }
}и 