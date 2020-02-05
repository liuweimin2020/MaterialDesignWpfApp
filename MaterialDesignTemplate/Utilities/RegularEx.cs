using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MaterialDesignTemplate.Utilities
{
    public static class RegularEx
    {
        //====== 元字符 ======
        // .   除\n以外的任意的单个字符。例如a.b
        // []  字符组,[]表示在字符组中罗列出来的字符，任意取单个.例如a[xyz]b, a[a-z]b, a[a-zABC]b,a[a-zA-Z]b,a[a-zA-Z0-9样本]b
        // a[.abc]b  .出现在字符组中表示一个普通的. 并不是一个元字符
        // | 表示“或”的意思，例如 a(x|y)b ,z|food表示匹配z或者food
        // () 表示改变优先级，或者提取组
        // * 表示限定前面出现的表达式出现0次或者多次




    }
}
