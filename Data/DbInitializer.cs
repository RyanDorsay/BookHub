using System;
using System.Linq;
using BookHub.Models;
using BookHub.Data;
using Bogus;


namespace BookHub.Data
{
    public static class DbInitializer
    {
            public static void Initialize(ApplicationDbContext context)
            {
                {
                context.Database.EnsureCreated();

                if (context.Books.Any())
                {
                    return; // DB has been seeded
                }   

                // Create a Faker instance for the Book model
                var faker = new Faker<Books>()
                    .RuleFor(b => b.Title, f => f.Lorem.Sentence(3, 5))
                    .RuleFor(b => b.Author, f => f.Name.FullName())
                    .RuleFor(b => b.Genre, f => f.Commerce.Categories(1)[0])
                    .RuleFor(b => b.Description, f => f.Lorem.Paragraph());

                // Generate a list of fake books
                var books = faker.Generate(100);

                context.Books.AddRange(books);
                context.SaveChanges();
            
            }
        }
    }

}