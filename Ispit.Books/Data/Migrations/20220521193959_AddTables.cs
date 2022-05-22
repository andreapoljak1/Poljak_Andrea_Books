using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Books.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Author",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Author",
                newName: "FirstName");

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "DateOfBirth", "Description", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1874, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska književnica koja je u Hrvatskoj i u svijetu priznata kao jedna od najznačajnijih spisateljica za djecu.", "Ivana", "Brlić - Mažuranić" },
                    { 2, new DateTime(1917, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatski kazališni i filmski glumac, dramatik, komediograf, romanopisac, pjesnik, dječji pisac i prvi direktor kazališta 'Gavella'", "Pero", "Budak" },
                    { 3, new DateTime(1891, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatski književnik i filmski scenarist. Najpoznatija djela su mu: Breza (koju je i sam režirao, uz pomoć redatelja Ante Babaje) i Svoga tela gospodar..", "Slavko", "Kolar" },
                    { 4, new DateTime(1911, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smatra se začetnikom moderne hrvatske književnosti za djecu.[5] Autor je brojnih pjesama i priča namijenjenima djeci, te je autor i mnogobrojnih članaka u časopisima. ", "Grigor", "Vitez" },
                    { 5, new DateTime(1899, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatski književnik, prevoditelj s ruskog, češkog, slovenskog i njemačkog jezika, prvi predsjednik Društva hrvatskih književnih prevodilaca. Jedan od najvažnijih hrvatskih književnika 20. stoljeća.", "Gustav", "Krklec" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Nakladničkom djelatnošću bavi se od 1998. godine", "Dječja knjiga d.o.o., Zagreb" },
                    { 2, "Mozaik knjiga je jedna od najvećih nakladničkih kuća u Hrvatskoj koja objavljuje popularnu beletristiku za odrasle, djecu i mlade, ilustrirane enciklopedije, priručnike za odgoj i roditeljstvo, kuharice, poslovne knjige i filozofske tekstove te lektirni program.", "Mozaik knjiga" },
                    { 3, "Školska knjiga je jedna od najvećih izdavačkih kuća u Hrvatskoj. Sjedište joj je u Zagrebu. Školska knjiga je objavila preko 22 000 naslova u nakladi od 415 mil. primjeraka.", "Školska knjiga" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Author",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Author",
                newName: "Name");
        }
    }
}
