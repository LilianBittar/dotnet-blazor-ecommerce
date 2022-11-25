using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film. ", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", 9.99m, "The Hitchhiker's Guide to the Galaxy" },
                    { 2, "The book takes inspiration from a set of spiritual beliefs held by the ancient Toltec people to help readers transform their lives into a new experience of freedom, true happiness, and love.[4] According to the author, everything a person does is based on 'agreements' they have made with themselves, with others, with God, and with life itself.[1] In these agreements, people may tell themselves who they are, how to behave, what is possible, and what is impossible.[1] Some agreements that individuals create may not cause issues, but there are certain agreements that come from a place of fear and have the power to deplete one's emotional energy as well as diminish the self-worth of a person.[1] The book states that these self-limiting agreements are what creates needless suffering.[1] Ruiz also believes that to find personal joy, one must get rid of society-imposed and fear-based agreements that may subconsciously influence the behavior and mindset of the individual.[5] Another basic premise of the book suggests that much of suffering is self-created and that most of the time, individuals have the ability to transform themselves and the negative thoughts they may have about situations occurring within their life.[6] The author identifies sources of unhappiness in life and proposes four beneficial agreements that one can make with oneself to improve ones overall state of well-being. By making a pact with these four key agreements, an individual is able to dramatically impact the amount of happiness they feel in their lives, regardless of external circumstances.", "https://upload.wikimedia.org/wikipedia/en/5/52/The_Four_Agreements.jpeg", 7.99m, "The Four Agreements" },
                    { 3, "To Kill a Mockingbird is a novel by the American author Harper Lee. It was published in 1960 and was instantly successful. In the United States, it is widely read in high schools and middle schools. To Kill a Mockingbird has become a classic of modern American literature, winning the Pulitzer Prize. The plot and characters are loosely based on Lee's observations of her family, her neighbors and an event that occurred near her hometown of Monroeville, Alabama, in 1936, when she was ten. ", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", 6.99m, "To Kill a Mockingbird" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");
        }
    }
}
