using System;
using Documet.Models;
using Microsoft.EntityFrameworkCore;

namespace Document.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<UserDocuments> UserDocuments { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {

        model.Entity<Status>().HasData(
            new Status()
            {
                Id = 1,
                Name = "Новый"
            },
            new Status()
            {
                Id = 2,
                Name = "В процессе"
            },
            new Status()
            {
                Id = 3,
                Name = "Отказано"
            },
            new Status()
            {
                Id = 4,
                Name = "Одобрено"
            }
        );
        model.Entity<Department>().HasData(
            new Department()
            {
                Id = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                Name = "РТСУ",
                CreatedAt = DateTime.UtcNow
            }
        );
        model.Entity<User>().HasData(
            new User()
            {
                Id = Guid.NewGuid(),
                Name = "Админ",
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                Phone = "+000000000000",
                CreatedAt = DateTime.UtcNow,
                DepartmentId = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440")
            }
        );

    }
}