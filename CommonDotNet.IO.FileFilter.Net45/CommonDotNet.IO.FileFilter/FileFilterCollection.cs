using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDotNet.IO
{
    /// <summary>
    /// 文件过滤集合。
    /// </summary>
    public class FileFilterCollection :
#if Net35
 ICollection<FileFilterBase>
#endif
#if Net40||Net45
 ISet<FileFilterBase>
#endif
    {
        private readonly HashSet<FileFilterBase> _collection;

        /// <summary>
        /// 创建一个空的文件过滤集合。
        /// </summary>
        public FileFilterCollection()
            : this(new FileFilterBase[] { })
        {
        }

        /// <summary>
        /// 以现有集合创建一个新的文件过滤集合。
        /// </summary>
        /// <param name="fileFilters">现有文件过滤集合。</param>
        /// <exception cref="ArgumentNullException"><c>fileFilters</c> 为 null。</exception>
        public FileFilterCollection(IEnumerable<FileFilterBase> fileFilters)
        {
            if (fileFilters == null)
            {
                throw new ArgumentNullException("fileFilters");
            }
            _collection = new HashSet<FileFilterBase>();
            foreach (var fileFilter in fileFilters)
            {
                Add(fileFilter);
            }
        }

        /// <summary>
        /// 以现有文件过滤创建一个新的文件过滤集合。
        /// </summary>
        /// <param name="fileFilters">现有的文件过滤。</param>
        /// <exception cref="ArgumentNullException"><c>fileFilters</c> 为 null。</exception>
        public FileFilterCollection(params FileFilterBase[] fileFilters)
        {
            if (fileFilters == null)
            {
                throw new ArgumentNullException("fileFilters");
            }
            _collection = new HashSet<FileFilterBase>();
            foreach (var fileFilter in fileFilters)
            {
                Add(fileFilter);
            }
        }

        /// <summary>
        /// 以文件扩展名创建文件过滤集合。
        /// </summary>
        /// <param name="extensions">文件扩展名。</param>
        /// <exception cref="ArgumentNullException"><c>extensions</c> 为 null。</exception>
        public FileFilterCollection(params string[] extensions)
        {
            if (extensions == null)
            {
                throw new ArgumentNullException("extensions");
            }
            _collection = new HashSet<FileFilterBase>();
            foreach (var extension in extensions)
            {
                Add(new FileFilter(extension));
            }
        }

        /// <summary>
        /// 获取集合中包含的元素数。
        /// </summary>
        public int Count
        {
            get
            {
                return _collection.Count;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示 CommonDotNet.IO.FileFilter.FileFilterCollection 是否为只读。
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 获取文件过滤集合的字符串形式。
        /// </summary>
        /// <param name="fileFilterCollection">文件过滤集合。</param>
        /// <returns>文件过滤集合的字符串形式。若文件过滤集合为 null，则返回 null。</returns>
        public static implicit operator string(FileFilterCollection fileFilterCollection)
        {
            return fileFilterCollection == null ? null : fileFilterCollection.ToString();
        }

        /// <summary>
        /// 往现有文件过滤集合添加一个新的文件过滤。
        /// </summary>
        /// <param name="collection">现有文件过滤集合。</param>
        /// <param name="fileFilter">新的文件过滤。</param>
        /// <returns>合并的集合。</returns>
        public static FileFilterCollection operator +(FileFilterCollection collection, FileFilterBase fileFilter)
        {
            if (collection == null)
            {
                if (fileFilter == null)
                {
                    return null;
                }
                return new FileFilterCollection(fileFilter);
            }
            return new FileFilterCollection(collection._collection) { fileFilter };
        }

        /// <summary>
        /// 将指定的元素添加到集中。
        /// </summary>
        /// <param name="item">要添加到集中的元素。</param>
        /// <returns>如果该元素添加到 CommonDotNet.IO.FileFilterCollection 对象中则为 true；如果该元素已存在则为 false。</returns>
        public bool Add(FileFilterBase item)
        {
            return _collection.Add(item);
        }

        /// <summary>
        /// 从 CommonDotNet.IO.FileFilterCollection 对象中移除所有元素。
        /// </summary>
        public void Clear()
        {
            _collection.Clear();
        }

        /// <summary>
        /// 确定 CommonDotNet.IO.FileFilterCollection 对象是否包含指定的元素。
        /// </summary>
        /// <param name="item">要在 CommonDotNet.IO.FileFilterCollection 对象中查找的元素。</param>
        /// <returns>如果 CommonDotNet.IO.FileFilterCollection 对象包含指定的元素，则为 true；否则为 false。</returns>
        public bool Contains(FileFilterBase item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(FileFilterBase[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<FileFilterBase> other)
        {
            _collection.ExceptWith(other);
        }

        public IEnumerator<FileFilterBase> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        void ICollection<FileFilterBase>.Add(FileFilterBase item)
        {
            _collection.Add(item);
        }

        public void IntersectWith(IEnumerable<FileFilterBase> other)
        {
            _collection.IntersectWith(other);
        }

        public bool IsProperSubsetOf(IEnumerable<FileFilterBase> other)
        {
            return _collection.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<FileFilterBase> other)
        {
            return _collection.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<FileFilterBase> other)
        {
            return _collection.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<FileFilterBase> other)
        {
            return _collection.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<FileFilterBase> other)
        {
            return _collection.Overlaps(other);
        }

        public bool Remove(FileFilterBase item)
        {
            return _collection.Remove(item);
        }

        public bool SetEquals(IEnumerable<FileFilterBase> other)
        {
            return _collection.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<FileFilterBase> other)
        {
            _collection.SymmetricExceptWith(other);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            for (var i = 0; i < _collection.Count; i++)
            {
                buffer.Append(_collection.ElementAt(i).ToString());
                if (i != _collection.Count - 1)
                {
                    buffer.Append('|');
                }
            }
            return buffer.ToString();
        }

        public void UnionWith(IEnumerable<FileFilterBase> other)
        {
            _collection.UnionWith(other);
        }
    }
}