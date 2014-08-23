namespace CommonDotNet.IO
{
    /// <summary>
    /// 用于 FileDialog 类及其之类的 Filter 属性的文件过滤基类。
    /// </summary>
    public abstract class FileFilterBase
    {
        /// <summary>
        /// 该文件过滤的描述。
        /// </summary>
        public virtual string Description
        {
            get;
            protected set;
        }

        /// <summary>
        /// 过滤的文件类别。
        /// </summary>
        public virtual string Extension
        {
            get;
            protected set;
        }

        /// <summary>
        /// 将两个文件过滤合并。
        /// </summary>
        /// <param name="fileFilter">一个文件过滤。</param>
        /// <param name="otherFileFilter">另一个文件过滤。</param>
        /// <returns>合并后的文件过滤。</returns>
        public static FileFilterCollection Add(FileFilterBase fileFilter, FileFilterBase otherFileFilter)
        {
            return new FileFilterCollection(fileFilter, otherFileFilter);
        }

        /// <summary>
        /// 返回文件过滤的字符串形式。
        /// </summary>
        /// <param name="fileFilter">一个文件过滤。</param>
        /// <returns>指定文件过滤的字符串形式。若文件过滤为 null，则返回 null。</returns>
        public static implicit operator string(FileFilterBase fileFilter)
        {
            return fileFilter == null ? null : fileFilter.ToString();
        }

        /// <summary>
        /// 判断两个文件过滤是否不相同。
        /// </summary>
        /// <param name="fileFilter">一个文件过滤。</param>
        /// <param name="otherFileFilter">另一个文件过滤。</param>
        /// <returns>若两个文件过滤的类别相同，则返回 true；否则返回 false。</returns>
        public static bool operator !=(FileFilterBase fileFilter, FileFilterBase otherFileFilter)
        {
            return (fileFilter == otherFileFilter) == false;
        }

        /// <summary>
        /// 将两个文件过滤合并。
        /// </summary>
        /// <param name="fileFilter">一个文件过滤。</param>
        /// <param name="otherFileFilter">另一个文件过滤。</param>
        /// <returns>合并后的文件过滤。</returns>
        public static FileFilterCollection operator +(FileFilterBase fileFilter, FileFilterBase otherFileFilter)
        {
            return Add(fileFilter, otherFileFilter);
        }

        /// <summary>
        /// 判断两个文件过滤是否相同。
        /// </summary>
        /// <param name="fileFilter">一个文件过滤。</param>
        /// <param name="otherFileFilter">另一个文件过滤。</param>
        /// <returns>若两个文件过滤的类别不同，则返回 true；否则返回 false。</returns>
        public static bool operator ==(FileFilterBase fileFilter, FileFilterBase otherFileFilter)
        {
            if (ReferenceEquals(fileFilter, null) && ReferenceEquals(otherFileFilter, null))
            {
                return true;
            }
            if (ReferenceEquals(fileFilter, null) || ReferenceEquals(otherFileFilter, null))
            {
                return false;
            }
            return fileFilter.Extension == otherFileFilter.Extension;
        }

        /// <summary>
        /// 指示当前实例是否与另一实例相同。
        /// </summary>
        /// <param name="obj">另一实例。</param>
        /// <returns>是否相同。</returns>
        public sealed override bool Equals(object obj)
        {
            var fileFilter = obj as FileFilterBase;
            if (fileFilter != null)
            {
                return Extension == fileFilter.Extension;
            }
            return Extension.Equals(obj);
        }

        /// <summary>
        /// 返回该文件过滤的文件类别的哈希代码。
        /// </summary>
        /// <returns>哈希代码。</returns>
        public sealed override int GetHashCode()
        {
            return Extension.GetHashCode();
        }

        /// <summary>
        /// 返回文件过滤的字符串形式。
        /// </summary>
        /// <returns>字符串。</returns>
        public override string ToString()
        {
            return Description + "|" + Extension;
        }
    }
}