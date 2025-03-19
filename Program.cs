using System.Diagnostics;

using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string appPath = @"C:\Users\Andrey\source\repos\CaptchaSolutionByIndusi\bin\Debug\net8.0\CaptchaSolutionByIndusi.exe";
        string logFilePath = @"C:\Users\Andrey\Desktop\Логи перезапусков.txt";

        while (true)
        {
            Console.WriteLine("Запуск основного приложения...");
            LogRestartTime(logFilePath);

            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.Start();

            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                Console.WriteLine("Основное приложение завершилось с ошибкой, перезапуск...");
            }
            else
            {
                Console.WriteLine("Основное приложение завершилось нормально.");
                break;
            }
        }
    }

    static void LogRestartTime(string logFilePath)
    {
        try
        {
            string logMessage = $"Перезапуск приложения: {DateTime.Now}\n";
            File.AppendAllText(logFilePath, logMessage);
            Console.WriteLine($"Время перезапуска записано в файл: {logFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
        }
    }
}