using EFCreatingDatabase.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCreatingDatabase.DAL
{
    public class EFContext : DbContext
    {
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetUserRoles> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=denysdb;Username=denys;Password=qwerty1*");
        }
        /// <summary>
        ///     Клас-налаштування.
        ///     Створений для встановлення налаштувань для класу AspNetUserRoles
        ///     В методі створюються Entities для цього класу, а саме встановлюються
        ///     Primary Keys і Foreign Keys 
        /// </summary>
        /// <param name="modelBuilder">Параметр за допомогою якого можна встановлювати налаштування</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetUserRoles>(userRoles => 
            {
                //  Встановлення PRIMARY KEYS
                userRoles.HasKey(userRolesPrimaryKey => new { userRolesPrimaryKey.RoleId, userRolesPrimaryKey.UserId });


                //  Встановлення звязку один до багатьох
                //  Вибірка віртуального елемента з класу AspNetRoles
                userRoles.HasOne(userRolesVirtualElementFromClassRoles => userRolesVirtualElementFromClassRoles.Role)
                //  Вибірка віртуальної колекції з класу AspNetUserRoles, для встановлення звязку з полем
                //  userRolesVirtualElementFromClassRoles
                .WithMany(userRolesVirtualCollectionFromClassUserRoles => userRolesVirtualCollectionFromClassUserRoles.UserRoles)
                //  Встановлюється поле до якого буде відноситись Constraint (ForeignKey)
                .HasForeignKey(userRolesColumnWithForeignKeyConstraint => userRolesColumnWithForeignKeyConstraint.RoleId)
                //  Встановлюється обовязковість заповнення поля
                .IsRequired();

                //  Встановлення звязку один до багатьох
                //  Вибірка віртуального поля з класу User, для встановлення звязку
                userRoles.HasOne(userRolesVirtualElementFromClassUser => userRolesVirtualElementFromClassUser.User)
                //  Вибірка віртуальної колекції з класу userRoles, для встановлення звязку один до багатьох
                //  з класом AspNetUser
                .WithMany(userRolesVirtualCollectionFromClassUserRoles => userRolesVirtualCollectionFromClassUserRoles.UserRoles)
                //  Вибірка поля(INT), для якого будуть застосовуватися налаштування ForeignKey
                .HasForeignKey(userRolesIntColumnWithForeignKeyConstraint => userRolesIntColumnWithForeignKeyConstraint.UserId)
                .IsRequired();
            });
        }
    }
}
