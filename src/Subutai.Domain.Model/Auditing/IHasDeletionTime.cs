namespace Subutai.Domain.Model.Auditing;

public interface IHasDeletionTime
{
    DateTime? DeletedAt { get; set; }
}
