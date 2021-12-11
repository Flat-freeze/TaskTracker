using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Data.Migrations
{
    public partial class CreateConstraintCreateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedBy",
                table: "Tasks",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UpdatedBy",
                table: "Tasks",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedBy",
                table: "Projects",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UpdatedBy",
                table: "Projects",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Commands_CreatedBy",
                table: "Commands",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Commands_UpdatedBy",
                table: "Commands",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_CreatedBy",
                table: "Columns",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_UpdatedBy",
                table: "Columns",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_AspNetUsers_CreatedBy",
                table: "Columns",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_AspNetUsers_UpdatedBy",
                table: "Columns",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_AspNetUsers_CreatedBy",
                table: "Commands",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_AspNetUsers_UpdatedBy",
                table: "Commands",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_CreatedBy",
                table: "Projects",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_UpdatedBy",
                table: "Projects",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_CreatedBy",
                table: "Tasks",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UpdatedBy",
                table: "Tasks",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Columns_AspNetUsers_CreatedBy",
                table: "Columns");

            migrationBuilder.DropForeignKey(
                name: "FK_Columns_AspNetUsers_UpdatedBy",
                table: "Columns");

            migrationBuilder.DropForeignKey(
                name: "FK_Commands_AspNetUsers_CreatedBy",
                table: "Commands");

            migrationBuilder.DropForeignKey(
                name: "FK_Commands_AspNetUsers_UpdatedBy",
                table: "Commands");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_CreatedBy",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UpdatedBy",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_CreatedBy",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UpdatedBy",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatedBy",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UpdatedBy",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CreatedBy",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UpdatedBy",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Commands_CreatedBy",
                table: "Commands");

            migrationBuilder.DropIndex(
                name: "IX_Commands_UpdatedBy",
                table: "Commands");

            migrationBuilder.DropIndex(
                name: "IX_Columns_CreatedBy",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Columns_UpdatedBy",
                table: "Columns");
        }
    }
}
