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
        },
         new Product
         {
             Id = 4,
             CategoryId = 2,
             Title = "The Matrix",
             Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
             ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
         },
        new Product
        {
            Id = 5,
            CategoryId = 2,
            Title = "Back to the Future",
            Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",

        },
        new Product
        {
            Id = 6,
            CategoryId = 2,
            Title = "Toy Story",
            Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",

        },
        new Product
        {
            Id = 7,
            CategoryId = 3,
            Title = "Half-Life 2",
            Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",

        },
        new Product
        {
            Id = 8,
            CategoryId = 3,
            Title = "Diablo II",
            Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
        },
        new Product
        {
            Id = 9,
            CategoryId = 3,
            Title = "Day of the Tentacle",
            Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
        },
        new Product
        {
            Id = 10,
            CategoryId = 3,
            Title = "Xbox",
            Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
        },
        new Product
        {
            Id = 11,
            CategoryId = 3,
            Title = "Super Nintendo Entertainment System",
            Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
        });
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
