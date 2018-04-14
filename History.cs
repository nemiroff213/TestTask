using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvendApp
{
    class History<T>
    {
        List<T> list = new List<T>();
        public void AddObject(T[] obj)
        {
            list.AddRange(obj);
        }
        public T[] GetPreviousElement()
        {
            if (list.Count > 3)
            {
                list.RemoveRange(list.Count - 3, 3);
            }
            Stack<T> stack = new Stack<T>();
            foreach (var item in list)
            {
                stack.Push(item);
            }
            T[] massiv = new T[3];
            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = stack.Pop();
            }
            return massiv;
        }
    }
}
