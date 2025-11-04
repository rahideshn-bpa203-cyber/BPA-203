using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Types.Models
{
    internal class Library<T>
    {
        public string Name { get; set; }
        public List<T> Items { get; set; }

        public Library(string name)
        {
            Name = name;
            Items = new List<T>();
        }

        public void Add(T item)
        {
            Items.Add(item);
            Console.WriteLine("Elave edildi");
        }

        public void Remove(T item)
        {
            Items.Remove(item);
            Console.WriteLine("Silindi");
        }

        public List<T> GetAll() => Items;

        public int Count() => Items.Count;

        public T? FindByIndex(int index)
        {
            if (index >= 0 && index < Items.Count)
                return Items[index];
            else
                return default;
        }
    }
}

    

