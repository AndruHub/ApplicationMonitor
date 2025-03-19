using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string appPath = @".exe"; // поменять
        string logFilePath = @".txt"; // поменять

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
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
        }
    }
}