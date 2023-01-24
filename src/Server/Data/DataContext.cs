using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                name = "Books",
                Url = "books"
            },
            new Category
            {
                Id = 2,
                name = "Movies",
                Url = "movies"
            },
            new Category
            {
                Id = 3,
                name = "Video Games",
                Url = "video-games"
            }
        );
        modelBuilder.Entity<Product>().HasData(

            new Product
            {
                Id = 1,
                Title = "The Hitchhiker's Guide to the Galaxy",
                Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film. ",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                Price = 9.99M,
                CategoryId = 1
            },

        new Product
        {
            Id = 2,
            Title = "The Four Agreements",
            Description = "The book takes inspiration from a set of spiritual beliefs held by the ancient Toltec people to help readers transform their lives into a new experience of freedom, true happiness, and love.[4] According to the author, everything a person does is based on 'agreements' they have made with themselves, with others, with God, and with life itself.[1] In these agreements, people may tell themselves who they are, how to behave, what is possible, and what is impossible.[1] Some agreements that individuals create may not cause issues, but there are certain agreements that come from a place of fear and have the power to deplete one's emotional energy as well as diminish the self-worth of a person.[1] The book states that these self-limiting agreements are what creates needless suffering.[1] Ruiz also believes that to find personal joy, one must get rid of society-imposed and fear-based agreements that may subconsciously influence the behavior and mindset of the individual.[5] Another basic premise of the book suggests that much of suffering is self-created and that most of the time, individuals have the ability to transform themselves and the negative thoughts they may have about situations occurring within their life.[6] The author identifies sources of unhappiness in life and proposes four beneficial agreements that one can make with oneself to improve ones overall state of well-being. By making a pact with these four key agreements, an individual is able to dramatically impact the amount of happiness they feel in their lives, regardless of external circumstances.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/52/The_Four_Agreements.jpeg",
            Price = 7.99M,
            CategoryId = 2
        },
        new Product
        {
            Id = 3,
            Title = "To Kill a Mockingbird",
            Description = "To Kill a Mockingbird is a novel by the American author Harper Lee. It was published in 1960 and was instantly successful. In the United States, it is widely read in high schools and middle schools. To Kill a Mockingbird has become a classic of modern American literature, winning the Pulitzer Prize. The plot and characters are loosely based on Lee's observations of her family, her neighbors and an event that occurred near her hometown of Monroeville, Alabama, in 1936, when she was ten. ",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg",
            Price = 6.99M,
            CategoryId = 3
        });
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
