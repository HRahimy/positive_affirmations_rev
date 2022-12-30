using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebStack.Infrastructure.Persistence.Migrations.IdentityConfigurationDb
{
    /// <inheritdoc />
    public partial class InitialCreateIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity_config");

            migrationBuilder.CreateTable(
                name: "api_resources",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    displayname = table.Column<string>(name: "display_name", type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    allowedaccesstokensigningalgorithms = table.Column<string>(name: "allowed_access_token_signing_algorithms", type: "character varying(100)", maxLength: 100, nullable: true),
                    showindiscoverydocument = table.Column<bool>(name: "show_in_discovery_document", type: "boolean", nullable: false),
                    requireresourceindicator = table.Column<bool>(name: "require_resource_indicator", type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    lastaccessed = table.Column<DateTime>(name: "last_accessed", type: "timestamp without time zone", nullable: true),
                    noneditable = table.Column<bool>(name: "non_editable", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "api_scopes",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    displayname = table.Column<string>(name: "display_name", type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    showindiscoverydocument = table.Column<bool>(name: "show_in_discovery_document", type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    lastaccessed = table.Column<DateTime>(name: "last_accessed", type: "timestamp without time zone", nullable: true),
                    noneditable = table.Column<bool>(name: "non_editable", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scopes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    clientid = table.Column<string>(name: "client_id", type: "character varying(200)", maxLength: 200, nullable: false),
                    protocoltype = table.Column<string>(name: "protocol_type", type: "character varying(200)", maxLength: 200, nullable: false),
                    requireclientsecret = table.Column<bool>(name: "require_client_secret", type: "boolean", nullable: false),
                    clientname = table.Column<string>(name: "client_name", type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    clienturi = table.Column<string>(name: "client_uri", type: "character varying(2000)", maxLength: 2000, nullable: true),
                    logouri = table.Column<string>(name: "logo_uri", type: "character varying(2000)", maxLength: 2000, nullable: true),
                    requireconsent = table.Column<bool>(name: "require_consent", type: "boolean", nullable: false),
                    allowrememberconsent = table.Column<bool>(name: "allow_remember_consent", type: "boolean", nullable: false),
                    alwaysincludeuserclaimsinidtoken = table.Column<bool>(name: "always_include_user_claims_in_id_token", type: "boolean", nullable: false),
                    requirepkce = table.Column<bool>(name: "require_pkce", type: "boolean", nullable: false),
                    allowplaintextpkce = table.Column<bool>(name: "allow_plain_text_pkce", type: "boolean", nullable: false),
                    requirerequestobject = table.Column<bool>(name: "require_request_object", type: "boolean", nullable: false),
                    allowaccesstokensviabrowser = table.Column<bool>(name: "allow_access_tokens_via_browser", type: "boolean", nullable: false),
                    frontchannellogouturi = table.Column<string>(name: "front_channel_logout_uri", type: "character varying(2000)", maxLength: 2000, nullable: true),
                    frontchannellogoutsessionrequired = table.Column<bool>(name: "front_channel_logout_session_required", type: "boolean", nullable: false),
                    backchannellogouturi = table.Column<string>(name: "back_channel_logout_uri", type: "character varying(2000)", maxLength: 2000, nullable: true),
                    backchannellogoutsessionrequired = table.Column<bool>(name: "back_channel_logout_session_required", type: "boolean", nullable: false),
                    allowofflineaccess = table.Column<bool>(name: "allow_offline_access", type: "boolean", nullable: false),
                    identitytokenlifetime = table.Column<int>(name: "identity_token_lifetime", type: "integer", nullable: false),
                    allowedidentitytokensigningalgorithms = table.Column<string>(name: "allowed_identity_token_signing_algorithms", type: "character varying(100)", maxLength: 100, nullable: true),
                    accesstokenlifetime = table.Column<int>(name: "access_token_lifetime", type: "integer", nullable: false),
                    authorizationcodelifetime = table.Column<int>(name: "authorization_code_lifetime", type: "integer", nullable: false),
                    consentlifetime = table.Column<int>(name: "consent_lifetime", type: "integer", nullable: true),
                    absoluterefreshtokenlifetime = table.Column<int>(name: "absolute_refresh_token_lifetime", type: "integer", nullable: false),
                    slidingrefreshtokenlifetime = table.Column<int>(name: "sliding_refresh_token_lifetime", type: "integer", nullable: false),
                    refreshtokenusage = table.Column<int>(name: "refresh_token_usage", type: "integer", nullable: false),
                    updateaccesstokenclaimsonrefresh = table.Column<bool>(name: "update_access_token_claims_on_refresh", type: "boolean", nullable: false),
                    refreshtokenexpiration = table.Column<int>(name: "refresh_token_expiration", type: "integer", nullable: false),
                    accesstokentype = table.Column<int>(name: "access_token_type", type: "integer", nullable: false),
                    enablelocallogin = table.Column<bool>(name: "enable_local_login", type: "boolean", nullable: false),
                    includejwtid = table.Column<bool>(name: "include_jwt_id", type: "boolean", nullable: false),
                    alwayssendclientclaims = table.Column<bool>(name: "always_send_client_claims", type: "boolean", nullable: false),
                    clientclaimsprefix = table.Column<string>(name: "client_claims_prefix", type: "character varying(200)", maxLength: 200, nullable: true),
                    pairwisesubjectsalt = table.Column<string>(name: "pair_wise_subject_salt", type: "character varying(200)", maxLength: 200, nullable: true),
                    userssolifetime = table.Column<int>(name: "user_sso_lifetime", type: "integer", nullable: true),
                    usercodetype = table.Column<string>(name: "user_code_type", type: "character varying(100)", maxLength: 100, nullable: true),
                    devicecodelifetime = table.Column<int>(name: "device_code_lifetime", type: "integer", nullable: false),
                    cibalifetime = table.Column<int>(name: "ciba_lifetime", type: "integer", nullable: true),
                    pollinginterval = table.Column<int>(name: "polling_interval", type: "integer", nullable: true),
                    coordinatelifetimewithusersession = table.Column<bool>(name: "coordinate_lifetime_with_user_session", type: "boolean", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    lastaccessed = table.Column<DateTime>(name: "last_accessed", type: "timestamp without time zone", nullable: true),
                    noneditable = table.Column<bool>(name: "non_editable", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identity_providers",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scheme = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    displayname = table.Column<string>(name: "display_name", type: "character varying(200)", maxLength: 200, nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    properties = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    lastaccessed = table.Column<DateTime>(name: "last_accessed", type: "timestamp without time zone", nullable: true),
                    noneditable = table.Column<bool>(name: "non_editable", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identity_resources",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    displayname = table.Column<string>(name: "display_name", type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    showindiscoverydocument = table.Column<bool>(name: "show_in_discovery_document", type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    noneditable = table.Column<bool>(name: "non_editable", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "api_resource_claims",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apiresourceid = table.Column<int>(name: "api_resource_id", type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_resource_claims_api_resources_api_resource_id",
                        column: x => x.apiresourceid,
                        principalSchema: "identity_config",
                        principalTable: "api_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_resource_properties",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apiresourceid = table.Column<int>(name: "api_resource_id", type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_resource_properties_api_resources_api_resource_id",
                        column: x => x.apiresourceid,
                        principalSchema: "identity_config",
                        principalTable: "api_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_resource_scopes",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    apiresourceid = table.Column<int>(name: "api_resource_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_scopes", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_resource_scopes_api_resources_api_resource_id",
                        column: x => x.apiresourceid,
                        principalSchema: "identity_config",
                        principalTable: "api_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_resource_secrets",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apiresourceid = table.Column<int>(name: "api_resource_id", type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_secrets", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_resource_secrets_api_resources_api_resource_id",
                        column: x => x.apiresourceid,
                        principalSchema: "identity_config",
                        principalTable: "api_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_scope_claims",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scopeid = table.Column<int>(name: "scope_id", type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scope_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_scope_claims_api_scopes_scope_id",
                        column: x => x.scopeid,
                        principalSchema: "identity_config",
                        principalTable: "api_scopes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_scope_properties",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scopeid = table.Column<int>(name: "scope_id", type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scope_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_scope_properties_api_scopes_scope_id",
                        column: x => x.scopeid,
                        principalSchema: "identity_config",
                        principalTable: "api_scopes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_claims",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_claims_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_cors_origins",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    origin = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_cors_origins", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_cors_origins_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_grant_types",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    granttype = table.Column<string>(name: "grant_type", type: "character varying(250)", maxLength: 250, nullable: false),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_grant_types", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_grant_types_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_id_prestrictions",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provider = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_id_prestrictions", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_id_prestrictions_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_post_logout_redirect_uris",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    postlogoutredirecturi = table.Column<string>(name: "post_logout_redirect_uri", type: "character varying(400)", maxLength: 400, nullable: false),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_post_logout_redirect_uris", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_post_logout_redirect_uris_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_properties",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_properties_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_redirect_uris",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    redirecturi = table.Column<string>(name: "redirect_uri", type: "character varying(400)", maxLength: 400, nullable: false),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_redirect_uris", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_redirect_uris_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_scopes",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_scopes", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_scopes_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_secrets",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clientid = table.Column<int>(name: "client_id", type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_secrets", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_secrets_clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "identity_config",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_resource_claims",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    identityresourceid = table.Column<int>(name: "identity_resource_id", type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resource_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_identity_resource_claims_identity_resources_identity_resour~",
                        column: x => x.identityresourceid,
                        principalSchema: "identity_config",
                        principalTable: "identity_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_resource_properties",
                schema: "identity_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    identityresourceid = table.Column<int>(name: "identity_resource_id", type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resource_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_identity_resource_properties_identity_resources_identity_re~",
                        column: x => x.identityresourceid,
                        principalSchema: "identity_config",
                        principalTable: "identity_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_claims_api_resource_id_type",
                schema: "identity_config",
                table: "api_resource_claims",
                columns: new[] { "api_resource_id", "type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_properties_api_resource_id_key",
                schema: "identity_config",
                table: "api_resource_properties",
                columns: new[] { "api_resource_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_scopes_api_resource_id_scope",
                schema: "identity_config",
                table: "api_resource_scopes",
                columns: new[] { "api_resource_id", "scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_secrets_api_resource_id",
                schema: "identity_config",
                table: "api_resource_secrets",
                column: "api_resource_id");

            migrationBuilder.CreateIndex(
                name: "ix_api_resources_name",
                schema: "identity_config",
                table: "api_resources",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_scope_claims_scope_id_type",
                schema: "identity_config",
                table: "api_scope_claims",
                columns: new[] { "scope_id", "type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_scope_properties_scope_id_key",
                schema: "identity_config",
                table: "api_scope_properties",
                columns: new[] { "scope_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_scopes_name",
                schema: "identity_config",
                table: "api_scopes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_claims_client_id_type_value",
                schema: "identity_config",
                table: "client_claims",
                columns: new[] { "client_id", "type", "value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_cors_origins_client_id_origin",
                schema: "identity_config",
                table: "client_cors_origins",
                columns: new[] { "client_id", "origin" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_grant_types_client_id_grant_type",
                schema: "identity_config",
                table: "client_grant_types",
                columns: new[] { "client_id", "grant_type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_id_prestrictions_client_id_provider",
                schema: "identity_config",
                table: "client_id_prestrictions",
                columns: new[] { "client_id", "provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_post_logout_redirect_uris_client_id_post_logout_redi~",
                schema: "identity_config",
                table: "client_post_logout_redirect_uris",
                columns: new[] { "client_id", "post_logout_redirect_uri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_properties_client_id_key",
                schema: "identity_config",
                table: "client_properties",
                columns: new[] { "client_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_redirect_uris_client_id_redirect_uri",
                schema: "identity_config",
                table: "client_redirect_uris",
                columns: new[] { "client_id", "redirect_uri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_scopes_client_id_scope",
                schema: "identity_config",
                table: "client_scopes",
                columns: new[] { "client_id", "scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_secrets_client_id",
                schema: "identity_config",
                table: "client_secrets",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_clients_client_id",
                schema: "identity_config",
                table: "clients",
                column: "client_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_providers_scheme",
                schema: "identity_config",
                table: "identity_providers",
                column: "scheme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_resource_claims_identity_resource_id_type",
                schema: "identity_config",
                table: "identity_resource_claims",
                columns: new[] { "identity_resource_id", "type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_resource_properties_identity_resource_id_key",
                schema: "identity_config",
                table: "identity_resource_properties",
                columns: new[] { "identity_resource_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_resources_name",
                schema: "identity_config",
                table: "identity_resources",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "api_resource_claims",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "api_resource_properties",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "api_resource_scopes",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "api_resource_secrets",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "api_scope_claims",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "api_scope_properties",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_claims",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_cors_origins",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_grant_types",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_id_prestrictions",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_post_logout_redirect_uris",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_properties",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_redirect_uris",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_scopes",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "client_secrets",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "identity_providers",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "identity_resource_claims",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "identity_resource_properties",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "api_resources",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "api_scopes",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "identity_config");

            migrationBuilder.DropTable(
                name: "identity_resources",
                schema: "identity_config");
        }
    }
}
