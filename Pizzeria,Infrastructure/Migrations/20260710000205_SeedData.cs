using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pizzeria_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Categoria", "Descripcion", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Clásica", "Pizza clásica con salsa de tomate y queso muzzarella.", "Muzzarella", 5500m },
                    { 2, "Clásica", "Pizza con tomate, ajo, orégano y muzzarella.", "Napolitana", 6500m },
                    { 3, "Especial", "Pizza con jamón, morrón y muzzarella.", "Especial", 7500m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nombre", "Password", "Rol" },
                values: new object[,]
                {
                    { 1, "admin@pizzeria.com", "Administrador", "123456", "Admin" },
                    { 2, "user@pizzeria.com", "Usuario Demo", "123456", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
