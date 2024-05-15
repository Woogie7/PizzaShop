using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TransleteRusAndAddImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Pizzas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Традиционная");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Вегетарианская");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Мясная");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Морепродукты");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Гавайская");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Барбекю");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Маргарита");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Пепперони");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "ЧетыреСыра");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Суприм");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Мексиканска");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Фермерская");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Кальцоне");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "глютенаНет");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Пользовательская");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Тесто");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Топпинг");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Соус");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Сып");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Овощи");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Мясо");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Морепродукты");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Травы");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Фрукты");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Орехи");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Молочка");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Зерно");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Приправы");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Масла");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Подсластители");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Другое");

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Маленькая");

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Средняя");

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Большая");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Pizzas");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Traditional");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Vegetarian");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "MeatLovers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Seafood");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Hawaiian");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "BBQ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Margherita");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Pepperoni");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "FourCheese");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Supreme");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Mexican");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Farmhouse");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Calzone");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "GlutenFree");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Custom");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Base");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Topping");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Sauce");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Cheese");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Vegetable");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Meat");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Seafood");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Herb");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Fruit");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Nut");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Dairy");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Grain");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Condiment");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Oil");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Sweetener");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Other");

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Small");

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Large");
        }
    }
}
