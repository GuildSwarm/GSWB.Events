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
                name: "EventRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Slots = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoles", x => x.Id);
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
                name: "EventRoster",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Descriptions = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoster", x => x.Id);
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
                name: "ParticipationRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequiredRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequiredLicenseId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsGameHandleVerificationRequired = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipationRequirements", x => x.Id);
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
                    DiscordTemplateId = table.Column<Guid>(type: "uuid", nullable: true),
                    DiscordEventId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ExpectedDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LaunchDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
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
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
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
                name: "EventRoleEventRoster",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RostersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoleEventRoster", x => new { x.RolesId, x.RostersId });
                    table.ForeignKey(
                        name: "FK_EventRoleEventRoster_EventRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "EventRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRoleEventRoster_EventRoster_RostersId",
                        column: x => x.RostersId,
                        principalTable: "EventRoster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRoleParticipationRequirement",
                columns: table => new
                {
                    EventRolesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipationRequirementsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoleParticipationRequirement", x => new { x.EventRolesId, x.ParticipationRequirementsId });
                    table.ForeignKey(
                        name: "FK_EventRoleParticipationRequirement_EventRoles_EventRolesId",
                        column: x => x.EventRolesId,
                        principalTable: "EventRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRoleParticipationRequirement_ParticipationRequirements~",
                        column: x => x.ParticipationRequirementsId,
                        principalTable: "ParticipationRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRoleTemplateParticipationRequirement",
                columns: table => new
                {
                    EventRoleTemplatesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoleTemplateParticipationRequirement", x => new { x.EventRoleTemplatesId, x.RequirementsId });
                    table.ForeignKey(
                        name: "FK_EventRoleTemplateParticipationRequirement_EventRoleTemplate~",
                        column: x => x.EventRoleTemplatesId,
                        principalTable: "EventRoleTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRoleTemplateParticipationRequirement_ParticipationRequ~",
                        column: x => x.RequirementsId,
                        principalTable: "ParticipationRequirements",
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
                    SentAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ReceivedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
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
                        name: "FK_EventActivities_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventManagemers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Logbook = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventManagemers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventManagemers_Events_Id",
                        column: x => x.Id,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipationRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipationRequirementId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipationRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventParticipationRequirements_Events_Id",
                        column: x => x.Id,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    ParticipantNotes = table.Column<string>(type: "text", nullable: true),
                    ManagerNotes = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_EventParticipations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTag_Events_Id",
                        column: x => x.Id,
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
                name: "EventRoleTemplateEventTemplate",
                columns: table => new
                {
                    EventRoleTemplatesId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventTemplatesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoleTemplateEventTemplate", x => new { x.EventRoleTemplatesId, x.EventTemplatesId });
                    table.ForeignKey(
                        name: "FK_EventRoleTemplateEventTemplate_EventRoleTemplates_EventRole~",
                        column: x => x.EventRoleTemplatesId,
                        principalTable: "EventRoleTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRoleTemplateEventTemplate_EventTemplates_EventTemplate~",
                        column: x => x.EventTemplatesId,
                        principalTable: "EventTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTemplateParticipationRequirement",
                columns: table => new
                {
                    EventTemplatesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTemplateParticipationRequirement", x => new { x.EventTemplatesId, x.RequirementsId });
                    table.ForeignKey(
                        name: "FK_EventTemplateParticipationRequirement_EventTemplates_EventT~",
                        column: x => x.EventTemplatesId,
                        principalTable: "EventTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTemplateParticipationRequirement_ParticipationRequirem~",
                        column: x => x.RequirementsId,
                        principalTable: "ParticipationRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTemplateTag",
                columns: table => new
                {
                    EventTemplatesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTemplateTag", x => new { x.EventTemplatesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_EventTemplateTag_EventTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "EventTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTemplateTag_EventTemplates_EventTemplatesId",
                        column: x => x.EventTemplatesId,
                        principalTable: "EventTemplates",
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
                name: "IX_EventActivities_EventId",
                table: "EventActivities",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipations_ChannelId",
                table: "EventParticipations",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipations_EventId",
                table: "EventParticipations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoleEventRoster_RostersId",
                table: "EventRoleEventRoster",
                column: "RostersId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoleParticipationRequirement_ParticipationRequirements~",
                table: "EventRoleParticipationRequirement",
                column: "ParticipationRequirementsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoleTemplateEventTemplate_EventTemplatesId",
                table: "EventRoleTemplateEventTemplate",
                column: "EventTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoleTemplateParticipationRequirement_RequirementsId",
                table: "EventRoleTemplateParticipationRequirement",
                column: "RequirementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DiscordTemplateId",
                table: "Events",
                column: "DiscordTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTemplateParticipationRequirement_RequirementsId",
                table: "EventTemplateParticipationRequirement",
                column: "RequirementsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTemplates_DiscordTemplateId",
                table: "EventTemplates",
                column: "DiscordTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTemplateTag_TagsId",
                table: "EventTemplateTag",
                column: "TagsId");

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
                name: "EventManagemers");

            migrationBuilder.DropTable(
                name: "EventParticipationRequirements");

            migrationBuilder.DropTable(
                name: "EventParticipations");

            migrationBuilder.DropTable(
                name: "EventRoleEventRoster");

            migrationBuilder.DropTable(
                name: "EventRoleParticipationRequirement");

            migrationBuilder.DropTable(
                name: "EventRoleTemplateEventTemplate");

            migrationBuilder.DropTable(
                name: "EventRoleTemplateParticipationRequirement");

            migrationBuilder.DropTable(
                name: "EventTag");

            migrationBuilder.DropTable(
                name: "EventTemplateParticipationRequirement");

            migrationBuilder.DropTable(
                name: "EventTemplateTag");

            migrationBuilder.DropTable(
                name: "StaticTransactions");

            migrationBuilder.DropTable(
                name: "EventRoster");

            migrationBuilder.DropTable(
                name: "EventRoles");

            migrationBuilder.DropTable(
                name: "EventRoleTemplates");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ParticipationRequirements");

            migrationBuilder.DropTable(
                name: "EventTags");

            migrationBuilder.DropTable(
                name: "EventTemplates");

            migrationBuilder.DropTable(
                name: "ActivityParticipations");

            migrationBuilder.DropTable(
                name: "DiscordEventChannels");

            migrationBuilder.DropTable(
                name: "DiscordEventChannelTemplate");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
