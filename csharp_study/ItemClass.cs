namespace csharp_study
{
    /// <summary>
    /// Item Class (クラス名)
    /// </summary>
    /// <remarks>
    /// Remarks, comments (備考)
    /// </remarks>
    /// <example>
    /// Use Example (使用方法)
    /// </example>
    public class ItemClass : IItem, IDisposable, ICloneable, IEquatable<ItemClass>
    {

        #region Enum

        public enum ColorTypes
        {
            Undefined = 0,
            Green,
            Blue,
            GreenYellow,
            GreenGreen,
            BlueGreenYellow
        }

        [Flags]
        public enum StatusTypes
        {
            Created = 1 << 1,
            Deleted = 1 << 2,
            Changed = 1 << 3,
            Renamed = 1 << 4,
            None = 0,
        }

        // flag = 0x1100 -> Renamed and Changed

        #endregion

        #region Field

        /// <summary>
        /// Name (Field)
        /// </summary>
        private string _Name = string.Empty;

        /// <summary>
        /// Count (Field)
        /// </summary>
        private int _Count = 0;

        /// <summary>
        /// Disposed Flag (Field)
        /// </summary>
        private bool _Disposed = false;

        #endregion

        #region Property

        /// <summary>
        /// Name (Property)
        /// </summary>
        public string Name { get => _Name; set { _Name = value; } }

        /// <summary>
        /// Count (Property)
        /// </summary>
        public int Count
        { 
            get => _Count; 
            set {
                if (value < 0) ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(value));
                _Count = value;
            }
        }

        /// <summary>
        /// Comment (Property & Field)
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        #endregion

        #region Initialize

        /// <summary>
        /// Itemを初期化します
        /// </summary>
        public ItemClass()
        {
            Name = string.Empty;
            Count = 0;
        }

        /// <summary>
        /// Itemを初期化します
        /// </summary>
        /// <param name="name">Name</param>
        public ItemClass(string name) : this()
        {
            Name = name;
        }

        /// <summary>
        /// Itemを初期化します
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="count">Count</param>
        public ItemClass(string name, int count) : this(name)
        {
            Count = count;
        }

        public ItemClass(string name, int count, string? comment) : this(name, count)
        {
            Comment = comment ?? string.Empty;
        }

        /// <summary>
        /// ItemClassを初期化します
        /// </summary>
        /// <param name="item">Interface IItemを使用しているクラス</param>
        public ItemClass(IItem item) : this(item.Name, item.Count) { }

        /// <summary>
        /// ItemClassを初期化します
        /// </summary>
        /// <param name="item">ItemClass</param>
        public ItemClass(ItemClass item) : this((IItem)item) { Comment = item.Comment; }

        #endregion

        #region

        ~ItemClass() => Dispose(true);

        #endregion

        #region Function

        public override int GetHashCode() => new { Name, Count, Comment }.GetHashCode();

        public override string ToString() => Name;

        public override bool Equals(object? obj) => GetHashCode() == base.GetHashCode();

        public bool Equals(IItem? other) => Equals((object?)other);

        public bool Equals(ItemClass? other) => Equals((object?)other);

        public int CompareTo(IItem? other)
        {
            int value = other == null ? 1 : Name.CompareTo(other.Name);
            return value == 0 ? other == null ? 1 : Count.CompareTo(other.Count) : value;
        }

        /// <summary>
        /// クラスの複製を返します
        /// </summary>
        /// <returns>ItemClass</returns>
        /// <remarks>
        /// IClonableは、一般的にパブリックAPIに実装しないことをおすすめします。
        /// </remarks>
        /// <href>https://learn.microsoft.com/ja-jp/dotnet/api/system.icloneable?view=net-8.0</href>
        public object Clone() => new ItemClass(this);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed) return;
            if (disposing)
            {
                Name = string.Empty;
                Count = 0;
            }
            _Disposed = true;
        }

        #endregion

    }
}