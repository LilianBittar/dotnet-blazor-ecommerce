﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.Data;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221125184427_ProductSeeding")]
    partial class ProductSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film. ",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                            Price = 9.99m,
                            Title = "The Hitchhiker's Guide to the Galaxy"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The book takes inspiration from a set of spiritual beliefs held by the ancient Toltec people to help readers transform their lives into a new experience of freedom, true happiness, and love.[4] According to the author, everything a person does is based on 'agreements' they have made with themselves, with others, with God, and with life itself.[1] In these agreements, people may tell themselves who they are, how to behave, what is possible, and what is impossible.[1] Some agreements that individuals create may not cause issues, but there are certain agreements that come from a place of fear and have the power to deplete one's emotional energy as well as diminish the self-worth of a person.[1] The book states that these self-limiting agreements are what creates needless suffering.[1] Ruiz also believes that to find personal joy, one must get rid of society-imposed and fear-based agreements that may subconsciously influence the behavior and mindset of the individual.[5] Another basic premise of the book suggests that much of suffering is self-created and that most of the time, individuals have the ability to transform themselves and the negative thoughts they may have about situations occurring within their life.[6] The author identifies sources of unhappiness in life and proposes four beneficial agreements that one can make with oneself to improve ones overall state of well-being. By making a pact with these four key agreements, an individual is able to dramatically impact the amount of happiness they feel in their lives, regardless of external circumstances.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/52/The_Four_Agreements.jpeg",
                            Price = 7.99m,
                            Title = "The Four Agreements"
                        },
                        new
                        {
                            Id = 3,
                            Description = "To Kill a Mockingbird is a novel by the American author Harper Lee. It was published in 1960 and was instantly successful. In the United States, it is widely read in high schools and middle schools. To Kill a Mockingbird has become a classic of modern American literature, winning the Pulitzer Prize. The plot and characters are loosely based on Lee's observations of her family, her neighbors and an event that occurred near her hometown of Monroeville, Alabama, in 1936, when she was ten. ",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg",
                            Price = 6.99m,
                            Title = "To Kill a Mockingbird"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
