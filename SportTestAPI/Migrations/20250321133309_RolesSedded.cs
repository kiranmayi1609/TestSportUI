using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportTestAPI.Migrations
{
    /// <inheritdoc />
    public partial class RolesSedded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10efd525-49de-4dce-9d8e-739f0be5a5e6", "3", "Player", "Player" },
                    { "d7398990-2a09-486b-98d9-1cad9cae8974", "1", "Admin", "Admin" },
                    { "dc460f91-7ee7-490b-9d0a-0c7dfe2ce5b7", "2", "Coach", "Coach" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a3f029ce-ccf9-421a-aaf9-4c5a1bf24925", "9149ad8e-862b-46f9-a327-44acf2c7cb2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2dcc3221-1121-4723-a30b-e15cce1f080f", "158293b4-3b76-435c-8c47-1c1810843428" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 1,
                column: "DateIssued",
                value: new DateTime(2025, 3, 21, 14, 33, 8, 774, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 2,
                column: "DateIssued",
                value: new DateTime(2025, 3, 21, 14, 33, 8, 774, DateTimeKind.Local).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 21, 14, 33, 8, 774, DateTimeKind.Local).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "TrainingSessions",
                keyColumn: "SessionID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 21, 14, 33, 8, 774, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "TrainingSessions",
                keyColumn: "SessionID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 21, 14, 33, 8, 774, DateTimeKind.Local).AddTicks(2624));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10efd525-49de-4dce-9d8e-739f0be5a5e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7398990-2a09-486b-98d9-1cad9cae8974");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc460f91-7ee7-490b-9d0a-0c7dfe2ce5b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "acb2aa2c-cc92-424d-b5ff-2cc3f1e7f9a4", "e077680f-8af7-4699-813f-a4e3e8c2e0f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f8e173f-64e6-4707-8532-b15857f860ab", "f63e0991-062c-48c9-b585-baca6d5d1ff7" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 1,
                column: "DateIssued",
                value: new DateTime(2025, 3, 11, 12, 21, 21, 304, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 2,
                column: "DateIssued",
                value: new DateTime(2025, 3, 11, 12, 21, 21, 304, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 11, 12, 21, 21, 304, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "TrainingSessions",
                keyColumn: "SessionID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 11, 12, 21, 21, 304, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "TrainingSessions",
                keyColumn: "SessionID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 11, 12, 21, 21, 304, DateTimeKind.Local).AddTicks(2609));
        }
    }
}
