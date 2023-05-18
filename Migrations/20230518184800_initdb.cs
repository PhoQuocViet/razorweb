using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.models;

#nullable disable

namespace CS58ASPNETRazor09EntityFrameworkASPNET.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });
                
                //Insert Date
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] {"Title", "Created", "Content"},
                    values: new object[2, 3] {
                        {"Bai viet 1", new DateTime(2021, 8, 20), "Noi dung 1"}, {"Bai viet 2", new DateTime(2021, 8, 21), "Noi dung 2"}
                    }
                );

                //Sử dụng Bogus (Fake Data):
                Randomizer.Seed = new Random(8675309); 
                var fakerArticle = new Faker<Article>(); //đối tượng dùng để phát sinh ra Article
                fakerArticle.RuleFor(a => a.Title, fakerArticle => fakerArticle.Lorem.Sentence(5, 5)); //thiết lập luật phát sinh giá trị cho các thuộc tính của Article
                fakerArticle.RuleFor(a => a.Created, fakerArticle => fakerArticle.Date.Between(new DateTime(2021, 1, 1), new DateTime(2021, 7, 30)));
                fakerArticle.RuleFor(a => a.Content, fakerArticle => fakerArticle.Lorem.Paragraphs(1, 4));

                for (int i = 0; i < 150; i++){
                    var article = fakerArticle.Generate();
                    migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] {"Title", "Created", "Content"},
                    values: new object[] {
                        article.Title, article.Created, article.Content
                    }
                );
                }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
