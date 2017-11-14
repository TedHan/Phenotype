namespace Phenotype.Utils
{
    public class SpecialRulesHelper
    {
        public static string Transform(string input)
        {
            string output = string.Empty;

            if (input.Contains("黑色红色系"))
                output = input.Replace("黑色红色系", "红色");
            else if (input.Contains("巧克力色红色系"))
                output = input.Replace("巧克力色红色系", "红色");
            else if (input.Contains("肉桂色红色系"))
                output = input.Replace("肉桂色红色系", "红色");
            else if (input.Contains("蓝色红色系"))
                output = input.Replace("蓝色红色系", "乳色");
            else if (input.Contains("淡紫色红色系"))
                output = input.Replace("淡紫色红色系", "乳色");
            else if (input.Contains("米黄色红色系"))
                output = input.Replace("米黄色红色系", "乳色");
            else if (input.Contains("黑色黑色系"))
                output = input.Replace("黑色黑色系", "黑色");
            else if (input.Contains("巧克力色黑色系"))
                output = input.Replace("巧克力色黑色系", "巧克力色");
            else if (input.Contains("肉桂色黑色系"))
                output = input.Replace("肉桂色黑色系", "肉桂色");
            else if (input.Contains("蓝色黑色系"))
                output = input.Replace("蓝色黑色系", "蓝色");
            else if (input.Contains("淡紫色黑色系"))
                output = input.Replace("淡紫色黑色系", "淡紫色");
            else if (input.Contains("米黄色黑色系"))
                output = input.Replace("米黄色黑色系", "米黄色");
            else if (input.Contains("黑色三色系"))
                output = input.Replace("黑色三色系", "红黑三色");
            else if (input.Contains("巧克力色三色系"))
                output = input.Replace("巧克力色三色系", "巧克力色红色三色");
            else if (input.Contains("肉桂色三色系"))
                output = input.Replace("肉桂色三色系", "肉桂色红色三色");
            else if (input.Contains("蓝色三色系"))
                output = input.Replace("蓝色三色系", "蓝乳三色");
            else if (input.Contains("淡紫色三色系"))
                output = input.Replace("淡紫色三色系", "淡紫色乳色三色");
            else if (input.Contains("米黄色三色系"))
                output = input.Replace("米黄色三色系", "米黄色乳色三色");
            else
                output = input;

            return output;
        }
    }
}