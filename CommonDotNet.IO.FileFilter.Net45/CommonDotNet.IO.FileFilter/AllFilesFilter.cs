using CommonDotNet.IO.Properties;
using System;

namespace CommonDotNet.IO
{
    /// <summary>
    /// 表示所有文件的文件过滤。
    /// </summary>
    public sealed class AllFilesFilter : FileFilterBase
    {
        private const string DefaultExtension = "*.*";

        private static string _defaultDescription = Resources.DefaultAllFilesDescription;

        /// <summary>
        /// 创建一个表示所有文件的文件过滤。
        /// </summary>
        public AllFilesFilter()
            : this(_defaultDescription)
        {
        }

        /// <summary>
        /// 创建一个表示所有文件的文件过滤。
        /// </summary>
        /// <param name="description">该文件过滤的描述。</param>
        public AllFilesFilter(string description)
        {
            base.Extension = Extension;
            base.Description = description;
        }

        /// <summary>
        /// 该文件过滤的描述。
        /// </summary>
        public new static string Description
        {
            get
            {
                return _defaultDescription;
            }
        }

        /// <summary>
        /// 过滤的文件类别。返回 "*.*"。
        /// </summary>
        public new static string Extension
        {
            get
            {
                return DefaultExtension;
            }
        }

        /// <summary>
        /// 设置默认的所有文件过滤的描述。
        /// </summary>
        /// <param name="description">描述字符串。</param>
        public static void SetDefaultDescription(string description)
        {
            if (description == null)
            {
                throw new ArgumentNullException("description");
            }
            if (description.Length == 0)
            {
                throw new ArgumentException(Resources.StringLengthMustLargerThanZero, "description");
            }
            _defaultDescription = description;
        }
    }
}