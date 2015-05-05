using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ModulesInAction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Модуль в действии";
            Console.WindowWidth = 35;
            Console.BufferWidth = 35;
            //загружаем сборку
            Assembly asm = Assembly.Load(AssemblyName.GetAssemblyName("SampleLibrary.dll"));
            //получаем необходимый модуль этой сборки
            Module mod = asm.GetModule("SampleLibrary.dll");
            //выводим список типов данных, объявленный в текущем модуле
            Console.WriteLine("Объявленные типы данных:");
            foreach (Type t in mod.GetTypes())
                Console.WriteLine(t.FullName);
            //получаем тип данных из сборки
            Type Person = mod.GetType("SampleLibrary.Person") as Type;
            //создаём объект полученного типа данныъ
            object person = Activator.CreateInstance(Person, new object[] { "Иван", "Иванов", 30 });
            Console.WriteLine();
            //вызываем метод Print от созданного объекта
            Person.GetMethod("Print").Invoke(person, null);
        }
    }
}
