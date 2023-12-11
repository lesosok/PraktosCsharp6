using System.IO;
using Практическая__6;

Console.WriteLine("Введите путь до файла (вместе с названием), который вы хотите открыть\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
string path = Console.ReadLine();
FileSaver fileSaver = new FileSaver();

Console.Clear();
Console.WriteLine("Сохранить файл в одном из трёх форматов (txt, json, xml) - F1. Закрыть программу - Escape\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

Figure figure = fileSaver.FileReader(path);

Console.WriteLine($"{figure.figurename}");
Console.WriteLine($"{figure.width}");
Console.WriteLine($"{figure.height}");

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.F1)
    {
        Console.Clear();
        Console.WriteLine("Введите путь до файла (вместе с названием), куда вы хотите сохранить текст\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
        string savepath = Console.ReadLine();
        fileSaver.Filesaver(figure, savepath);
        Console.WriteLine("Успешно сохранено! Спасибо что воспользовались текстовым редактором!");
        break;
    }

    else if (key.Key == ConsoleKey.Escape)
    {
        break;
    }

    else
    {
        Console.WriteLine("Неправильный ввод. Повторите попытку");
        continue;
    }
}