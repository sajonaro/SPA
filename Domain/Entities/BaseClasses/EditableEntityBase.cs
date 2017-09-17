namespace Domain.Entities.BaseClasses
{
    using System.ComponentModel.DataAnnotations;
    using Domain.Contracts;

    public abstract class EditableEntityBase: EntityBase, IEditableEntity
    {

        /// <summary>
        /// Is needed for optimistic concurrency support
        /// </summary>
        [Timestamp]
        public byte[] Version { get; set; }

 
    }
}
