using Subutai.Domain.Model.Auditing;

namespace Subutai.Domain.Model;

public class ProjectEntity : IHasCreationTime, IHasModificationTime, IHasDeletionTime
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public int? DepartmentId { get; set; }
    public DateTime DateStarted { get; set; }
    public DateTime? DateCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public DepartmentEntity? Department { get; set; }
}
