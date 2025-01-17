using Subutai.Domain.Model.Auditing;

namespace Subutai.Domain.Model;

public class DepartmentEntity : IHasCreationTime, IHasModificationTime, IHasDeletionTime
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
