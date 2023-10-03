using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tc_no = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Room_Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MyTask_Title = table.Column<string>(type: "text", nullable: false),
                    MyTask_Description = table.Column<string>(type: "text", nullable: false),
                    MyTask_DeadLine = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MyTask_Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Project_Title = table.Column<string>(type: "text", nullable: false),
                    Project_Description = table.Column<string>(type: "text", nullable: false),
                    Project_DeadLine = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Project_Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ticket_Content = table.Column<string>(type: "text", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Ticket_Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsDeleted", "PasswordHash", "PasswordSalt", "Phone", "Tc_no", "UpdatedAt", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 3, 14, 27, 16, 293, DateTimeKind.Utc).AddTicks(8180), "bg@gmail.com", "Bülent Karanfil", false, new byte[] { 3, 224, 31, 43, 114, 221, 62, 143, 78, 231, 246, 144, 147, 145, 69, 201, 110, 190, 66, 183, 125, 250, 252, 187, 131, 157, 236, 73, 37, 145, 162, 51, 74, 242, 228, 171, 73, 16, 159, 159, 244, 183, 154, 1, 210, 105, 211, 32, 213, 120, 198, 168, 181, 162, 33, 207, 178, 51, 203, 179, 163, 218, 132, 186 }, new byte[] { 28, 9, 219, 186, 215, 241, 156, 135, 35, 11, 185, 139, 156, 126, 242, 170, 55, 66, 150, 246, 203, 236, 141, 228, 32, 34, 145, 90, 142, 182, 72, 14, 210, 243, 213, 247, 188, 138, 173, 86, 145, 50, 252, 194, 32, 247, 130, 244, 135, 82, 206, 129, 24, 171, 120, 64, 34, 169, 93, 18, 55, 65, 116, 223, 31, 177, 29, 197, 222, 190, 137, 92, 0, 144, 139, 148, 102, 197, 144, 79, 133, 92, 21, 46, 99, 155, 113, 121, 247, 208, 205, 194, 101, 102, 232, 125, 78, 172, 255, 127, 186, 11, 28, 121, 33, 0, 71, 91, 144, 246, 241, 100, 162, 196, 149, 249, 142, 72, 124, 203, 200, 66, 154, 100, 134, 54, 114, 22 }, "324763282348237", "32324324234234", new DateTime(2023, 10, 3, 14, 27, 16, 293, DateTimeKind.Utc).AddTicks(8260), "bulent123", 0 },
                    { 2, new DateTime(2023, 10, 3, 14, 27, 16, 293, DateTimeKind.Utc).AddTicks(8420), "kaam@gmail.com", "Kan kaan", false, new byte[] { 3, 224, 31, 43, 114, 221, 62, 143, 78, 231, 246, 144, 147, 145, 69, 201, 110, 190, 66, 183, 125, 250, 252, 187, 131, 157, 236, 73, 37, 145, 162, 51, 74, 242, 228, 171, 73, 16, 159, 159, 244, 183, 154, 1, 210, 105, 211, 32, 213, 120, 198, 168, 181, 162, 33, 207, 178, 51, 203, 179, 163, 218, 132, 186 }, new byte[] { 28, 9, 219, 186, 215, 241, 156, 135, 35, 11, 185, 139, 156, 126, 242, 170, 55, 66, 150, 246, 203, 236, 141, 228, 32, 34, 145, 90, 142, 182, 72, 14, 210, 243, 213, 247, 188, 138, 173, 86, 145, 50, 252, 194, 32, 247, 130, 244, 135, 82, 206, 129, 24, 171, 120, 64, 34, 169, 93, 18, 55, 65, 116, 223, 31, 177, 29, 197, 222, 190, 137, 92, 0, 144, 139, 148, 102, 197, 144, 79, 133, 92, 21, 46, 99, 155, 113, 121, 247, 208, 205, 194, 101, 102, 232, 125, 78, 172, 255, 127, 186, 11, 28, 121, 33, 0, 71, 91, 144, 246, 241, 100, 162, 196, 149, 249, 142, 72, 124, 203, 200, 66, 154, 100, 134, 54, 114, 22 }, "324763282348237", "45756865745654", new DateTime(2023, 10, 3, 14, 27, 16, 293, DateTimeKind.Utc).AddTicks(8490), "kan123", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_RoomId",
                table: "Projects",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RoomId",
                table: "Tickets",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
