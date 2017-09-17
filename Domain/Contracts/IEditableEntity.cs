namespace Domain.Contracts
{
    public interface IEditableEntity :IEntity 
    {
        byte[] Version { get; }
     
    }
}
