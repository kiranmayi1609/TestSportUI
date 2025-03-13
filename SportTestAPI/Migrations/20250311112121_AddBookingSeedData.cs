using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportTestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "CourtID", "Date", "UserID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "123" },
                    { 2, 2, new DateTime(2025, 3, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), "143" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "88f97a79-7c71-46ea-8f4f-67b9a798d545", "46745e64-f998-4461-ad9f-fcc90c6b9cd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e2d1dfa0-0830-4a46-95a4-ac6552ae69bb", "b0fbf43f-ec1f-411d-9022-2728f2840983" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 1,
                column: "DateIssued",
                value: new DateTime(2025, 3, 11, 12, 14, 6, 846, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 2,
                column: "DateIssued",
                value: new DateTime(2025, 3, 11, 12, 14, 6, 846, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 11, 12, 14, 6, 846, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "TrainingSessions",
                keyColumn: "SessionID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 11, 12, 14, 6, 846, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "TrainingSessions",
                keyColumn: "SessionID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 11, 12, 14, 6, 846, DateTimeKind.Local).AddTicks(2101));
        }
    }
}
