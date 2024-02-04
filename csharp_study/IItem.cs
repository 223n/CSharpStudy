namespace csharp_study
{
    /// <summary>
    /// Item Interface
    /// </summary>
    public interface IItem : IEquatable<IItem>, IComparable<IItem>
    {

        /// <summary>
        /// Name (Property)
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Count (Property)
        /// </summary>
        int Count { get; set; }

    }
}
