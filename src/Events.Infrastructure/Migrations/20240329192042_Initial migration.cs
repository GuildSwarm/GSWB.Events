using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscordEventChannels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    DiscordChannelId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordEventChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscordEventChannels_DiscordEventChannels_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DiscordEventChannels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiscordEventChannelTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    DiscordChannelId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordEventChannelTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscordEventChannelTemplate_DiscordEventChannelTemplate_Par~",
                        column: x => x.ParentId,
                        principalTable: "DiscordEventChannelTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequiredRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequiredLicenseId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsGameHandleVerificationRequired = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventRoleTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    RequiredCount = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoleTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityParticipations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentRatio = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ActivityId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityParticipations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityParticipations_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscordEventId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ExpectedDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscordTemplateId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_DiscordEventChannels_DiscordTemplateId",
                        column: x => x.DiscordTemplateId,
                        principalTable: "DiscordEventChannels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ExpectedDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscordTemplateId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTemplates_DiscordEventChannelTemplate_DiscordTemplateId",
                        column: x => x.DiscordTemplateId,
                        principalTable: "DiscordEventChannelTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventRequirementEventRoleTemplate",
                columns: table => new
                {
                    EventRequirementsId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventRoleTemplatesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRequirementEventRoleTemplate", x => new { x.EventRequirementsId, x.EventRoleTemplatesId });
                    table.ForeignKey(
                        name: "FK_EventRequirementEventRoleTemplate_EventRequirements_EventRe~",
                        column: x => x.EventRequirementsId,
                        principalTable: "EventRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRequirementEventRoleTemplate_EventRoleTemplates_EventR~",
                        column: x => x.EventRoleTemplatesId,
                        principalTable: "EventRoleTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DynamicTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReceivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicTransactions_ActivityParticipations_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "ActivityParticipations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DynamicTransactions_ActivityParticipations_SenderId",
                        column: x => x.SenderId,
                        principalTable: "ActivityParticipations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaticTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    ParticipationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticTransactions_ActivityParticipations_ParticipationId",
                        column: x => x.ParticipationId,
                        principalTable: "ActivityParticipations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventActivities_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEventRequirement",
                columns: table => new
                {
                    EventRequirementsId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEventRequirement", x => new { x.EventRequirementsId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_EventEventRequirement_EventRequirements_EventRequirementsId",
                        column: x => x.EventRequirementsId,
                        principalTable: "EventRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEventRequirement_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEventTag",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEventTag", x => new { x.EventsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_EventEventTag_EventTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "EventTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEventTag_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventManagemers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Logbook = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventManagemers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventManagemers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MaxSlots = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRoles_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EventTemplateId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityTemplates_EventTemplates_EventTemplateId",
                        column: x => x.EventTemplateId,
                        principalTable: "EventTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventRequirementEventTemplate",
                columns: table => new
                {
                    EventRequirementsId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventTemplatesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRequirementEventTemplate", x => new { x.EventRequirementsId, x.EventTemplatesId });
                    table.ForeignKey(
                        name: "FK_EventRequirementEventTemplate_EventRequirements_EventRequir~",
                        column: x => x.EventRequirementsId,
                        principalTable: "EventRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRequirementEventTemplate_EventTemplates_EventTemplates~",
                        column: x => x.EventTemplatesId,
                        principalTable: "EventTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRoleTemplateEventTemplate",
                columns: table => new
                {
                    EventRoleTemplatesId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventTemplateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoleTemplateEventTemplate", x => new { x.EventRoleTemplatesId, x.EventTemplateId });
                    table.ForeignKey(
                        name: "FK_EventRoleTemplateEventTemplate_EventRoleTemplates_EventRole~",
                        column: x => x.EventRoleTemplatesId,
                        principalTable: "EventRoleTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRoleTemplateEventTemplate_EventTemplates_EventTemplate~",
                        column: x => x.EventTemplateId,
                        principalTable: "EventTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTagEventTemplate",
                columns: table => new
                {
                    EventTemplatesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTagEventTemplate", x => new { x.EventTemplatesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_EventTagEventTemplate_EventTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "EventTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTagEventTemplate_EventTemplates_EventTemplatesId",
                        column: x => x.EventTemplatesId,
                        principalTable: "EventTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    ParticipantNotes = table.Column<string>(type: "text", nullable: true),
                    ManagerNotes = table.Column<string>(type: "text", nullable: true),
                    EventRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChannelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventParticipations_DiscordEventChannels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "DiscordEventChannels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventParticipations_EventRoles_EventRoleId",
                        column: x => x.EventRoleId,
                        principalTable: "EventRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRequirementEventRole",
                columns: table => new
                {
                    EventRequirementsId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventRolesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRequirementEventRole", x => new { x.EventRequirementsId, x.EventRolesId });
                    table.ForeignKey(
                        name: "FK_EventRequirementEventRole_EventRequirements_EventRequiremen~",
                        column: x => x.EventRequirementsId,
                        principalTable: "EventRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRequirementEventRole_EventRoles_EventRolesId",
                        column: x => x.EventRolesId,
                        principalTable: "EventRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityParticipations_ActivityId",
                table: "ActivityParticipations",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTemplates_EventTemplateId",
                table: "ActivityTemplates",
                column: "EventTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscordEventChannels_ParentId",
                table: "DiscordEventChannels",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscordEventChannelTemplate_ParentId",
                table: "DiscordEventChannelTemplate",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicTransactions_ReceiverId",
                table: "DynamicTransactions",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicTransactions_SenderId",
                table: "DynamicTransactions",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EventActivities_ActivityId",
                table: "EventActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventActivities_EventId",
                table: "EventActivities",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEventRequirement_EventsId",
                table: "EventEventRequirement",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEventTag_TagsId",
                table: "EventEventTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventManagemers_EventId",
                table: "EventManagemers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipations_ChannelId",
                table: "EventParticipations",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipations_EventRoleId",
                table: "EventParticipations",
                column: "EventRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequirementEventRole_EventRolesId",
                table: "EventRequirementEventRole",
                column: "EventRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequirementEventRoleTemplate_EventRoleTemplatesId",
                table: "EventRequirementEventRoleTemplate",
                column: "EventRoleTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequirementEventTemplate_EventTemplatesId",
                table: "EventRequirementEventTemplate",
                column: "EventTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoles_EventId",
                table: "EventRoles",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoleTemplateEventTemplate_EventTemplateId",
                table: "EventRoleTemplateEventTemplate",
                column: "EventTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DiscordTemplateId",
                table: "Events",
                column: "DiscordTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTagEventTemplate_TagsId",
                table: "EventTagEventTemplate",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTemplates_DiscordTemplateId",
                table: "EventTemplates",
                column: "DiscordTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticTransactions_ParticipationId",
                table: "StaticTransactions",
                column: "ParticipationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityTemplates");

            migrationBuilder.DropTable(
                name: "DynamicTransactions");

            migrationBuilder.DropTable(
                name: "EventActivities");

            migrationBuilder.DropTable(
                name: "EventEventRequirement");

            migrationBuilder.DropTable(
                name: "EventEventTag");

            migrationBuilder.DropTable(
                name: "EventManagemers");

            migrationBuilder.DropTable(
                name: "EventParticipations");

            migrationBuilder.DropTable(
                name: "EventRequirementEventRole");

            migrationBuilder.DropTable(
                name: "EventRequirementEventRoleTemplate");

            migrationBuilder.DropTable(
                name: "EventRequirementEventTemplate");

            migrationBuilder.DropTable(
                name: "EventRoleTemplateEventTemplate");

            migrationBuilder.DropTable(
                name: "EventTagEventTemplate");

            migrationBuilder.DropTable(
                name: "StaticTransactions");

            migrationBuilder.DropTable(
                name: "EventRoles");

            migrationBuilder.DropTable(
                name: "EventRequirements");

            migrationBuilder.DropTable(
                name: "EventRoleTemplates");

            migrationBuilder.DropTable(
                name: "EventTags");

            migrationBuilder.DropTable(
                name: "EventTemplates");

            migrationBuilder.DropTable(
                name: "ActivityParticipations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "DiscordEventChannelTemplate");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "DiscordEventChannels");
        }
    }
}
