namespace Domain.Contracts
{
    /// <summary>
    /// A thing that has Id
    /// </summary>
    public interface IEntity
    {
        int Id { get; }
        bool IsDeleted { get; set; }
    }
}
