using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace video_rental.Migrations
{
    public partial class addedIsCheckedOutflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedOut",
                table: "Movies",
                type: "bool",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckedOut",
                table: "Movies");
        }
    }
}
