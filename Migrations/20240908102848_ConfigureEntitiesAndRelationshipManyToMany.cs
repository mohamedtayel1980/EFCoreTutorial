using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureEntitiesAndRelationshipManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Attendees_AttendeesAttendeeId",
                table: "EventAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Events_EventsEventId",
                table: "EventAttendees");

            migrationBuilder.RenameColumn(
                name: "EventsEventId",
                table: "EventAttendees",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "AttendeesAttendeeId",
                table: "EventAttendees",
                newName: "AttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventAttendees_EventsEventId",
                table: "EventAttendees",
                newName: "IX_EventAttendees_EventId");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedOn",
                table: "EventAttendees",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Attendees_AttendeeId",
                table: "EventAttendees",
                column: "AttendeeId",
                principalTable: "Attendees",
                principalColumn: "AttendeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Events_EventId",
                table: "EventAttendees",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Attendees_AttendeeId",
                table: "EventAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Events_EventId",
                table: "EventAttendees");

            migrationBuilder.DropColumn(
                name: "JoinedOn",
                table: "EventAttendees");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventAttendees",
                newName: "EventsEventId");

            migrationBuilder.RenameColumn(
                name: "AttendeeId",
                table: "EventAttendees",
                newName: "AttendeesAttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventAttendees_EventId",
                table: "EventAttendees",
                newName: "IX_EventAttendees_EventsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Attendees_AttendeesAttendeeId",
                table: "EventAttendees",
                column: "AttendeesAttendeeId",
                principalTable: "Attendees",
                principalColumn: "AttendeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Events_EventsEventId",
                table: "EventAttendees",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
