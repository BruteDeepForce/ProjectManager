namespace Subutai.Domain.Model.Auditing;

public interface IHasCreationTime
{
    DateTime CreatedAt { get; set; }
}
