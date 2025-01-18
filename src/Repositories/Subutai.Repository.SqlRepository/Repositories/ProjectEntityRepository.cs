using Microsoft.EntityFrameworkCore;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;
using Subutai.Repository.SqlRepository.Contexts;

namespace Subutai.Repository.SqlRepository.Repositories;

public class ProjectEntityRepository : IProjectEntityRepository
{
    private readonly ISubutaiContext _context;

    public ProjectEntityRepository(ISubutaiContext context)
    {
        _context = context;
    }
    public async Task<ProjectEntity> AddAsync(ProjectEntity entity)
    {
        await _context.Projects.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<ProjectEntity> UpdateAsync(ProjectEntity entity)
    {
        var singleEntity = await _context.Projects.FirstOrDefaultAsync(e => e.Id == entity.Id);

        if (singleEntity == null)
       {
          throw new ArgumentException("Entity not found");
       } 
        singleEntity.Name = entity.Name;
        singleEntity.Description = entity.Description;
        singleEntity.Reference = entity.Reference;
        singleEntity.DateCompleted = entity.DateCompleted;
        singleEntity.DateStarted = entity.DateStarted;
        singleEntity.UpdatedAt = DateTime.UtcNow;
        singleEntity.DepartmentId = entity.DepartmentId;
        _context.Projects.Update(singleEntity);
        await _context.SaveChangesAsync();

        return singleEntity;
    }   
    public async Task<ProjectEntity> DeleteAsync(int id)
    {
        var singleEntity = await _context.Projects.FirstOrDefaultAsync(e => e.Id == id);

        if(singleEntity == null)
        {
            throw new ArgumentException("Entity is not found");
        }
        singleEntity.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return singleEntity;
    }
    public async Task<List<ProjectEntity>> GetAsync()
    {
        var projects =  await _context.Projects.ToListAsync();

        var unDeletedProjects = projects.Where(e => e.DeletedAt == null).ToList();

        return unDeletedProjects;
    }
}
