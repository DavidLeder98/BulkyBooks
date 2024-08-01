using Bulky.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Enchiridion",
                    Author = "Billy the Hero",
                    Description = "A beginner's guide for aspiring heroes, the Enchiridion is packed with essential advice for new adventurers. Learn the basics of combat, survival, and questing, along with tips for navigating the world of heroes. This book is the perfect starting point for anyone looking to embark on a heroic journey.",
                    ISBN = "ENC1234567",
                    ListPrice = 900,
                    Price = 850,
                    Price50 = 800,
                    Price100 = 750
                },
                new Product
                {
                    Id = 2,
                    Title = "Morellonomicon",
                    Author = "Xergoloth the Mad",
                    Description = "Dive into the dark arts with the Morellonomicon, a grimoire filled with forbidden spells and malevolent enchantments. This book is not for the faint-hearted, as it reveals the sinister paths of necromancy and demonology. Perfect for those who dare to harness the power of the shadows.",
                    ISBN = "MOR7654321",
                    ListPrice = 500,
                    Price = 490,
                    Price50 = 450,
                    Price100 = 400
                },
                new Product
                {
                    Id = 3,
                    Title = "Swordsmanship for Beginners",
                    Author = "Wardun the One-armed",
                    Description = "Designed for novice warriors, this manual provides a thorough introduction to the art of sword fighting. It covers basic techniques, footwork, and defensive maneuvers to build a solid foundation. Master the fundamentals and prepare yourself for any battle with confidence.",
                    ISBN = "SWD1010101",
                    ListPrice = 50,
                    Price = 45,
                    Price50 = 40,
                    Price100 = 35
                },
                new Product
                {
                    Id = 4,
                    Title = "Basics of Cantrips",
                    Author = "Arch Wizard Toadbottom",
                    Description = "An essential handbook for aspiring spellcasters, Basics of Cantrips introduces readers to the simplest and most practical spells. This guide covers a variety of everyday enchantments, perfect for beginners looking to hone their magical skills. Start your journey into the magical arts with ease.",
                    ISBN = "BOC4445444",
                    ListPrice = 100,
                    Price = 90,
                    Price50 = 80,
                    Price100 = 70
                },
                new Product
                {
                    Id = 5,
                    Title = "Bestiary of the Black Woods",
                    Author = "Bob",
                    Description = "Explore the mysterious and dangerous creatures that inhabit the Black Woods with this detailed bestiary. Each entry provides descriptions, habits, and weaknesses of the forest's denizens, from the elusive Shadow Stalker to the fearsome Night Terror. Equip yourself with the knowledge to survive and thrive in the dark wilderness.",
                    ISBN = "BBW1122448",
                    ListPrice = 30,
                    Price = 29,
                    Price50 = 27,
                    Price100 = 25
                },
                new Product
                {
                    Id = 6,
                    Title = "Adventuring Ethics 3rd Edition",
                    Author = "Moralla Goodman",
                    Description = "Navigate the moral dilemmas of adventuring with this updated guide on ethical behavior in the field. This edition covers new scenarios and offers advice on maintaining honor and integrity. A crucial resource for any adventurer committed to doing the right thing, even in the face of peril.",
                    ISBN = "AEE3333333",
                    ListPrice = 15,
                    Price = 14,
                    Price50 = 13,
                    Price100 = 12
                }
                );
        }
    }
}
