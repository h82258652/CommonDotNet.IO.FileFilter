using CommonDotNet.IO.Properties;
using System;
using System.Text.RegularExpressions;

namespace CommonDotNet.IO
{
    /// <summary>
    /// 用于 FileDialog 类及其之类的 Filter 属性的文件过滤。
    /// </summary>
    public class FileFilter : FileFilterBase
    {
        private string _description;

        private string _extension;

        /// <summary>
        /// 创建一个新的文件过滤。
        /// </summary>
        /// <param name="extension">文件过滤的类别。</param>
        /// <param name="description">文件过滤的描述。</param>
        public FileFilter(string extension, string description)
        {
            Extension = extension;
            Description = description;
        }

        /// <summary>
        /// 创建一个新的文件过滤。
        /// </summary>
        /// <param name="extension">文件过滤的类别。</param>
        public FileFilter(string extension)
            : this(extension, null)
        {
        }

        /// <summary>
        /// 该文件过滤的描述。
        /// </summary>
        public sealed override string Description
        {
            get
            {
                return _description;
            }
            protected set
            {
                _description = string.IsNullOrEmpty(value) ? Extension : value;
            }
        }

        /// <summary>
        /// 过滤的文件类别。
        /// </summary>
        public sealed override string Extension
        {
            get
            {
                return _extension;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (value.Length == 0)
                {
                    throw new ArgumentException(Resources.StringLengthMustLargerThanZero, "value");
                }
                var regex = new Regex(@"^\*?\.?(\w+)$");
                Match match = regex.Match(value);
                if (match.Success == false)
                {
                    throw new ArgumentException(Resources.InvalidFileExtension, "value");
                }
                _extension = "*." + match.Groups[1].Value;
            }
        }
    }
}