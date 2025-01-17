namespace Subutai.Domain.Model.Auditing;

public interface IHasModificationTime
{
    DateTime? UpdatedAt { get; set; }
}
