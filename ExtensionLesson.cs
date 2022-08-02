using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHints
{
    public static class IntegerExtension
    {
        private static int TreeNode(int l, int r)
        {
            if (l == r) return l;
            if (r - l == 1) return l * r;
            int m = (l + r) / 2;
            return TreeNode(l, m) * TreeNode(++m, r);
        }

        public static int Phactorial(this int num)
        {
            if (num < 0) return 0;
            if (num == 0 || num == 1) return 1;
            if (num == 2) return 2;
            return TreeNode(2, num);
        }
    }

    internal class ExtensionLesson : ILesson
    {
        public void StartLesson()
        {
            int num = 10;

            Console.WriteLine(num.Phactorial());
        }
    }
}
